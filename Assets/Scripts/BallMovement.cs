using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float _radius;
    [SerializeField]
    private float _angle;
    public bool clockwise;
    public GameObject _center;
    void Start()
    {
        clockwise = true;
        _angle = -20;
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
            _angle += Time.deltaTime;
            BallMove(_angle);
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
