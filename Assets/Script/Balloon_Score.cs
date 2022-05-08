using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balloon_Score : MonoBehaviour
{
    int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    
    public void AddScore()
    {
        score++;

        scoreText.text = score.ToString();
    }

    
}
