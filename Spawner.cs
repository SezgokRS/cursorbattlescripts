using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject theSidekick;
    [SerializeField] GameObject theShirunken;
    [SerializeField] GameObject theAgitator;
    [SerializeField] float waitToSpawnSidekick;
    [SerializeField] float waitToSpawnShirunken;
    [SerializeField] float waitToSpawnAgitator;
    [SerializeField] float increaseTimeBy;
    [SerializeField] int scoreLimit = 5;
    GameObject controller;

    float timeSpentForSidekick = 0;
    float timeSpentForShirunken = 0;
    float timeSpentForAgitator = 0;
    // Start is called before the first frame update
    void Start()
    {
        //timeSpent = Time.time;
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeSpentForSidekick >= waitToSpawnSidekick)
        {
            Instantiate(theSidekick, new Vector3(10f, Random.Range(4, -4), 0), transform.rotation);
            timeSpentForSidekick = Time.time;
        }
        if (Time.time - timeSpentForShirunken >= waitToSpawnShirunken)
        {
            Instantiate(theShirunken, new Vector3(10f, 5.5f, 0), transform.rotation);
            timeSpentForShirunken = Time.time;
        }
        if (Time.time - timeSpentForAgitator >= waitToSpawnAgitator)
        {
            Instantiate(theAgitator, new Vector3(10f, Random.Range(4, -4), 0), transform.rotation);
            timeSpentForAgitator = Time.time;
            if (controller.GetComponent<TheControllerScript>().playerScore >= scoreLimit)
            {
                waitToSpawnSidekick /= increaseTimeBy;
                waitToSpawnShirunken /= increaseTimeBy;
                waitToSpawnAgitator /= increaseTimeBy;
                scoreLimit *= 2;
            }
        }
    }
}
