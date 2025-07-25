using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    protected Rigidbody2D _rigidbody;//리지드바디 지정
    [SerializeField] private SpriteRenderer characterRenderer;//캐릭터 렌더링


    protected Vector2 movementDirection = Vector2.zero;//벡터값 0지정
    protected MoveManager moveManager;

    public Vector2 MovementDirection { get { return movementDirection; } }//이동 함수 지정


    protected Vector2 lookDirection = Vector2.zero;//방향 지정


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();//리지드바디 가져오기
        moveManager = GetComponent<MoveManager>();
    }
    protected virtual void Update()
    {
        HandleAction();
        Rotate(movementDirection);
        Movment(movementDirection);
    }
    protected virtual void HandleAction()
    {
        //미니게임cs에서 오버라이드처리하기.
    }
    private void Movment(Vector2 direction)
    {
        direction = direction * 5; // 이동 속도

        // 실제 물리 이동
        _rigidbody.velocity = direction;
        moveManager.Move(movementDirection);
    }

    private void Rotate(Vector2 direction)
    {
        // 방향이 없을 경우에는 회전 처리하지 않음
        if (direction == Vector2.zero) return;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// 방향 벡터를 각도로 변환
        bool isLeft = Mathf.Abs(rotZ) > 90f; // 회전 각도에 따라 판단

        characterRenderer.flipX = isLeft;


    }


}



