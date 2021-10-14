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
    // Update text
    // Params:
    //  textInput: the text that the TMP will be set to
    public void UpdateText(string textInput)
    {
        GetComponent<TextMeshProUGUI>().text = textInput;
    }
}
