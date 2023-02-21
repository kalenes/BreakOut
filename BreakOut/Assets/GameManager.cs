using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    [SerializeField]private GameObject[] breakables;
    public GameObject[] balls;
    public GameObject ball;
    private bool gamePause = false;
    public GameObject star;
    private float currentTime;
    private float instTime;
    public TextMeshProUGUI endText;
    private void Start()
    {
        instTime = Random.Range(6, 10);
    }

    private void Update()
    {
        breakables = GameObject.FindGameObjectsWithTag("Breakable");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        currentTime += Time.deltaTime;
        if(currentTime > instTime)
        {
            instantStar();
        }
        if (balls.Length == 0 && !gamePause)
        {
            gamePause = true;
            endText.text = "THE LOSE";
            endText.color = Color.red;
            GameOver();
        }

        if (breakables.Length <=0)
        {
            gamePause = true;
            endText.text = "THE WIN";
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    
    public void instantStar()
    {
        float random;
        random = Random.Range(-2.05f, 2.05f); 
        Debug.Log(random);
        Instantiate(star, new Vector2(random, 5.3f), Quaternion.identity);
        instTime = Random.Range(4, 10);
        currentTime = 0;
    }
    public void instantBall(Vector2 a)
    {
        Instantiate(ball, a, Quaternion.identity);
    }

}
