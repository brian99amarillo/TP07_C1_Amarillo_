using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private float lifeTime = 2f;
    private float damage = 25f;
    private float ontime = 0f;

    public float Damage { get { return damage; } }
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ontime += Time.deltaTime;
        if (ontime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(int Sing)
    {
        Vector3 direction = new Vector3(Sing, 0, 0).normalized;
        transform.up = direction;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
