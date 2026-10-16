using UnityEngine;

public class PickebleHealt : MonoBehaviour
{
    [SerializeField] private float healthValue = 100f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Heal(healthValue);
            AudioManager.Instance.PlayerHealt();
            Destroy(gameObject);
        }
    }

}
