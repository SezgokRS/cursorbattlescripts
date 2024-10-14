using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheControllerScript : MonoBehaviour
{
    public int playerScore;
    public int gameScore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameScore = playerScore * 10;    
    }
}
