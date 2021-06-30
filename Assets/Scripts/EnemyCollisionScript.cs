using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the behaviour of enemies and player when they collide
/// </summary>
public class EnemyCollisionScript : MonoBehaviour
{
    // Time of animation of player
    public float playerAnimationTime = 0.5f;
    // Time of animation of enemy
    public float enemyAnimationTime = 0.2f;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // enemy?
        EnemyScript enemy = otherCollider.gameObject.GetComponent<EnemyScript>();
        if (enemy != null) 
        {

            // Animation of enemy
            otherCollider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY; 
            otherCollider.GetComponent<Animator>().SetTrigger("OnPlayerMeet");
            // Animation of player
            GetComponent<Animator>().SetTrigger("EnemyMeet");
            GetComponent<PlayerScript>().SetAnimation(playerAnimationTime);
            GetComponent<AudioSource>().Play();
            // Destroying enemy
            Destroy(otherCollider.gameObject, enemyAnimationTime);
        }
    }
    
}
