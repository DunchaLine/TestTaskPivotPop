using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresMovement : MonoBehaviour
{
    public Camera cam;
    public float speed;
    public Material[] objColors;
    private Material _ownMaterial;

    void Start()
    {
        cam = GetComponent<Camera>();
        _ownMaterial = GetComponent<Renderer>().material;
        _ownMaterial.color = objColors[Random.Range(0, objColors.Length)].color;
    }

    void Update()
    {
        if (transform.position.y < -5f)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.activeInHierarchy)
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }
    }
}
