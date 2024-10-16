using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum bStates
{
    INACTIVE,
    ENTER,
    ACTIVE,
    LEAVE,
    DISABLED
}

public class BehemothBehaviour : MonoBehaviour
{
    public bStates bState;
    public int behemothHealth = 20;
    GameObject[] enemiesCollision;
    GameObject theController;
    TheControllerScript ctrlScr;
    public float requiredPoints = 5;
    GameObject weapon;
    [SerializeField] GameObject lookOutLaser;
    GameObject laserOnScene;
    bool isLaserOn = false;
    WeaponBehemoth wpnScr;
    // Start is called before the first frame update
    void Start()
    {
        bState = bStates.INACTIVE;
        theController = GameObject.FindGameObjectWithTag("GameController");
        ctrlScr = theController.GetComponent<TheControllerScript>();
        weapon = transform.GetChild(0).gameObject;
        wpnScr = weapon.GetComponent<WeaponBehemoth>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCollision = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemiesCollision)
        {
            Physics2D.IgnoreCollision(enemy.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        switch(bState) {
            case bStates.ENTER:
                if(gameObject.transform.localPosition.x > 7.7f)
                {
                    transform.Translate(-4 * Time.deltaTime, 0, 0);
                    wpnScr.timerForShooting = Time.time;
                }
                else
                {
                    bState = bStates.ACTIVE;
                }
                break;
            case bStates.ACTIVE:
                if (!isLaserOn)
                {
                    laserOnScene = Instantiate(lookOutLaser, new Vector3(-6.0f, weapon.transform.localPosition.y, 0), transform.rotation);
                    isLaserOn = true;
                }
                laserOnScene.transform.position = new Vector3(-6.0f, weapon.transform.localPosition.y, 0);
                break;
            case bStates.LEAVE:
                if (laserOnScene) { Destroy(laserOnScene.gameObject); }
                isLaserOn = false;
                if(gameObject.transform.localPosition.x < 11f)
                {
                    transform.Translate(4 * Time.deltaTime, 0, 0);
                }
                else
                {
                    bState = bStates.INACTIVE;
                }
                break;
            case bStates.INACTIVE:
                if(ctrlScr.playerScore >= requiredPoints)
                {
                    requiredPoints *= 2;
                    bState = bStates.ENTER;
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if(behemothHealth > 1) { 
                Destroy(collision.gameObject);
                behemothHealth -= 1;
            }
            else
            {
                Destroy(collision.gameObject);
                bState = bStates.LEAVE;
            }
        }
    }
}


