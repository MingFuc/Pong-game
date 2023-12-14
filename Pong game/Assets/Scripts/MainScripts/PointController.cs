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
    public bool continueSpawn = false;
    public int roundToWin = 3;

    // Start is called before the first frame update
    void Start()
    {
        destroyOutOfBoundScript = GetComponent<DestroyOutOfBound>();
        StartCoroutine(SpawnBallAfter3Second());

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
        if (p1Point == roundToWin)
        {
            Debug.Log("Player 1 win");
        }
        if (p2Point == roundToWin)
        {
            Debug.Log("Player 2 win");
        }
        if (continueSpawn == true)
        {
            StartCoroutine(SpawnBallAfter3Second());
            continueSpawn = false;
        }
    }
    public void SpawnBall()
    {
        if (!(p1Point == roundToWin || p2Point == roundToWin))
        {
            Instantiate(ball);
        }
    }
    public IEnumerator SpawnBallAfter3Second()
    {
        yield return new WaitForSeconds(3);
        SpawnBall();
    }
}
