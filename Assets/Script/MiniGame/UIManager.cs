using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;//���ھ� �ؽ�Ʈ�� ����ŸƮ �ؽ�Ʈ�� �����´�.
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI CountDownText;
    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)//�ؽ�Ʈ�� ������
        {
            Debug.LogError("����ŸƮ�ؽ�Ʈ�� ���پ�");
        }

        if (scoreText == null)//������
        {
            Debug.LogError("���ھ��ؽ�Ʈ�� ���پ�");
        }
        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);//�̰� �۵���Ű�� �ؽ�Ʈ�� ���δ�.
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();//���ھ ��Ʈ������ ������ ����Ѵ�.
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
