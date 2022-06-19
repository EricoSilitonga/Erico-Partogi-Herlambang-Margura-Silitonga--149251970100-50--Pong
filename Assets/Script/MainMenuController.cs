using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject secret;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void CreditGame()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OpenSecret()
    {
        secret.SetActive(true);
    }
}
