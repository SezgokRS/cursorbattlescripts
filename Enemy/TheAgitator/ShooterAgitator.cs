using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAgitator : MonoBehaviour { 
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] Transform[] shootingPoints;
    float myTime;
    
    void Start()
    {
        myTime = Time.time;
    }

    void Update()
    {
        if (Time.time - myTime >= 2)
        {
            foreach (var point in shootingPoints)
            {
                GameObject bullet = Instantiate(enemyBulletPrefab, point.position, transform.rotation);
                BulletShirunken bulletBehaviour = bullet.GetComponent<BulletShirunken>();
                bulletBehaviour.speed = -bulletBehaviour.speed;
                myTime = Time.time;
            }
        }
    }
}
