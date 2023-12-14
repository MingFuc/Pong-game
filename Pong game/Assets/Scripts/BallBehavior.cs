using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private PhysicsMaterial2D pM;
    private float speed = 10;

    public int colliderCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        pM = ballRb.sharedMaterial;
        pM.bounciness = 1.1f;
        BallFlyAtStart();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FasterMoving();
    }
    void BallFlyAtStart()
    {
        ballRb.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse); //ball will fly to left or right

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player 1") || collision.gameObject.CompareTag("Player 2"))
        {
            colliderCount++;
        }
    }

    public void FasterMoving()
    {
        switch (colliderCount)
        {
            case 3:
                pM.bounciness = 1.15f;
                break;
            case 6:
                pM.bounciness = 1.2f;
                break;
        }
    }
}
