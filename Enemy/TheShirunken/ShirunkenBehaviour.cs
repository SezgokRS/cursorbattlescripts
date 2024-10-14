using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum shirunkenStates
{
    INTRO,
    DEFAULT,
    DEATH
}
public class ShirunkenBehaviour : MonoBehaviour
{
    public shirunkenStates sState;
    [SerializeField] float health = 20;
    GameObject[] collisionShirunken;
    void Start()
    {
        sState = shirunkenStates.INTRO;
    }

    // Update is called once per frame
    void Update()
    {
        collisionShirunken = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var obj in collisionShirunken)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (health > 0)
            {
                health -= 1;
            }
            else
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
