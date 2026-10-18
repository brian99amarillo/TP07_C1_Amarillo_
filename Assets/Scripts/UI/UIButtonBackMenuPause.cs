using UnityEngine;
using UnityEngine.UI;

public class UIButtonBackMenuPause : MonoBehaviour
{
    [SerializeField] private UIMenuPause UIMenuPause; // Referencia al script UIMenuPause para acceder a la variable isPause
    [Header("Back Buttons")]
    [SerializeField] private Button btnBackSettings; // Boton Back desde settings del menu de pausa
    [SerializeField] private Button btnBackCredits; // Boton Back desde creditos del menu de pausa

    private void Awake()
    {
        // Botones de volver
        btnBackSettings.onClick.AddListener(OnBackButtonSettingsClicked);  // Back de settings
        btnBackCredits.onClick.AddListener(OnBackButtonCreditsClicked); // Back de los creditos
    }

    private void OnDestroy()
    {
        btnBackSettings.onClick.RemoveListener(OnBackButtonSettingsClicked);
        btnBackCredits.onClick.RemoveListener(OnBackButtonCreditsClicked);
    }

    private void OnBackButtonSettingsClicked()
    {
        UIMenuPause.ReturnToPauseMenu();
    }

    private void OnBackButtonCreditsClicked()
    {
        UIMenuPause.ReturnToPauseMenu();
    }
}
