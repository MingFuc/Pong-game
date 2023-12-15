using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private PhysicsMaterial2D pM;
    private float speed = 15;
    private int[] leftOrRight = {-1, 1};
    private int maxBoundNumberBeforeDeflect = 20;

    public int colliderCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        pM = ballRb.sharedMaterial;
        pM.bounciness = 1.2f;
        BallFlyAtSpawn();
    }
    void FixedUpdate()
    {    
        FasterMoving();
        
    }
    void BallFlyAtSpawn()
    {
        //instantiate direction for AddForce() method
        int leftOrRightIndex = Random.Range(0, leftOrRight.Length);
        Vector2 randomDirection = new Vector2(leftOrRight[leftOrRightIndex], Random.Range(-1f, 1f));
        //
        ballRb.AddForce(randomDirection * speed, ForceMode2D.Impulse); //ball will fly to left or right
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player 1") || collision.gameObject.CompareTag("Player 2"))
        {
            colliderCount++;
        }
    }

    public void FasterMoving() //faster when collide with platform
    {
        switch (colliderCount)
        {
            case 3:
                pM.bounciness = 1.3f;
                break;
            case 6:
                pM.bounciness = 1.4f;
                break;
        }
        //deflect the ball if it bounces too much
        if (colliderCount > maxBoundNumberBeforeDeflect)
        {

            transform.Translate(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed); 

        }
        //
    }

}
