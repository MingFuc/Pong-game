using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public int p1Point = 0;
    public int p2Point = 0;
    public DestroyOutOfBound destroyOutOfBoundScript;
    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        destroyOutOfBoundScript = GetComponent<DestroyOutOfBound>();
        SpawnBall();

    }

    // Update is called once per frame
    void Update()
    {
        p1Text.text = p1Point.ToString();
        p2Text.text = p2Point.ToString();
        GameManager();
    }
    void GameManager()
    {
        if (p1Point == 3)
        {
            Debug.Log("Player 1 win");
        }
        if (p2Point == 3)
        {
            Debug.Log("Player 2 win");
        }
    }
    public void SpawnBall()
    {
        if (!(p1Point == 3 || p2Point == 3))
        {
            Instantiate(ball);
        }
    }
}
