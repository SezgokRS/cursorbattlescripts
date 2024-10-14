using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Content;
#endif

public class BehaviourSidekick : MonoBehaviour
{
    [SerializeField] int lives;
    GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controller.GetComponent<TheControllerScript>().playerScore);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (lives <= 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                controller.GetComponent<TheControllerScript>().playerScore += 1;
                Debug.Log(controller.GetComponent<TheControllerScript>().playerScore);
            }
            else
            {
                Destroy(collision.gameObject);
                lives -= 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

}
