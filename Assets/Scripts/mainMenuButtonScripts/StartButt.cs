using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButt : MonoBehaviour
{
    public void StartGame()
    {
     
        SceneManager.LoadScene("Level1");

    }
}
