using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Goal : MonoBehaviour
{
    [SerializeField]Text _text1;
    [SerializeField]Text _text2;
    PlayerMove _pm;
    bool _enabled1 = false;
    // Start is called before the first frame update
    void Start()
    {
       _text1.enabled = false;
        _text2.enabled = false;
        _pm = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("ÉQÅ[ÉÄÉNÉäÉA");
            _text1.enabled = true;
            _text2.enabled = true;
        }
    }

}
