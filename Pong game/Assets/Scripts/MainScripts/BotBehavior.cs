using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BotBehavior : MonoBehaviour
{
    private PointController pointControllerScript;
    private float speed = 15;
    private float bound = 8.5f;
    private AudioSource auSource;

    public AudioClip collideClip;
    public static BotBehavior instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pointControllerScript = GameObject.Find("Game Manager").GetComponent<PointController>();
        auSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        PreventFromGoOutBound();
    }
    public void ChasingBall(float yPos)
    {
        //Debug.Log("Chasing ball");
        if ( pointControllerScript.isBallSpawning == true)
        {
            float botYPos = transform.position.y;
            transform.Translate( new Vector2(0, yPos - botYPos).normalized * speed * Time.deltaTime);
        }
    }
    void PreventFromGoOutBound()
    {
        if (gameObject.transform.position.y > bound)
        {
            gameObject.transform.position = (new Vector2(gameObject.transform.position.x, bound));
        }
        if (gameObject.transform.position.y < -bound)
        {
            gameObject.transform.position = (new Vector2(gameObject.transform.position.x, -bound));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            auSource.PlayOneShot(collideClip, 1f);
        }
    }
}
