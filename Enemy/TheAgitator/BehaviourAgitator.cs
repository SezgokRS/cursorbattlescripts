using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum aStates
{
    INTRO,
    DEFAULT,
    DEATH
}

public class BehaviourAgitator : MonoBehaviour
{
    public int health;
    public aStates aState;
    GameObject[] collisionIgnorer;
    GameObject theController;
    TheControllerScript ctrlScr;
    // Start is called before the first frame update
    void Start()
    {
        aState = aStates.INTRO;
        theController = GameObject.FindGameObjectWithTag("GameController");
        ctrlScr = theController.GetComponent<TheControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        collisionIgnorer = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var obj in collisionIgnorer)
        {
            Physics2D.IgnoreCollision(obj.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerLaser")
        {
            ctrlScr.playerScore += 2;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            if (health > 0)
            {
                health -= 1;
            }
            else
            {
                Destroy(gameObject);
                ctrlScr.playerScore += 2;
            }
            Destroy(collision.gameObject);
        }
    }
}
