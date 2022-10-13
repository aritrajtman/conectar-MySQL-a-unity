using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Text playerDisplay;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.usuario;
        }
    }

   public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToiniciarsesion()
    {
        SceneManager.LoadScene(2);
    }
}
