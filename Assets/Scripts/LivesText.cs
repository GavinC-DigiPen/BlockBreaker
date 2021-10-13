//------------------------------------------------------------------------------
//
// File Name:	LivesText.cs
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

public class LivesText : MonoBehaviour
{
    [Tooltip("Prefab of the ball")]
    public GameObject ball;
    [Tooltip("Delay before new ball spawn in")]
    public float ballSpawnDelay = 1f;
    [Tooltip("Name of end scene")]
    public string endScene = "EndScreen";

    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = " Lives: " + lives;
    }

    // Increase the score and changes the text
    public void DecreaseLives()
    {
        lives--;
        GetComponent<TextMeshProUGUI>().text = " Lives: " + lives;

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
}
