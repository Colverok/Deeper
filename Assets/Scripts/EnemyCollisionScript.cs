using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionScript : MonoBehaviour
{
    /*
    void CollisionAnimate(GameObject player, GameObject enemy)
    {
        enemy.GetComponent<Animator>().SetTrigger("OnPlayerMeet");

        print(enemy.GetComponent<Animator>().GetParameter(0).name);
        player.GetComponent<Animator>().SetTrigger("EnemyMeet");
        player.GetComponent<PlayerScript>().IsMeetEnemy = true;
        player.GetComponent<AudioSource>().Play();
    }*/
    public float playerAnimationTime = 0.5f;

    public float enemyAnimationTime = 0.2f;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Это enemy?
        EnemyScript enemy = otherCollider.gameObject.GetComponent<EnemyScript>();
        if (enemy != null) 
        {
            //CollisionAnimate(this.gameObject, otherCollider.gameObject);

            otherCollider.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            otherCollider.GetComponent<Animator>().SetTrigger("OnPlayerMeet");
            
            GetComponent<Animator>().SetTrigger("EnemyMeet");
            GetComponent<PlayerScript>().SetAnimation(playerAnimationTime);
            GetComponent<AudioSource>().Play();
            Destroy(otherCollider.gameObject, enemyAnimationTime);
        }
    }
    
}
