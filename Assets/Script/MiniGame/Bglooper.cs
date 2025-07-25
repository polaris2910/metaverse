using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bglooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public int numBgCount = 5;
    public Vector3 obstacleLastPosition = Vector3.zero;
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
        public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);
        if (collision.CompareTag("BackGround"))//백그라운드랑 부팇히면
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;//박스 콜라이더 정보로 x사이즈 측정
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount; //그라운드 5개니까 5곱해서 진행..굳이 변수로 지정한 이유는 확장성 때문일까? 맞는거같네
            collision.transform.position = pos;//아무튼 바뀐 포지션을 다시 입력해준다.
            return;
        }



        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}

    // Update is called once per frame
    