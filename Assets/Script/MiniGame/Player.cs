using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animater;
    Rigidbody2D _rigidbody;

    public float flapforce = 6.0f;
    public float forwordSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;
    public bool godmood = false;
    GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        animater = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animater == null)
            Debug.LogError("���ϸ����Ͱ� ���پƾ�");
        if (_rigidbody == null)
            Debug.LogError("������ٵ𰡾��پƾ�");

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();

                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;

            }
        }

    }
    private void FixedUpdate()
    {
        if (isDead) return;

        {
            Vector3 velocity = _rigidbody.velocity;
            velocity.x = forwordSpeed;
            if (isFlap == true)
            {
                velocity.y += flapforce;//�̹� �Ʒ��� -�̵��ӵ��� ��� �־ ���� ���ϸ� �� ��������.
                isFlap = false;
            }
            _rigidbody.velocity = velocity;

            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godmood)
        {
            return;
        }

        animater.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        gameManager.GameOver();

    }
}
