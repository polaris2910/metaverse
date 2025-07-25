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
        if (collision.CompareTag("BackGround"))//��׶���� �λI����
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;//�ڽ� �ݶ��̴� ������ x������ ����
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount; //�׶��� 5���ϱ� 5���ؼ� ����..���� ������ ������ ������ Ȯ�强 �����ϱ�? �´°Ű���
            collision.transform.position = pos;//�ƹ�ư �ٲ� �������� �ٽ� �Է����ش�.
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
    