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
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    //<summary>水平方向の入力値
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
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
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
