using UnityEngine;
using UnityEngine.UI;

public class UIHealtPlayer : MonoBehaviour
{
    public static UIHealtPlayer Instance { get; private set; }
    [SerializeField] private Image barLife;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHealthBar(float currentLife, float maxLife)
    {
        barLife.fillAmount = currentLife / maxLife;
    }


}
