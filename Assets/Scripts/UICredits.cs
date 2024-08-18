using UnityEngine;
using UnityEngine.UI;

public class UICredits : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button backButtonCredits;
    [Header("Panels")]
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject mainMenuPanel;

    private void Awake()
    {
        backButtonCredits.onClick.AddListener(OnBackButtonCreditsClicked);
    }

    void Update()
    {
        
    }

    private void OnDestroy()
    {
        backButtonCredits.onClick.RemoveListener(OnBackButtonCreditsClicked);
    }

    private void OnBackButtonCreditsClicked()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
