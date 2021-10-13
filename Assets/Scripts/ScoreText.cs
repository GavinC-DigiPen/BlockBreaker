//------------------------------------------------------------------------------
//
// File Name:	ScoreText.cs
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

public class ScoreText : MonoBehaviour
{
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = " Score: " + score;
    }
    
    // Increase the score and changes the text
    public void IncreaseScore()
    {
        score++;
        GetComponent<TextMeshProUGUI>().text = " Score: " + score;
    }
}
