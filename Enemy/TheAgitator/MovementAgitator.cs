using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Fixed speed with random changes in movement direction. No rotation necessary since the aggitator seems to shoot only forward*/

public class MovementAgitator : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] BehaviourAgitator behaviourScr;
    float xSpeed;
    float ySpeed;
    float myTime;
    void Start()
    {
        myTime = Time.time;
        xSpeed = UnityEngine.Random.Range(2, -2) * speed;
        ySpeed = UnityEngine.Random.Range(2, -2) * speed;
    }

    void Update()
    {
        if (xSpeed == 0)
        {
            xSpeed += 1;
        }
        if (ySpeed == 0)
        {
            ySpeed += 1;
        }
        switch (behaviourScr.aState) {
            case aStates.INTRO:
                if(gameObject.transform.localPosition.x > 5.5f)
                {
                    transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    behaviourScr.aState = aStates.DEFAULT;
                }
                break;

            case aStates.DEFAULT:
                if (Time.time - myTime <= 4)
                {
                    transform.position += new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
                    if (transform.localPosition.x >= 8 || transform.localPosition.x <= -3)
                    {
                        xSpeed = -xSpeed;
                    }
                    if (transform.localPosition.y >= 4 || transform.localPosition.y <= -4)
                    {
                        ySpeed = -ySpeed;
                    }
                }
                else
                {
                    xSpeed = UnityEngine.Random.Range(1, -1) * speed;
                    ySpeed = UnityEngine.Random.Range(1, -1) * speed;
                    myTime = Time.time;
                }
                break;
        }
    }
}


