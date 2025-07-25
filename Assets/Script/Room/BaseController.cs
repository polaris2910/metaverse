using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    protected Rigidbody2D _rigidbody;//������ٵ� ����
    [SerializeField] private SpriteRenderer characterRenderer;//ĳ���� ������


    protected Vector2 movementDirection = Vector2.zero;//���Ͱ� 0����
    protected MoveManager moveManager;

    public Vector2 MovementDirection { get { return movementDirection; } }//�̵� �Լ� ����


    protected Vector2 lookDirection = Vector2.zero;//���� ����


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();//������ٵ� ��������
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
        //�̴ϰ���cs���� �������̵�ó���ϱ�.
    }
    private void Movment(Vector2 direction)
    {
        direction = direction * 5; // �̵� �ӵ�

        // ���� ���� �̵�
        _rigidbody.velocity = direction;
        moveManager.Move(movementDirection);
    }

    private void Rotate(Vector2 direction)
    {
        // ������ ���� ��쿡�� ȸ�� ó������ ����
        if (direction == Vector2.zero) return;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// ���� ���͸� ������ ��ȯ
        bool isLeft = Mathf.Abs(rotZ) > 90f; // ȸ�� ������ ���� �Ǵ�

        characterRenderer.flipX = isLeft;


    }


}



