using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This class describes the behaviour of the ui "new level" button 
/// </summary>
public class UIButtonLevelLoad : MonoBehaviour {

	/// <summary>
    /// The name of level to load
    /// </summary>
	public string LevelToLoad;
    /// <summary>
    /// Time of Audioclip linked with button
    /// </summary>
    private float audioTime;

    void Start()
    {
        audioTime = GetComponent<AudioSource>().clip.length;
    }
    public void LoadLevel()
    {
        // Play Audio
        GetComponent<AudioSource>().Play();
        StartCoroutine(WaitAndLoad());
    }
    IEnumerator WaitAndLoad()
    {
        // After the button has played audio ...
        yield return new WaitForSecondsRealtime(audioTime);
        // Loading the level from LevelToLoad
        SceneManager.LoadScene(LevelToLoad);
    }
}
