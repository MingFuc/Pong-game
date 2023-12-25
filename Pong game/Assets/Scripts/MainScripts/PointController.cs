using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public static PointController instance;
    public int p1Point = 0;
    public int p2Point = 0;
    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;
    public GameObject ball;
    public bool continueSpawn = false;
    public int roundToWin;
    public GameObject winLeft;
    public GameObject winRight;
    public GameObject restartButton;
    public bool isGameOver = false;
    public bool isBallSpawning = false;
    public bool onePlayer;

    public GameObject pBot;
    public GameObject p2;
    private void Awake()
    {
        roundToWin = RefRoundSelec.instance.refDefaultRound;
        instance = this;

        onePlayer = PlayerSelect.instance.choose1Player;
        if (onePlayer == true)
        {
            pBot.SetActive(true);
        }
        else
        {
            p2.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBallAfter1Second());
    }

    // Update is called once per frame
    void Update()
    {
        //tracking point
        p1Text.text = p1Point.ToString();
        p2Text.text = p2Point.ToString();
        //
        GameManager();
    }
    void GameManager()
    {
        if (p1Point == roundToWin)
        {
            //Debug.Log("Player 1 win");
            isGameOver = true;
            winLeft.SetActive(true);
            restartButton.SetActive(true);
        }
        if (p2Point == roundToWin)
        {
            //Debug.Log("Player 2 win");
            isGameOver = true;
            winRight.SetActive(true);
            restartButton.SetActive(true);
        }
        if (continueSpawn == true)
        {
            StartCoroutine(SpawnBallAfter1Second());
            continueSpawn = false;
        }
    }
    public void SpawnBall()
    {
        if (!(p1Point == roundToWin || p2Point == roundToWin))
        {
            Vector2 spawnPosition = new Vector2(0, Random.Range(-7, 7));
            Instantiate(ball, spawnPosition, transform.rotation);
            isBallSpawning = true;
        }
    }
    public IEnumerator SpawnBallAfter1Second()
    {
        yield return new WaitForSeconds(1);
        SpawnBall();
    }
}
