using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void QuitGame() {
        Application.Quit();//this line only works in build mode not play mode.
    }
}
