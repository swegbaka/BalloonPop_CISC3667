using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject name;
    public string Username;
    
    void Update()
    {
        Username = name.GetComponent<InputField> ().text;

    }
    
    
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("username", Username);
        SceneManager.LoadScene("Game");
    }
}
