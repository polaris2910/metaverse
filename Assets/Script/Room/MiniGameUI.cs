using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameUI : MonoBehaviour
{
    public TextMeshProUGUI HighScore;

    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastMiniGameScore", 0); //플레이어 프리펩 가져오기
        Debug.Log(lastScore);


        HighScore.text = lastScore.ToString();
    }
}
