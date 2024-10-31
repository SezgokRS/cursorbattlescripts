using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    GameObject theCursor;
    Controller cursorCtrl;
    [SerializeField] GameObject healthSign;
    GameObject currentHealthSign;
    GameObject healthBar;
    Animator healthAnim;
    [SerializeField] AnimationClip destroyClip;
    [SerializeField] AnimationClip hrtIdleClip;
    float timer;
    int onScreen;
    public float heartXPosition;
    public float spaceBetweenHearts;

    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health Bar");
        theCursor = GameObject.FindGameObjectWithTag("TheCursor");
        cursorCtrl = theCursor.GetComponent<Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cursorCtrl.playerHealth > onScreen)
        {
            currentHealthSign = Instantiate(healthSign);
            healthAnim = currentHealthSign.GetComponent<Animator>();
            currentHealthSign.transform.parent = healthBar.transform;
            onScreen += 1;
            currentHealthSign.transform.localPosition = new Vector3(heartXPosition, healthBar.transform.localPosition.y, 0);
            heartXPosition += spaceBetweenHearts;
            timer = Time.time + destroyClip.length;
        }
        if(cursorCtrl.playerHealth < onScreen)
        {
            onScreen -= 1;
            heartXPosition -= spaceBetweenHearts;
            healthAnim.Play("heartLossAnim");
            
            //Destroy(currentHealthSign);
            currentHealthSign = healthBar.transform.GetChild(cursorCtrl.playerHealth - 1).gameObject;
            healthAnim = currentHealthSign.GetComponent<Animator>();
                   
        }
    }
}
