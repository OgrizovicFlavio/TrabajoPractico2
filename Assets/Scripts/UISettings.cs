using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider sliderSpeedPlayer1;
    [SerializeField] private Slider sliderSpeedPlayer2;
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI textSpeedPlayer1;
    [SerializeField] private TextMeshProUGUI textSpeedPlayer2;
    [Header("Buttons")]
    [SerializeField] private Button backButtonSettings;
    [Header("Panels")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [Header("Players")]
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    private void Awake()
    {
        sliderSpeedPlayer1.onValueChanged.AddListener(OnValueChangedSliderPlayer1);
        sliderSpeedPlayer2.onValueChanged.AddListener(OnValueChangedSliderPlayer2);
        backButtonSettings.onClick.AddListener(OnBackButtonSettingsClicked);
    }

    void Update()
    {

    }

    private void OnDestroy()
    {
        sliderSpeedPlayer1.onValueChanged.RemoveListener(OnValueChangedSliderPlayer1);
        sliderSpeedPlayer2.onValueChanged.RemoveListener(OnValueChangedSliderPlayer2);
        backButtonSettings.onClick.RemoveListener(OnBackButtonSettingsClicked);
    }

    private void OnValueChangedSliderPlayer1(float value)
    {
        player1.SetMovementSpeed(value);
        textSpeedPlayer1.text = value.ToString();
    }

    private void OnValueChangedSliderPlayer2(float value)
    {
        player2.SetMovementSpeed(value);
        textSpeedPlayer2.text = value.ToString();
    }

    private void OnBackButtonSettingsClicked()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
