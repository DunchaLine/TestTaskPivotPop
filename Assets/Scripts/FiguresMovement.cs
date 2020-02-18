﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresMovement : MonoBehaviour
{
    public float speed;
    public Material[] objColors;
    private Material ownMaterial;

    void Start()
    {
        ownMaterial = GetComponent<Renderer>().material;
        ownMaterial.color = objColors[Random.Range(0, objColors.Length)].color;
    }

    void Update()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }
}
