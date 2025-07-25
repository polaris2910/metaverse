using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    public UIManager UIManager//외부 접근 가능하게 해줌
    {
        get { return uiManager; }
    }
    static GameManager gameManager;


    public static GameManager Instance { get { return gameManager; } }
    private int currentScore = 0;
    private int bestScore = 0;

    private void Awake()
    {

        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();//씬에서 UIManager를 찾아서 참조함
        uiManager = FindObjectOfType<UIManager>();

        uiManager.StartCountdown(3);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();//리스타트 출력
    }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("LastMiniGameScore", 0);
        uiManager.UpdateScore(0);//시작하면 점수 계산
    }
    public void RestartGame()
    {
        PlayerPrefs.SetInt("LastMiniGameScore", bestScore); // 점수 저장
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
        }

        UIManager.UpdateScore(currentScore);

        Debug.Log("Score: " + currentScore);
    }

}


