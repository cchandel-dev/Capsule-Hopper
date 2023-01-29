using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUi;
    public static bool gamePaused = false;
    public static int gameLevel;
    [SerializeField] Button HelpButton, ResumeButton, ExitButton, SettingsButton;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameLevel = SceneManager.GetActiveScene().buildIndex;
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                PauseMenuUi.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Resume();
            }
        }
        HelpButton.onClick.AddListener(HelpMenu);
        ResumeButton.onClick.AddListener(Resume);
        ExitButton.onClick.AddListener(Exit);
        SettingsButton.onClick.AddListener(Settings);
    }
    void HelpMenu()
    {
        SceneManager.LoadScene("Help Screen");
        Scene helpScreen = SceneManager.GetSceneByName("Help Screen");
        SceneManager.SetActiveScene(helpScreen);  
    }
    void Resume() 
    {
        Time.timeScale = 1;
        PauseMenuUi.SetActive(false);
    }
    void Exit()
    {
        Application.Quit();
    }
    void Settings()
    {
        SceneManager.LoadScene("Settings Screen");
        Scene settingScreen = SceneManager.GetSceneByName("Settings Screen");
        SceneManager.SetActiveScene(settingScreen);
    }
}
