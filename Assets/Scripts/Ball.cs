//------------------------------------------------------------------------------
//
// File Name:	Ball.cs
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

public class Ball : MonoBehaviour
{
    [Tooltip("Amount of x and y force added to ball on start")]
    public Vector2 forceAdded = new Vector2(250, 250);
    [Tooltip("The delay before the ball starts moving")]
    public float ballMoveDelay = 0.5f;

    private KeyCode moveBallKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelayVelocity");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(moveBallKey))
        {
            StartCoroutine("DelayVelocity");
        }
    }

        // Coroutitine so delay can be added, adds velocity 
        private IEnumerator DelayVelocity()
    {
        yield return new WaitForSeconds(ballMoveDelay);

        bool dirrection = Random.Range(0f, 1f) > 0.5f;
        if (dirrection)
        {
            forceAdded.x *= -1;
        }
        GetComponent<Rigidbody2D>().AddForce(forceAdded);
    }

    // Destroy when off screen
    private void OnBecameInvisible()
    {
        FindObjectOfType<LevelController>().DecreaseLives();
        Destroy(gameObject);
    }
}
