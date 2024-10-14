using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShirunken : MonoBehaviour
{
    [SerializeField] MovementShirunken movementScript;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform[] shootingPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movementScript.movementEnded)
        {
            for(int i = 0; i < shootingPoints.Length; i++)
            {
                GameObject bullet;
                bullet = Instantiate(enemyBullet, shootingPoints[i].position, transform.rotation);
                bullet.transform.Rotate(0, 0, 90 * i);
                movementScript.movementEnded = false;

            }
        }
    }
}
