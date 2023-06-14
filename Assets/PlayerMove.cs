using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    [SerializeField] int _hp = 1;
    //[SerializeField] Text _text;//GameOver
    //[SerializeField] Text _text1;//Game Clear
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    [SerializeField] bool m_flipX = false;
    //<summary>水平方向の入力値
    float m_h;
    float m_scaleX;
    // Start is called before the first frame update
    int count = 0;
    bool m_isGround = false;
    bool iswallhit;
    bool _isAliving = true;
    public bool is_Game = true;
    public int Hp { get { return _hp; } }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        //_text.enabled = false;
    }

    // Update is called once per S
     void Update()
    {
        if (is_Game)
        {//入力を受け取る
            m_h = Input.GetAxisRaw("Horizontal");

            Vector2 velocity = _rb.velocity;
            velocity.x = m_h * m_movePower;
            _rb.velocity = velocity;

            // 各種入力を受け取る
            if (Input.GetButtonDown("Jump") && count < 2)
            {
                _rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
                count++;
            }
            //設定に応じて左右を反転させる
            if (m_flipX)
            {
                FlipX(m_h);
            }
            if (_hp == 0)
            {
                //_text.enabled = true;
            }
        }
        else //(!is_Game)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                is_Game = true;
                transform.position = new Vector2(-12, 0.5f);
            }
        }    }
    private object AddForce(float m_jumpPower)
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        if (!iswallhit)
        {
            _rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
        }
    }

    void FlipX(float horizontal)//方向転換
    {
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
        if (collision.tag == "Ground")
        {
            m_isGround = true;
            iswallhit = false;
            count = 0;
        }
        if (collision.tag == "wall")
        {
            iswallhit = true;
        }
    }
}
