using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    /// <summary>���E�ړ������</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>�W�����v�����</summary>
    [SerializeField] float m_jumpPower = 15f;
    //<summary>���������̓��͒l
    float m_h;
    float m_scaleX;
    // Start is called before the first frame update
    int count = 0;
    bool m_isGround = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per 
    private void Update()
    {//���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");

        Vector2 velocity = _rb.velocity;
        velocity.x = m_h * m_movePower;
        _rb.velocity = velocity;

        // �e����͂��󂯎��
        if (Input.GetButtonDown("Jump") && count < 2)
        {
            _rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            count++;
        }
    }
    private object AddForce(float m_jumpPower)
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
    }

    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
         * */
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_isGround = true;
        count = 0;
    }
}
