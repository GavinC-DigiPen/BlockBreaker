//------------------------------------------------------------------------------
//
// File Name:	BrickSpawner.cs
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

public class BrickSpawner : MonoBehaviour
{
    [Tooltip("The bottom left corner for area bricks will be spawned in")]
    public Vector2 oppositeCorner;
    [Tooltip("The offset of the second layer")]
    public float secondLayerOffset = 0.625f;
    [Tooltip("The regular offset between bricks")]
    public Vector2 spacing = new Vector2(1.25f, 0.5f);
    [Tooltip("The brick prefab")]
    public GameObject brickPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnLocation = transform.position;

        spawnLocation.y = transform.position.y;
        for (int y = 0; spawnLocation.y > oppositeCorner.y; y++)
        {
            if (y % 2 == 0)
            {
                spawnLocation.x = transform.position.x;
            }
            else
            {
                spawnLocation.x = transform.position.x + secondLayerOffset;
            }
            while (spawnLocation.x < oppositeCorner.x)
            {
                Instantiate(brickPrefab, spawnLocation, Quaternion.identity);
                spawnLocation.x += spacing.x;
            }
            spawnLocation.y -= spacing.y;
        }

        Destroy(gameObject);
    }

}
