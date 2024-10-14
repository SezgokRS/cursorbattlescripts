using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShirunken : MonoBehaviour
{
    [SerializeField] public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TheCursor" || collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
