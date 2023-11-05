using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void TryAgainOnClick()
    {
        // Load the StartScene when the "Try Again" button is clicked
        SceneManager.LoadScene("StartScene");
    }
}
