using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{

    protected override void HandleAction()
    {
        // 키보드 입력을 통해 이동 방향 계산 
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D 또는 ←/→
        float vertical = Input.GetAxisRaw("Vertical"); // W/S 또는 ↑/↓

        // 방향 벡터 정규화
        movementDirection = new Vector2(horizontal, vertical).normalized;//대각선 이동 속도 정상화?
    }
}


