using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    private float life = 50f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= collision.GetComponent<Bullet>().Damage;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }



}
