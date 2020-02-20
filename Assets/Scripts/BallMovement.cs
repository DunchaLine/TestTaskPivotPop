using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float _radius;
    public GameObject managerObj;
    public bool clockwise;
    public GameObject _center;
    private gManager manager;
    private Color tmpColor;
    [SerializeField]
    private float _angle;
    private Material ownMaterial;
    void Start()
    {
        manager = managerObj.GetComponent<gManager>();
        ownMaterial = GetComponent<Renderer>().material;
        clockwise = true;
        _angle = -20;
        Time.timeScale = 2f;
    }

    void Update()
    {
        Debug.Log("SCORE " + manager.Score);
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "figures")
        {
            tmpColor = other.gameObject.GetComponent<Renderer>().material.color;
            if (tmpColor == ownMaterial.color)
            {
                Destroy(other.gameObject);
                manager.Score++;
            }
        }
    }
}
