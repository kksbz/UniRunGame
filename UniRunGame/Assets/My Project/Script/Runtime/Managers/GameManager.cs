using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;
    private const string UI_OBJS = "UiObjs";
    private const string SCORE_TEXT_OBJ = "ScoreText";
    private const string GAME_OVER_UI_OBJ = "GameOverUi";
    public bool isGameOver = false;
    private GameObject scoreTextObj = default;
    private GameObject gameOverUi = default;
    private int score = default;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //Init
            isGameOver = false;
            GameObject uiObjs_ = GFunc.GetRootObj(UI_OBJS);
            scoreTextObj = uiObjs_.FindChildObj(SCORE_TEXT_OBJ);
            gameOverUi = uiObjs_.FindChildObj(GAME_OVER_UI_OBJ);

            score = 0;
        } // if : 게임 매니저가 존재하지 않는 경우 변수에 할당 및 초기화
        else
        {
            GFunc.LogWarning("[System] GameManager : Duplicated object warning");
            Destroy(gameObject);
        }
    } //Awake

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveScene().name);
        }
    } //Update

    //점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        if (isGameOver == true) { return; }
        //if : 게임이 진행중이라면
        score += newScore;
        scoreTextObj.SetTmpText($"Score : {score}");
    } //AddScore

    //플레이어 사망 시 게임오버를 실행하는 메서드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    } //OnPlayerDead
}
