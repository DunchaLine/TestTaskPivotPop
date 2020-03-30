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
    public GameObject restartButton;
    public GameObject loseText;
    public GameObject startText;
    public GameObject winText;
    [SerializeField]
    private bool _lineSpawned;
    private int _score;
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
            restartButton.SetActive(true);
        }
        if (Score == 10)
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
            return _lineSpawned;
        }
        set
        {
            _lineSpawned = value;
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreText.GetComponent<Text>().text = "Score: " + _score;
        }
    }
}
