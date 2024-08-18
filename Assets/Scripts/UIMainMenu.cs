using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;
    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !creditsPanel.activeSelf && !settingsPanel.activeSelf)
        {
            if (!mainPanel.activeSelf)
            {
                mainPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                mainPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        settingsButton.onClick.RemoveListener(OnCreditsButtonClicked);
        creditsButton.onClick.RemoveListener(OnCreditsButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        mainPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnSettingsButtonClicked()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void OnCreditsButtonClicked()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
