using UnityEngine;
using UnityEngine.UI;

public class UIButtonBackMainMenu : MonoBehaviour
{
    [Header("Back Buttons")]
    [SerializeField] private Button btnBackSettings; 
    [SerializeField] private Button btnBackCreditts; 

    [Header("Panels")]
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject CredittsPanel;

    private void Awake()
    {
        btnBackSettings.onClick.AddListener(OnBackButtonSettingsClicked);  
        btnBackCreditts.onClick.AddListener(OnBackButtonCredittsClicked); 
    }

    private void OnDestroy()
    {
        btnBackSettings.onClick.RemoveListener(OnBackButtonSettingsClicked);
        btnBackCreditts.onClick.RemoveListener(OnBackButtonCredittsClicked);
    }

    private void OnBackButtonSettingsClicked()
    {
        Menu.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    private void OnBackButtonCredittsClicked()
    {
        Menu.SetActive(true);
        CredittsPanel.SetActive(false);
    }
}