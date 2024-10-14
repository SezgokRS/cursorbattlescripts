using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementShirunken : MonoBehaviour
{
    float my_time;
    [SerializeField] float spinFor = 4;
    float maxXWest, maxY, maxXEast;
    float movementToX, movementToY;
    [SerializeField] float ySpeedRanger;
    [SerializeField] float xSpeedRanger;
    [SerializeField] float spinAmountRange;
    public bool movementEnded = false;
    [SerializeField] ShirunkenBehaviour shirunkenBehaviour;
    void Start()
    {
        my_time = Time.time + 4;
        movementToX = UnityEngine.Random.Range(xSpeedRanger, -xSpeedRanger);
        movementToY = UnityEngine.Random.Range(ySpeedRanger, -ySpeedRanger);
        maxXWest = -3f;
        maxXEast = 8f;
        maxY = 4f;
    }

    void Update()
    {
        switch (shirunkenBehaviour.sState)
        {
       
            
                case shirunkenStates.INTRO:
                    if(gameObject.transform.localPosition.x > 7 || gameObject.transform.localPosition.y > 3.5)
                    {
                        transform.position += new Vector3(-2 * Time.deltaTime, -2 * Time.deltaTime, 0);
                    }

                    if(gameObject.transform.localPosition.x <= 7 && gameObject.transform.localPosition.y <= 3.5f)
                    {
                        shirunkenBehaviour.sState = shirunkenStates.DEFAULT;
                    }
                    break;
                case shirunkenStates.DEFAULT:
                if (my_time <= Time.time)
                {
                    transform.position += new Vector3(movementToX * Time.deltaTime, movementToY * Time.deltaTime, 0);
                    transform.Rotate(0, 0, spinAmountRange * Time.deltaTime);
                    if (Time.time - my_time >= spinFor)
                    {
                        my_time = Time.time + 4;
                        movementToX = UnityEngine.Random.Range(xSpeedRanger, -xSpeedRanger);
                        movementToY = UnityEngine.Random.Range(ySpeedRanger, -ySpeedRanger);
                        movementEnded = true;
                    }
                    if (transform.localPosition.x >= maxXEast || transform.localPosition.x <= maxXWest)
                    {
                        movementToX = -movementToX;
                    }
                    if (transform.localPosition.y >= maxY || transform.localPosition.y <= -maxY)
                    {
                        movementToY = -movementToY;
                    }
                   
            }
                break;
        }
    }
}

