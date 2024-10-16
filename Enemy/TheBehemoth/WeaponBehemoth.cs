using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum weaponStates
{
    UPWARDS,
    DOWNWARDS,
    SHOOTING
}

public class WeaponBehemoth : MonoBehaviour
{
    [SerializeField] GameObject behemothBullet;
    GameObject bulletOnScreen;
    GameObject behemoth;
    BehemothBehaviour bBehaviour;
    [SerializeField] float weaponSpeed;
    public weaponStates wState;
    weaponStates oldState;
    public float timerForShooting;
    float timerIdk;
    float shootTime;
    bool bulletActive = true;
    void Start()
    {
        behemoth = gameObject.transform.parent.gameObject;
        bBehaviour = behemoth.GetComponent<BehemothBehaviour>();
        timerForShooting = Time.time;
        shootTime = Random.Range(4, 9);
        if (gameObject.transform.localPosition.y > 0)
        {
            wState = weaponStates.DOWNWARDS;
        }
        else
        {
            oldState = wState;
            wState = weaponStates.UPWARDS;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bBehaviour.bState == bStates.ACTIVE)
        {
            if (Time.time - timerForShooting < shootTime)
            {
                if (transform.localPosition.y > 3)
                {
                    wState = weaponStates.DOWNWARDS;
                }
                if (transform.localPosition.y < -3)
                {
                    wState = weaponStates.UPWARDS;
                }
            }
            else
            {
                timerIdk = Time.time;
                timerForShooting = Time.time;
                wState = weaponStates.SHOOTING;
            }
        
            switch (wState)
            {
                case weaponStates.DOWNWARDS:
                    gameObject.transform.Translate(0, -weaponSpeed * Time.deltaTime, 0);
                    break;
                case weaponStates.UPWARDS:
                    gameObject.transform.Translate(0, weaponSpeed * Time.deltaTime, 0);
                    break;
                case weaponStates.SHOOTING:
                    
                    if (Time.time - timerIdk < 2)
                    {
                        Debug.Log("SHOOTING!!!!!");
                        if (bulletActive)
                        {
                            bulletOnScreen = Instantiate(behemothBullet, new Vector3(transform.localPosition.x - 1, transform.localPosition.y, 0), transform.rotation);
                            bulletActive = false;
                        }
                    }
                    if (Time.time - timerIdk > 2)
                    {
                        Destroy(bulletOnScreen.gameObject);  
                        bulletActive = true;
                        shootTime = Random.Range(4.0f, 9.0f);
                        timerForShooting = Time.time;
                        Debug.Log(shootTime);
                        wState = oldState;
                    }
                    break;
            }
        }
        else
        {
            bBehaviour.behemothHealth = 20;
            if (bulletOnScreen)
            {
                Destroy(bulletOnScreen.gameObject);
            }
            bulletActive = true;
        }
    }
}
