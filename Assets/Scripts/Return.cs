using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Return : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button returnbtn;
    void Start()
    {
        returnbtn.onClick.AddListener(ReturnToGame);
    }
    void ReturnToGame() {

        Time.timeScale = 1;
        SceneManager.LoadScene(PauseMenu.gameLevel);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(PauseMenu.gameLevel));
    }
}
