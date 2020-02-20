using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class gManager : MonoBehaviour
{
    public Text scoreText;
    [HideInInspector]
    public bool isLose;
    public GameObject loseText;
    public GameObject startText;
    public GameObject winText;
    [SerializeField]
    private bool lineSpawned;
    private int score;
    void Start()
    {
        isLose = false;
        Line = false;
        Score = 0;
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.anyKey && Time.timeScale == 0)
        {
            startText.SetActive(false);
            Time.timeScale = 2f;
        }
        if (isLose)
        {
            LoseOrWin(loseText);
            if (Input.GetKeyDown(KeyCode.F))
            {
                RestartLvl();
            }
        }
        if (Score == 2)
        {
            LoseOrWin(winText);
            if (Input.anyKey)
            {
                RestartLvl();
            }
        }
    }

    private void LoseOrWin(GameObject go)
    {
        go.SetActive(true);
        Time.timeScale = 0f;
    }
    private void RestartLvl()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 2f;
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
            scoreText.GetComponent<Text>().text = "Score: " + score;
        }
    }
}
