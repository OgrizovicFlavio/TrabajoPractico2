using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPanel.activeSelf)
        {
            if (!mainMenuPanel.activeSelf)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        mainMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Resume()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
