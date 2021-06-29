using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    /// <summary>
    /// The player
    /// </summary>
    public GameObject player;
    /// <summary>
    /// The Image of the player when it is at the ground
    /// </summary>
    public Sprite playerAtTheGround;
    /// <summary>
    /// The GameObject which represents UI Pause
    /// </summary>
    public GameObject Pause;


    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject == player)
        {
            // Changing Sprite
            player.GetComponent<SpriteRenderer>().sprite = playerAtTheGround;
            // Setting the Canvas active and stopping the time
            Pause.GetComponent<UIPause>().isEnd = true;

        }
    }
}
