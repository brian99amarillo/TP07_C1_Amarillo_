using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public static UITimer Instance;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject panelTimer;
    public static float timePowerUp = 5f;

    private void Awake()
    {
        Instance = this;
        panelTimer.SetActive(false);
    }

    public void PanelActived() => panelTimer.SetActive(true);
    public void TimerON(float t) => timerText.text = "Invisibility Actived: " + (t).ToString("f1");
    public void PanelDisable() => panelTimer.SetActive(false);
}
