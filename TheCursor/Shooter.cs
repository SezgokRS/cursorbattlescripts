using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform[] shootingPoints;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeBetweenBullets = .2f;
    private float timeOfLastShot;
    bool laserActive = false;
    [SerializeField] GameObject playerLaser;
    GameObject activeLaser;

    public Image laserBar;
    public float laserTime, maxLaserTime, laserFillAmount;
    void Start()
    {
        laserBar.fillAmount = 0;    
    }
    void Update()
    {
        laserBar.fillAmount = laserTime / maxLaserTime;
        if (activeLaser == null)
        {
            if (laserTime < maxLaserTime)
            {
                laserTime += laserFillAmount * Time.deltaTime;
            }
            if (Keyboard.current.rightShiftKey.isPressed || Keyboard.current.leftShiftKey.isPressed)
            {
                if (Time.time - timeOfLastShot >= timeBetweenBullets)
                {
                    Instantiate(bulletPrefab, shootingPoints[0].position, transform.rotation);
                    Instantiate(bulletPrefab, shootingPoints[1].position, transform.rotation);

                    timeOfLastShot = Time.time;
                }
            }
        }
        if (Keyboard.current.eKey.isPressed && activeLaser == null && laserTime >= maxLaserTime)
        {
            laserBar.fillAmount = laserTime / maxLaserTime;
            laserTime = 0;
            laserActive = true;
            activeLaser = Instantiate(playerLaser, new Vector3(transform.localPosition.x + 1.2f, transform.localPosition.y, 0), transform.rotation);
            activeLaser.transform.parent = transform;
        }
        /*if(activeLaser != null)
        {
            laserActive = false;
            Destroy(activeLaser);
        }*/

    }
}
