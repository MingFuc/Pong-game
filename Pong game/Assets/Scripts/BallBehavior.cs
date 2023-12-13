using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        BallFlyAtStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BallFlyAtStart()
    {
        ballRb.AddForce(new Vector2(1,0) * speed, ForceMode2D.Impulse); //ball will fly to left or right
        
    }
}
