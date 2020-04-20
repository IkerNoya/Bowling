using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void onClickA()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnClickB()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnClickC()
    {
        SceneManager.LoadScene("Menu");
    }
}
