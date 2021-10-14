//------------------------------------------------------------------------------
//
// File Name:	LevelController.cs
// Author(s):	Gavin Cooper (gavin.cooper@digipen.edu)
// Project:	    Cage
// Course:	    WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [Tooltip("Prefab of the ball")]
    public GameObject ball;
    [Tooltip("Delay before new ball spawn in")]
    public float ballSpawnDelay = 1f;
    [Tooltip("Name of end scene")]
    public string endScene = "EndScreen";

    public int score = 0;
    public int lives = 3;
    private bool DontDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());
        SceneManager.activeSceneChanged += UpdateText;
    }

    // Runs when object awakes
    void Awake()
    {
        LevelController[] objs = FindObjectsOfType<LevelController>();
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroy = true;
        DontDestroyOnLoad(gameObject);
    }

    // Increase the score and changes the text
    public void IncreaseScore()
    {
        score++;
        ScoreText scoreText = FindObjectOfType<ScoreText>();
        if (scoreText)
        {
            scoreText.UpdateText(" Score: " + score.ToString());
        }
    }

    // Increase the score and changes the text
    public void DecreaseLives()
    {
        lives--;
        LivesText livesText = FindObjectOfType<LivesText>();
        if (livesText)
        {
            livesText.UpdateText(" Lives: " + lives.ToString());
        }

        if (lives > 0)
        {
            StartCoroutine("CreateBall");
        }
        else
        {
            SceneManager.LoadScene(endScene);
        }
    }

    // Create new ball
    private IEnumerator CreateBall()
    {
        yield return new WaitForSeconds(ballSpawnDelay);
        Instantiate(ball);
    }

    // Reset the variables
    public void Reset()
    {
        score = 0;
        lives = 3;
    }

    // Reload text on load of level
    // Params:
    //  current: current scene
    //  next: next scene, scene being changed to
    private void UpdateText(Scene current, Scene next)
    {
        if (DontDestroy)
        {
            Debug.Log(score + " " + lives);
            ScoreText scoreText = FindObjectOfType<ScoreText>();
            if (scoreText)
            {
                scoreText.UpdateText(" Score: " + score.ToString());
            }
            LivesText livesText = FindObjectOfType<LivesText>();
            if (livesText)
            {
                livesText.UpdateText(" Lives: " + lives.ToString());
            }

            if (next == SceneManager.GetSceneByName("EndScreen"))
            {
                EndText endText = FindObjectOfType<EndText>();
                if (endText)
                {
                    if (lives > 0)
                    {
                        endText.UpdateText("You Won");
                    }
                    else
                    {
                        endText.UpdateText("You Lost");
                    }
                }
            }
        }
    }
}
