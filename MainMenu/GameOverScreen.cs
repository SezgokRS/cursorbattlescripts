using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void Setup(int playerScore)
    {
        gameObject.SetActive(true);
        scoreText.text = "SCORE: " + playerScore.ToString();
    }
}
