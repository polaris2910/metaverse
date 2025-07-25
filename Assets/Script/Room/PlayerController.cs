using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{

    protected override void HandleAction()
    {
        // Ű���� �Է��� ���� �̵� ���� ��� 
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D �Ǵ� ��/��
        float vertical = Input.GetAxisRaw("Vertical"); // W/S �Ǵ� ��/��

        // ���� ���� ����ȭ
        movementDirection = new Vector2(horizontal, vertical).normalized;//�밢�� �̵� �ӵ� ����ȭ?
    }
}


