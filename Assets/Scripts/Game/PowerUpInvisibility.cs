using System.Collections;
using UnityEngine;

public class PowerUpInvisibility : MonoBehaviour

{
    [SerializeField] private GameObject PowerUpPrefab;
    [SerializeField] private Transform player;
    static public float counter = 0;

    private float timePowerUp = 5f;
    public static bool activedInvincibility = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && counter < 3)
        {
          Player player = collision.gameObject.GetComponent<Player>();
          StarsActived();
          player.StartCoroutine(InvicibilityRoutine());
          Destroy(gameObject);
       }
    }
    private IEnumerator InvicibilityRoutine()
    {
        activedInvincibility = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        UITimer.Instance.PanelActived();

        while (timePowerUp > 0f)
        {
            UITimer.Instance.TimerON(timePowerUp);
            yield return null;
            timePowerUp -= Time.deltaTime;
        }

        UITimer.Instance.PanelDisable();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
        activedInvincibility = false;
    }
    private void StarsActived()
    {
        counter++;
        UIStars.Instance.StarsCounter((int)counter);
    }
}