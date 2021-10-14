//------------------------------------------------------------------------------
//
// File Name:	Brick.cs
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
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    [Tooltip("The name of the scene that will be loaded when all bricks broken")]
    public string endScene = "EndScreen";
    [Tooltip("Do these bricks give score, when destroyed does it move to new scene")]
    public bool scoring = true;

    private Vector2 healthRange = new Vector2(1, 3);
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range((int)healthRange.x, (int)healthRange.y + 1);

        switch (health)
        {
            case 1:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }

        //Vector3 colorRGB;
        //colorRGB.x = Random.Range(0f, 0.5f);
        //colorRGB.y = Random.Range(0f, 0.5f);
        //colorRGB.z = Random.Range(0f, 0.5f);
        //switch (health)
        //{
        //    case 1:
        //        colorRGB.x = Random.Range(0.5f, 1f);
        //        break;
        //    case 2:
        //        colorRGB.y = Random.Range(0.5f, 1f);
        //        break;
        //    case 3:
        //        colorRGB.z = Random.Range(0.5f, 1f);
        //        break;
        //}
        //GetComponent<SpriteRenderer>().color = new Color(colorRGB.x, colorRGB.y, colorRGB.z);
    }

    // Delete self when collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health <= 0)
        {
            if (scoring)
            {
                LevelController scoreScript = FindObjectOfType<LevelController>();
                if (scoreScript)
                {
                    scoreScript.IncreaseScore();
                }

                Brick[] numberOfBricks = FindObjectsOfType<Brick>();
                if (numberOfBricks.Length <= 1)
                {
                    SceneManager.LoadScene(endScene);
                }
            }
            Destroy(gameObject);
        }
        else
        {
            switch (health)
            {
                case 1:
                    GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().color = Color.green;
                    break;
            }
        }
    }
}
