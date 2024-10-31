using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    [SerializeField] float verticalMoveSpeed = .5f;
    [SerializeField] float horizontalMoveSpeed = .5f;
    float moveAmount;
    [SerializeField] Controller controller;
    [SerializeField] float introTime;
    //this part is for bounce back when enemy is hit
    [SerializeField] float inviEffectTime = 1;
    public float inviEffectCounter;
    SpriteRenderer sprite;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin _ctmp;
    [SerializeField] public float shakeIntensity;
    float currentShakeInt;
    public float shakeMultiplier;

    void Start()
    {
        controller = GetComponent<Controller>();
        introTime = Time.time;
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void StartShake()
    {
        _ctmp = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _ctmp.m_AmplitudeGain = shakeIntensity;
    }
    void StopShake()
    {
        _ctmp = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _ctmp.m_AmplitudeGain = 0.0f;
    }

    IEnumerator Shake()
    {
        transform.localPosition += new Vector3(0, currentShakeInt, 0);
        yield return new WaitForSeconds(0.01f);
        transform.localPosition += new Vector3(0, -currentShakeInt, 0);
        yield return new WaitForSeconds(0.01f);
        currentShakeInt -= shakeMultiplier * Time.deltaTime;
    }

    void Update()
    {
        /*STATE MACHINE*/
        switch (controller.playerState) {
            case states.INTRO:
                StopShake();
                currentShakeInt = shakeIntensity;
                transform.Translate(horizontalMoveSpeed / 1.5f * Time.deltaTime, 0, 0);
                if (gameObject.transform.localPosition.x >= -7.5f)
                {
                    controller.playerState = states.DEFAULT;
                }
                break;

            case states.DEFAULT:
                StopShake();
                currentShakeInt = shakeIntensity;
                sprite.color = new Color(1, 1, 1, 1);
                moveAmount = Input.GetAxisRaw("Vertical") * Time.deltaTime;
                transform.Translate(0, verticalMoveSpeed * moveAmount, 0);

                moveAmount = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
                transform.Translate((horizontalMoveSpeed * moveAmount), 0, 0);

                if (transform.localPosition.x < -8.1f)
                {
                    transform.position = new Vector3(-8.1f, transform.localPosition.y, 0);
                }
                if (transform.localPosition.x > 8.1f)
                {
                    transform.position = new Vector3(8.1f, transform.localPosition.y, 0);
                }
                if (transform.localPosition.y > 4.1f)
                {
                    transform.position = new Vector3(transform.localPosition.x, 4.1f, 0);
                }
                if (transform.localPosition.y < -4.15f)
                {
                    transform.position = new Vector3(transform.localPosition.x, -4.15f, 0);
                }
                break;
            case states.INVINCIBLE:
                if (currentShakeInt > 0)
                {
                    StartCoroutine(Shake());
                }
                //StartShake();
                sprite.color = new Color(1, 1, 1, 0.3f);
                moveAmount = Input.GetAxisRaw("Vertical") * Time.deltaTime;
                transform.Translate(0, verticalMoveSpeed * moveAmount, 0);

                moveAmount = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
                transform.Translate((horizontalMoveSpeed * moveAmount), 0, 0);

                if (transform.localPosition.x < -8.1f)
                {
                    transform.position = new Vector3(-8.1f, transform.localPosition.y, 0);
                }
                if (transform.localPosition.x > 8.1f)
                {
                    transform.position = new Vector3(8.1f, transform.localPosition.y, 0);
                }
                if (transform.localPosition.y > 4.1f)
                {
                    transform.position = new Vector3(transform.localPosition.x, 4.1f, 0);
                }
                if (transform.localPosition.y < -4.15f)
                {
                    transform.position = new Vector3(transform.localPosition.x, -4.15f, 0);
                }
                break;
            case states.DEAD:
                gameObject.transform.Translate(0, -verticalMoveSpeed * Time.deltaTime, 0);
                break;
            /*STATE AMCHINE END*/
                
        }
    }
}



