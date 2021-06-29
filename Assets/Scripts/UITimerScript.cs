using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class describes the bahaviour of timer
/// </summary>
public class UITimerScript : MonoBehaviour
{
    /// <summary>
    /// The amount of time in seconds
    /// </summary>
    public float timer = 90;
    /// <summary>
    /// Name of scene which contains bad end 
    /// </summary>
    public string BadEndScene;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        // Convert into seconds
        TimeSpan delta = TimeSpan.FromSeconds(timer);
        // New format
        GetComponent<Text>().text = delta.Minutes.ToString("00") + ":" + delta.Seconds.ToString("00");
        // When the time = 0, player lose
        if (delta.TotalSeconds <= 0)
        {
                SceneManager.LoadScene(BadEndScene);
        }
        
    }
}
