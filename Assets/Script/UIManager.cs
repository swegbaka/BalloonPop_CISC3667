using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public Text timer;
    public float Temptimer = 60;

    public Text target;
    public float Temptarget;

    public GameObject GameOver;
    public GameObject Congrats;

    void Update()
    {
        Temptimer -= Time.deltaTime;
        timer.text = Temptimer.ToString("0.00");

        if (Temptimer < 0)
        {
            Temptimer = 0;
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if(score >= Temptarget && Temptarget == 10)
        {
            SceneManager.LoadScene("lvl2");
        }

        if (score >= Temptarget && Temptarget == 15)
        {
            SceneManager.LoadScene("lvl3");

        }
        if ((score >= Temptarget && Temptarget == 8))
        {
            Congrats.SetActive(true);
            Time.timeScale = 0;
        }
        if ((score >= Temptarget && Temptarget == 25))
        {
            SceneManager.LoadScene("lvl3_harder");
        }
        if ((score >= Temptarget && Temptarget == 11))
        {
            Congrats.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    
    public void AddScore()
    {
        score++;

        scoreText.text = score.ToString();
    }
}
