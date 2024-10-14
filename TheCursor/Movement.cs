using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    [SerializeField] float verticalMoveSpeed = .5f;
    [SerializeField] float horizontalMoveSpeed = .5f;
    float moveAmount;
    [SerializeField] Controller controller;
    [SerializeField] float introTime;
    
    void Start()
    {
        controller = GetComponent<Controller>();
        introTime = Time.time;
    }
    void Update()
    { 
        /*STATE MACHINE*/
        switch (controller.playerState) {
            case states.INTRO:
                transform.Translate(horizontalMoveSpeed / 1.5f * Time.deltaTime, 0, 0);
                if (gameObject.transform.localPosition.x >= -7.5f)
                {
                    controller.playerState = states.DEFAULT;
                }
                break;

            case states.DEFAULT:
                moveAmount = Input.GetAxisRaw("Vertical") * Time.deltaTime;
                transform.Translate(0, verticalMoveSpeed * moveAmount, 0);

                moveAmount = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
                transform.Translate((horizontalMoveSpeed * moveAmount), 0, 0);

                if (transform.localPosition.x < -8.1f)
                {
                    transform.position = new Vector3(-8.1f, transform.localPosition.y, 0);
                }
                if (transform.localPosition.x > 8.1f)
                {
                    transform.position = new Vector3(8.1f, transform.localPosition.y, 0);
                }
                if (transform.localPosition.y > 4.1f)
                {
                    transform.position = new Vector3(transform.localPosition.x, 4.1f, 0);
                }
                if (transform.localPosition.y < -4.15f)
                {
                    transform.position = new Vector3(transform.localPosition.x, -4.15f, 0);
                }
                break;
            case states.INVINCIBLE:
                Debug.Log("INVINCIBLE STATE");
                break;
            /*STATE AMCHINE END*/
                
        }
    }
}



