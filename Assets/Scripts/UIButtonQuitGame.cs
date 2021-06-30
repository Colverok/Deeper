using UnityEngine;
using System.Collections;

/// <summary>
/// This class describes the behaviour of the ui quit button 
/// </summary>
public class UIButtonQuitGame : MonoBehaviour {

    /// <summary>
    /// Time of Audioclip linked with button
    /// </summary>
    private float audioTime;

    void Start()
    {
        audioTime = GetComponent<AudioSource>().clip.length;
    }

    /// <summary>
    /// Method that quits the game
    /// </summary>
    public void QuitGame()
    {
        // Play Audio
        GetComponent<AudioSource>().Play();
        StartCoroutine(WaitAndQuit());
    }
    
    /// <summary>
    /// Coroutine that quit game after time of audio of button
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitAndQuit()
    {
        // After the button has played audio ...
        yield return new WaitForSecondsRealtime(audioTime);
        //Closes the game
        Application.Quit();
    }
}