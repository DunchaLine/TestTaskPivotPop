using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float radius;
    public GameObject managerObj;
    public bool clockwise;
    public GameObject center;
    private gManager _manager;
    private Color _tmpColor;
    [SerializeField]
    private float _angle;
    private Material _ownMaterial;
    void Start()
    {
        _manager = managerObj.GetComponent<gManager>();
        _ownMaterial = GetComponent<Renderer>().material;
        clockwise = true;
        _angle = -20;
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
        var x = Mathf.Cos(angle) * radius;
        var y = Mathf.Sin(angle) * radius;
        Vector3 _currPos = transform.position;
        transform.position = (new Vector3(x, y) + center.transform.position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "figures")
        {
            _tmpColor = other.gameObject.GetComponent<Renderer>().material.color;
            if (_tmpColor == _ownMaterial.color)
            {
                Destroy(other.gameObject);
                _manager.Score++;
            }
            else
            {
                _manager.isLose = true;
            }
        }
        else if (other.gameObject.tag == "Line")
        {
            _tmpColor = other.gameObject.GetComponent<Renderer>().material.color;
            _ownMaterial.color = _tmpColor;
        }
    }
}
