using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 20;
    private float flipSpeed = 1;
    private float rotateAngle = 1;
    private float bound = 8.5f;
    private AudioSource audioSource;
    private PointController pointControllerScript;

    public AudioClip collideSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pointControllerScript = GameObject.Find("Game Manager").GetComponent<PointController>();
    }
    void Update()
    {
        if (pointControllerScript.isGameOver == false)
        {
            MoveUpOrDown();
            Flip();
        }
    }
    void MoveUpOrDown()
    {
        if (gameObject.transform.position.y > bound)
        {
            gameObject.transform.position = (new Vector2(gameObject.transform.position.x, bound));
        }
        if (gameObject.transform.position.y < -bound)
        {
            gameObject.transform.position = (new Vector2(gameObject.transform.position.x, -bound));
        }

        if (gameObject.CompareTag("Player 1"))
        {
            if (Input.GetKey(KeyCode.W))
            {

                gameObject.transform.Translate(new Vector2(0, 1) * moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.Translate(new Vector2(0, 1) * -moveSpeed * Time.deltaTime, Space.World);
            }
        }
        if (gameObject.CompareTag("Player 2"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {

                gameObject.transform.Translate(new Vector2(0, 1) * moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.Translate(new Vector2(0, 1) * -moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
    void Flip()
    {
        if (gameObject.CompareTag("Player 1"))
        {
            if (Input.GetKey(KeyCode.D))
            {

                gameObject.transform.Rotate(new Vector3(0, 0, 1) * flipSpeed * Time.deltaTime, -rotateAngle);
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Rotate(new Vector3(0, 0, 1) * flipSpeed * Time.deltaTime, rotateAngle);
            }
        }
        if (gameObject.CompareTag("Player 2"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {

                gameObject.transform.Rotate(new Vector3(0, 0, 1) * flipSpeed * Time.deltaTime, -rotateAngle);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Rotate(new Vector3(0, 0, 1) * flipSpeed * Time.deltaTime, rotateAngle);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //Debug.Log("sound on");
            audioSource.PlayOneShot(collideSound, 1f);
        }
    }
    
}
