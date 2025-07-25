using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;//스코어 텍스트와 리스타트 텍스트를 가져온다.
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI CountDownText;
    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)//텍스트가 없으면
        {
            Debug.LogError("리스타트텍스트가 없다아");
        }

        if (scoreText == null)//없으면
        {
            Debug.LogError("스코어텍스트가 없다아");
        }
        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);//이걸 작동시키면 텍스트가 보인다.
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();//스코어를 스트링으로 가져와 출력한다.
    }

    public void CountDown(int Count)
    {
        CountDownText.text = Count.ToString();
    }
    public void StartCountdown(int startTime)
    {
        Time.timeScale = 0f;
        CountDownText.gameObject.SetActive(true);
        StartCoroutine(CountdownRoutine(startTime));
        
       
    }
    private IEnumerator CountdownRoutine(int time)
    {
        while (time > 0)
        {
            CountDown(time);
            yield return new WaitForSecondsRealtime(1f);
            time--;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        CountDownText.gameObject.SetActive(false);
        Time.timeScale = 1f; 

    }

}
