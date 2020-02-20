using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gManager : MonoBehaviour
{
    [SerializeField]
    private bool lineSpawned;
    private int score;
    void Start()
    {
        Line = false;
        Score = 0;
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

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
}
