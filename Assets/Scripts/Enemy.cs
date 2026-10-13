using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem dieEnemy;
    [SerializeField] private Image image;
    private float life = 0f;
    private float maxLife = 100f;

    private void Start()
    {   
        life = maxLife;
        animator.SetBool("isIdle", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Damage(collision);
        }
    }

    private void Die()
    {
        dieEnemy.transform.SetParent(null);   // la particula se separa del enemigo para que no se destruya con él
        dieEnemy.Play();
        Destroy(dieEnemy.gameObject, 1f);     // la particula se borra sola cuando termina el efecto
        Destroy(gameObject);                  // destruye el enemigo
    }

    private void Damage(Collider2D collision)
    {
        life -= collision.GetComponent<Bullet>().Damage;
        image.fillAmount = life / maxLife;
        if (life <= 0)
        {
            Die();
        }
    }
}
