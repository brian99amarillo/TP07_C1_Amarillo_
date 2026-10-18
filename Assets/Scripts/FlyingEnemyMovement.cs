using UnityEngine;
using System.Collections;

public class FlyingEnemyMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private SettingsEnemySO setttingsEnemy;
    [SerializeField] private BulletEnemy bulletEnemy;
    [SerializeField] private BulletEnemy bulletPrefab;
    [SerializeField] private Transform Gun;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip enemyShoot;
    [SerializeField] private float waitTime = 0.8f;
    [SerializeField] private float HeightMin = 2.5f;
    [SerializeField] private float HeightMax = 7f;
    private bool isWaiting = false;
    bool hasShot = false;

    public bool HasShot
    {
        get { return hasShot; }
        set { hasShot = value; }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {   
        rb.linearVelocity = new Vector2(rb.linearVelocityX, setttingsEnemy.Speed);
        animator.SetBool("isIdle", true);
    }

    void Update()
    {
        if (isWaiting) return;

        if (transform.position.y > HeightMax && !hasShot)
        {
            StartCoroutine(WaitAndShoot());
        }

        if (transform.position.y < HeightMin)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, setttingsEnemy.Speed);
            hasShot = false;
        }
    }

    private IEnumerator WaitAndShoot()
    {
        isWaiting = true;
        hasShot = true;
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);
        animator.SetBool("isIdle", false);

        BulletEnemy bullet = Instantiate(bulletPrefab, Gun.position, Quaternion.identity);
        bullet.Launch(Vector2.down);
        EnemyShoot();

        yield return new WaitForSeconds(waitTime);
        animator.SetBool("isIdle", true);
        rb.linearVelocity = new Vector2(rb.linearVelocityX, -setttingsEnemy.Speed);
        isWaiting = false;
               
    }
    public void EnemyShoot() => sfx.PlayOneShot(enemyShoot);
}
