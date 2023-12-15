using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float xBound = 24;
    private PointController pointControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        pointControllerScript = GameObject.Find("Game Manager").GetComponent<PointController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xBound )
        {
            pointControllerScript.p1Point++; //increase point
            pointControllerScript.continueSpawn = true;
            Destroy(gameObject);
        }
        if (transform.position.x < -xBound)
        {
            pointControllerScript.p2Point++;
            pointControllerScript.continueSpawn = true;
            Destroy(gameObject);
        }

    }
}
