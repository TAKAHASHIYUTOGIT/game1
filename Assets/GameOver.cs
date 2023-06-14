using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]Text _text;
    [SerializeField]Text _text2;
    bool _enabled = false;
    bool _enabled1 = false;
    PlayerMove _pm;
    // Start is called before the first frame update
    void Start()
    {
        _text.enabled = false;
        _text2.enabled = false;
        _pm = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_enabled == true && !_pm.is_Game)
        {

            _text.enabled = true;
        }
        else//(_enabled == false)
        {
            _text.enabled = false;
        }

        if (_enabled1 == true && !_pm.is_Game)
        {
            _text2.enabled = true;
        }
        else//( _enabled1 == false)
        {
            _text2.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("���������Q");
            _enabled = true;
            _enabled1 = true;
            _pm.is_Game = false;
            //_text.enabled = true;
        }   
    }
}



