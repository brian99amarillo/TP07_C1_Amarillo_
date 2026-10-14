using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform Gun;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask ground;
    [SerializeField] private SettingsPlayerSO settingsPlayer;
    private Rigidbody2D rb;
    private float life;
    private float LongLine = 1f;
    private bool isWalking = false;
    private bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        life = settingsPlayer.Life;
        animator.SetBool("isGrounded", true);
    }
    private void Update()
    {

        isGrounded = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y + (LongLine * -1)), ground); // Verifica si el objeto está tocando el suelo
        animator.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, settingsPlayer.JumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        if (Input.GetKey(KeyCode.A)) // Si la tecla A está presionada el objeto se mueve hacia la izquierda
        {
            rb.linearVelocity = new Vector2(-settingsPlayer.Speed, rb.linearVelocity.y);
            transform.right = Vector2.left;
            isWalking = isGrounded;
            animator.SetBool("Walk", isWalking);

        }
        if (Input.GetKey(KeyCode.D)) // Si la tecla D está presionada el objeto se mueve hacia la derecha
        {
            rb.linearVelocity = new Vector2(settingsPlayer.Speed, rb.linearVelocity.y);
            transform.right = Vector2.right;
            isWalking = isGrounded;
            animator.SetBool("Walk", isWalking);
        }


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            isWalking = false;
            animator.SetBool("Walk", isWalking);
        }
            
        if (Input.GetMouseButtonDown(0))
        {
            Bullet bullet = Instantiate(bulletPrefab, Gun.position, Quaternion.identity);
            bullet.Shoot((int)Mathf.Sign(Gun.right.x));
        }
    }

    private void Damage(Collider2D collision)
    {
        life -= collision.GetComponent<BulletEnemy>().Damage;
        if (life <= 0)
        {
            Die();
        }
    }

    private void DamageCollision(Collider2D collision)
    {
        life -= collision.GetComponent<SetttingsEnemySO>().Damage;
        if (life <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamageCollision(collision.collider);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Damage(collision);
        }
    }

    private void Die()
    {
      Debug.Log("Player has died");
    }
}
