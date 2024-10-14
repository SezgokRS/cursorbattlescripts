using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform[] shootingPoints;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeBetweenBullets = .2f;
    private float timeOfLastShot;

    void Update()
    {
        if (Keyboard.current.rightShiftKey.isPressed)
        {
            if (Time.time - timeOfLastShot >= timeBetweenBullets)
            {
                Instantiate(bulletPrefab, shootingPoints[0].position, transform.rotation);
                Instantiate(bulletPrefab, shootingPoints[1].position, transform.rotation);

                timeOfLastShot = Time.time;
            }
        }


    }
}
