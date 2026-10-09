using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private Bullet bulletPrefab;
   [SerializeField] private Transform Gun;
    private Rigidbody2D rb;
    private float speed = 5f;
    private float jumpForce = 5f;
    private float life = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) // Si la tecla A está presionada el objeto se mueve hacia la izquierda
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            transform.right= Vector2.left;
        }
        if (Input.GetKey(KeyCode.D)) // Si la tecla D está presionada el objeto se mueve hacia la derecha
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            transform.right= Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Bullet bullet = Instantiate(bulletPrefab, Gun.position, Quaternion.identity);
            bullet.Shoot((int)Mathf.Sign(Gun.right.x));
        }
    }





}
