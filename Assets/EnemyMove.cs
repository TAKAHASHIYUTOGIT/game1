using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    [SerializeField] float _speed;
    float _dir = 1;
    [SerializeField] Transform[] _returnPos;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _sr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
    //    if (transform.position.x > _returnPos[0].position.x)
    //    {
    //        _dir = -1;
    //        _sr.flipX = false;
    //    }
    //    else if (transform.position.x < _returnPos[1].position.x)
    //    {
    //        _dir = 1;
    //        _sr.flipX = true;
    //    }
    //    Debug.Log(_dir);
    }
}
