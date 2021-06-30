using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the behaviour of ground (the final of the game)
/// </summary>
public class GroundScript : MonoBehaviour
{
    /// <summary>
    /// The player
    /// </summary>
    public GameObject player;
    /// <summary>
    /// The GameObject which represents UI Pause
    /// </summary>
    public GameObject Pause;


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject == player)
        {
            // Setting the EndCanvas active and stopping the time
            Pause.GetComponent<UIPause>().isEnd = true;

        }
    }
}
