using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the behaviour of enemies 
/// </summary>
public class EnemyScript : MonoBehaviour
{
    /// <summary>
    /// The values of speed.x and speed.y of enemy
    /// </summary>
    public Vector2 speed = new Vector2(12, 12);
    /// <summary>
    /// The values of x and y direction of enemy
    /// </summary>
    public Vector2 direction = new Vector2(0, 1);

    /// <summary>
    /// New vector of velocity
    /// </summary>
    private Vector2 movement;

    void Update()
    {
        // Creating new vector of velocity depending on given speed and direction
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // Applying movement to the component velociry of Rigidbody
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
