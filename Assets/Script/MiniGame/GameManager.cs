using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    UIManager uiManager;
    public UIManager UIManager//�ܺ� ���� �����ϰ� ����
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
        uiManager = FindObjectOfType<UIManager>();//������ UIManager�� ã�Ƽ� ������
        uiManager = FindObjectOfType<UIManager>();

        uiManager.StartCountdown(3);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();//����ŸƮ ���
    }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("LastMiniGameScore", 0);
        uiManager.UpdateScore(0);//�����ϸ� ���� ���
    }
    public void RestartGame()
    {
        PlayerPrefs.SetInt("LastMiniGameScore", bestScore); // ���� ����
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


