using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("FirstScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("hit by a bullet");
            SceneManager.LoadScene("FirstScene");
        }
    }
}
