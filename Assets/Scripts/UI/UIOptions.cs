using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions: MonoBehaviour
{
    [Header("Player 1")]
    [SerializeField] private Slider speedSliderPlayer1;
    [SerializeField] private TextMeshProUGUI speedCounterPlayer1;
    [SerializeField] private PaddleMovement movementPlayer1;
    [SerializeField] private Slider heightSliderPlayer1;
    [SerializeField] private TextMeshProUGUI heightCounterPlayer1;
    [SerializeField] private PaddleSize heightPlayer1;
    [SerializeField] private Slider colorSliderPlayer1;
    [SerializeField] private PaddleColor colorPlayer1;

    [Header("Player 2")]
    [SerializeField] private Slider speedSliderPlayer2;
    [SerializeField] private TextMeshProUGUI speedCounterPlayer2;
    [SerializeField] private PaddleMovement movementPlayer2;
    [SerializeField] private Slider heightSliderPlayer2;
    [SerializeField] private TextMeshProUGUI heightCounterPlayer2;
    [SerializeField] private PaddleSize heightPlayer2;
    [SerializeField] private Slider colorSliderPlayer2;
    [SerializeField] private PaddleColor colorPlayer2;

    [Header("UI")]
    [SerializeField] private Button backButtonSettings;
    [SerializeField] private GameObject mainMenuPanel;

    private void Awake()
    {
        speedSliderPlayer1.onValueChanged.AddListener(OnValueChangedSpeedP1);
        speedSliderPlayer2.onValueChanged.AddListener(OnValueChangedSpeedP2);
        heightSliderPlayer1.onValueChanged.AddListener(OnValueChangedHeightSliderP1);
        heightSliderPlayer2.onValueChanged.AddListener(OnValueChangedHeightSliderP2);
        colorSliderPlayer1.onValueChanged.AddListener(OnValueChangedColorSliderP1);
        colorSliderPlayer2.onValueChanged.AddListener(OnValueChangedColorSliderP2);
        backButtonSettings.onClick.AddListener(OnBackButtonSettingsClicked);
    }

    private void OnDestroy()
    {
        speedSliderPlayer1.onValueChanged.RemoveListener(OnValueChangedSpeedP1);
        speedSliderPlayer2.onValueChanged.RemoveListener(OnValueChangedSpeedP2);
        heightSliderPlayer1.onValueChanged.RemoveListener(OnValueChangedHeightSliderP1);
        heightSliderPlayer2.onValueChanged.RemoveListener(OnValueChangedHeightSliderP2);
        colorSliderPlayer1.onValueChanged.RemoveListener(OnValueChangedColorSliderP1);
        colorSliderPlayer2.onValueChanged.RemoveListener(OnValueChangedColorSliderP2);
        backButtonSettings.onClick.RemoveListener(OnBackButtonSettingsClicked);
    }

    private void OnValueChangedSpeedP1(float value)
    {
        movementPlayer1.SetMovementSpeed(value);
        speedCounterPlayer1.text = value.ToString();
    }

    private void OnValueChangedSpeedP2(float value)
    {
        movementPlayer2.SetMovementSpeed(value);
        speedCounterPlayer2.text = value.ToString();
    }

    private void OnValueChangedHeightSliderP1(float value)
    {
        heightPlayer1.SetSizeX(value);
        heightCounterPlayer1.text = value.ToString();
    }

    private void OnValueChangedHeightSliderP2(float value)
    {
        heightPlayer2.SetSizeX(value);
        heightCounterPlayer2.text = value.ToString();
    }

    private void OnValueChangedColorSliderP1(float newColor)
    {
        colorPlayer1.SetColor(newColor);
    }

    private void OnValueChangedColorSliderP2(float newColor)
    {
        colorPlayer2.SetColor(newColor);
    }

    private void OnBackButtonSettingsClicked()
    {
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
