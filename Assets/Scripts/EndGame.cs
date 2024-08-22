using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
