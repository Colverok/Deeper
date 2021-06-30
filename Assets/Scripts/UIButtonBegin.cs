using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that describes the behaviour of button which starts the game
/// </summary>
public class UIButtonBegin : MonoBehaviour
{
    /// <summary>
    /// UI Pause Canvas
    /// </summary>
    public GameObject Pause;

    /// <summary>
    /// Method that starts the game
    /// </summary>
    public void StartGame()
    {
        // Set BeginCanvas not active and timescale = 1f
        Pause.GetComponent<UIPause>().isBegin = true;
    }
}
