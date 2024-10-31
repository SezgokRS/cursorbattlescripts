using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum states
{
    INTRO,
    DEFAULT,
    INVINCIBLE,
    DEAD
}

public class Controller : MonoBehaviour
{
    public states playerState;
    [SerializeField] public int playerHealth = 3;
    [SerializeField] float timeForInvi;
    float inviCounter;
    GameObject[] allEnemies;
    Movement mvmScr;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject gameController;
    TheControllerScript ctrScr;
    GameOverScreen gmOverScript;

    void Start()
    {
        inviCounter = Time.time;
        mvmScr = GetComponent<Movement>();
        gmOverScript = gameOverScreen.GetComponent<GameOverScreen>();
        ctrScr = gameController.GetComponent<TheControllerScript>();
    }
    void Update()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(playerState == states.DEFAULT)
        {
            foreach (var enemy in allEnemies)
            {
                Physics2D.IgnoreCollision(enemy.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), false);
            }
            inviCounter = Time.time;
        }
        else if(playerState == states.INVINCIBLE)
        {
            foreach(var enemy in allEnemies)
            {
                Physics2D.IgnoreCollision(enemy.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            }
            if(Time.time - inviCounter > timeForInvi)
            {
                playerState = states.DEFAULT;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (playerState == states.DEFAULT)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                
                if(playerHealth > 1) {
                    playerHealth -= 1;
                    playerState = states.INVINCIBLE;
                    mvmScr.inviEffectCounter = Time.time;
                }
                else
                {
                    gmOverScript.Setup(ctrScr.playerScore);
                    Time.timeScale = 0;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerState == states.DEFAULT)
        {
            if (collision.gameObject.tag == "EnemyBullet")
            {
                if (playerHealth > 1)
                {
                    Destroy(collision.gameObject);
                    playerHealth -= 1;
                    playerState = states.INVINCIBLE;
                }
                else
                {
                    Destroy(collision.gameObject);
                    gmOverScript.Setup(ctrScr.playerScore);
                    Time.timeScale = 0;
                }
            }
        }
        if(playerState == states.DEFAULT || playerState == states.INVINCIBLE)
        {
            if(collision.gameObject.tag == "HealthPickup")
            {
                if(playerHealth <= 6)
                {
                    playerHealth += 1;
                }
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
