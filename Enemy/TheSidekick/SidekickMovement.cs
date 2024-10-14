using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidekickMovement : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject controller;
    [SerializeField] float speedIncrease = 2;
    [SerializeField] float scoreLimit = 5;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.GetComponent<TheControllerScript>().playerScore >= scoreLimit)
        {
            scoreLimit *= 2;
            speed = speed * speedIncrease;
        }
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
