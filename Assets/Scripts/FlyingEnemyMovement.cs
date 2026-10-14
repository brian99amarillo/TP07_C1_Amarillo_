using UnityEngine;
using System.Collections;

public class FlyingEnemyMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private SetttingsEnemySO setttingsEnemy;
    [SerializeField] private BulletEnemy bulletEnemy;
    [SerializeField] private BulletEnemy bulletPrefab;
    [SerializeField] private Transform Gun;
    [SerializeField] private Animator animator;
    [SerializeField] private float waitTime = 0.8f;
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

        if (transform.position.y > 3.5f && !hasShot)
        {
            StartCoroutine(WaitAndShoot());
        }

        if (transform.position.y < -2.5f)
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

        yield return new WaitForSeconds(waitTime);
        animator.SetBool("isIdle", true);
        rb.linearVelocity = new Vector2(rb.linearVelocityX, -setttingsEnemy.Speed);
        isWaiting = false;

    }
}
