using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TheControllerScript : MonoBehaviour
{
    public int playerScore;
    public int gameScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    GameObject theCursor;
    Controller cursorCtrl;
    public bool gameIsStopped = false;

    void Start()
    {
        theCursor = GameObject.FindGameObjectWithTag("TheCursor");
        cursorCtrl = theCursor.GetComponent<Controller>();
        scoreText.text = "SCORE: 0";
        healthText.text = "HEALTH: " + cursorCtrl.playerHealth; 

    }

    // Update is called once per frame
    void Update()
    {
        gameScore = playerScore * 10;
        scoreText.text = "SCORE: " + playerScore;
        healthText.text = "HEALTH: " + cursorCtrl.playerHealth;
    }
}
