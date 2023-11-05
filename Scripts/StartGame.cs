using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartEasyGameOnClick()
    {
        // Load the main game scene
        SceneManager.LoadScene("SampleScene");
    }

    public void StartMediumGameOnClick()
    {
        // Load the main game scene
        SceneManager.LoadScene("MediumScene");
    }

    public void StartHardGameOnClick()
    {
        // Load the main game scene
        SceneManager.LoadScene("HardScene");
    }
}
