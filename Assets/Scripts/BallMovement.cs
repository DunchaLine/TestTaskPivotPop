using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float _radius;
    [SerializeField]
    private float _angle;
    //public float _speed;
    public bool clockwise;
    public GameObject _center;
    // private Rigidbody2D _rb;
    void Start()
    {
        clockwise = true;
        _angle = -20;
        //_rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 2f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clockwise = !clockwise;
        }
        else
        if (clockwise)
        {
            //var x = _center.transform.position.x + _radius * Mathf.Sin(_angle) * _speed;
            //var y = _center.transform.position.y + _radius * Mathf.Cos(_angle) * _speed;
            _angle += Time.deltaTime;
            BallMove(_angle);
            //float step = _speed / Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y), step);
            // Vector3 main = new Vector3(x, y);
            // Debug.Log("main: " + main);
            // _rb.velocity = main;
            // Vector3 _dir = new Vector3(x, y) - _currPos;
            // transform.Translate(_dir * Time.deltaTime * _speed);
        }
        if (!clockwise)
        {
            _angle -= Time.deltaTime;
            BallMove(_angle);
        }
    }
    void BallMove(float angle)
    {
            var x = Mathf.Cos(angle) * _radius;
            var y = Mathf.Sin(angle) * _radius;
            Vector3 _currPos = transform.position;
            transform.position = (new Vector3(x, y) + _center.transform.position);
    }
}
