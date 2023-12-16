using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float xBound = 24;
    private float yBound = 14;
    private PointController pointControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        pointControllerScript = GameObject.Find("Game Manager").GetComponent<PointController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xBound || transform.position.y > yBound)
        {
            pointControllerScript.p1Point++; //increase point
            pointControllerScript.continueSpawn = true;
            Destroy(gameObject);
            pointControllerScript.isBallSpawning = false;
        }
        if (transform.position.x < -xBound || transform.position.y < -yBound)
        {
            pointControllerScript.p2Point++;
            pointControllerScript.continueSpawn = true;
            Destroy(gameObject);
            pointControllerScript.isBallSpawning = false;
        }

    }
}
