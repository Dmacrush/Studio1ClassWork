using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

}
