using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gManager : MonoBehaviour
{
    [SerializeField]
    private bool lineSpawned = true;
    void Start()
    {
        Line = false;
    }

    void Update()
    {
        
    }

    public bool Line
    {
        get
        {
            return lineSpawned;
        }
        set
        {
            lineSpawned = value;
        }
    }
}
