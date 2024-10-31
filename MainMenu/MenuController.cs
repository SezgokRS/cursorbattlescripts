using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject[] buttons;
    [SerializeField] MainMenu menuScr;
    public float menuSpeedMultiplier;
    public float maxMenuSpeed;
    float speed;
    bool startAnimEnded;

    void Start()
    {
        startAnimEnded = false;
    }

    void Update()
    {
        if (menuScr.startGame)
        {
            RectTransform btCnvsPlacement = buttons[0].GetComponent<RectTransform>();
            foreach (var button in buttons)
            {
                
                if (btCnvsPlacement.localPosition.y > -575 && !startAnimEnded)
                {
                    if (speed < maxMenuSpeed)
                    {
                        speed += menuSpeedMultiplier * Time.deltaTime;
                    }
                    button.transform.localPosition += new Vector3(0, -speed, 0);
                }
                else
                {
                    startAnimEnded = true;
                    SceneManager.LoadSceneAsync(1);
                }
            }
        }
    }
}
