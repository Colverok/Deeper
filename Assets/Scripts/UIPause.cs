using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


/// <summary>
/// This class describes the behaviour of pause in game 
/// </summary>
public class UIPause : MonoBehaviour {

    /// <summary>
    /// Gameobject that represents canvas which is active when spacekey was pressed
    /// </summary>
    public GameObject spaceCanvas;
    /// <summary>
    /// Gameobject that represents canvas which is active when escapekey was pressed
    /// </summary>
    public GameObject escapeCanvas;
    /// <summary>
    /// Gameobject that represents canvas which is active when the player wins the level
    /// </summary>
    public GameObject goodJobCanvas;
    public GameObject beginCanvas;
    public AudioSource EscAudio;
    public Image EscImageToAnimate;
    /// <summary>
    /// Bool value describes if the player won the layer
    /// </summary>
    public bool isEnd = false;
    public bool isBegin = false;

    /// <summary>
    /// Bool value decribes if pause is active
    /// </summary>
    private SortedDictionary<string, bool> isPause = new SortedDictionary<string, bool>();
    /// <summary>
    /// The value describes timescale in game
    /// </summary>
    public float timer = 0;

    void Start()
    {
        isPause.Add("Space", false);
        isPause.Add("Escape", false);
        isPause.Add("End", false);
        isPause.Add("Begin", true);
    }
    /// <summary>
    /// Method that change the value of ispause to the opposite, activates canvas if ispause is true, otherwise desactivates
    /// </summary>
    /// <param name="canvas"> Canvas to set active</param>
    private void PauseAndActive(GameObject canvas, string state)
    {
        isPause[state] = !isPause[state];
        if (isPause[state])
        {
            timer = 0;
            canvas.SetActive(true);
            if (state == "Escape")
            {
                EscImageToAnimate.GetComponent<Animator>().SetTrigger("EscapeBegin");
            }
        }
        else
        {
            
            if (state == "Escape")
            {
                EscImageToAnimate.GetComponent<Animator>().SetTrigger("EscapeEnd");
                StartCoroutine(SetNotActiveCanvas());
            }
            else
            {
                canvas.SetActive(false);
                timer = 1f;
            }
        }
       
    }

    private bool IfAnotherPaused(string thisState)
    {
        foreach (string state in isPause.Keys)
        {
            if ((state != thisState) && (isPause[state] == true))
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Space) && !IfAnotherPaused("Space")) 
        {
            PauseAndActive(spaceCanvas, "Space");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !IfAnotherPaused("Escape"))
        {
            EscAudio.Play();            
            PauseAndActive(escapeCanvas, "Escape");
        }
        else if (isEnd)
        {
            isEnd = false;
            PauseAndActive(goodJobCanvas, "End");
        }
        else if (isBegin)
        {
            isPause["Begin"] = false;
            beginCanvas.SetActive(false);
            isBegin = false;
            timer = 1f;
        }

    }

    IEnumerator SetNotActiveCanvas()
    {
        yield return new WaitForSecondsRealtime(1f);
        escapeCanvas.SetActive(false);
        timer = 1f;
    }


    void LastUpdate()
    {
        Time.timeScale = 1f;
    }
}