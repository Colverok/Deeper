using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the behaviour of player (cat)
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// The values of speed.x and speed.y of player
    /// </summary>
    public Vector2 speed = new Vector2(50, 50);
    /// <summary>
    /// Bool value describes if the player have met enemy
    /// </summary>
    public bool IsMeetEnemy = false;
    /// <summary>
    /// Bool value describes if the player is animated at the moment
    /// </summary>
    public bool isAnimated = false;

    /// <summary>
    ///  Time of animation of player
    /// </summary>
    private float animationTime = 0.5f;
    /// <summary>
    ///  The direction of movement.x when player is animated
    /// </summary>
    private int directAnim;
    /// <summary>
    /// New vector of velocity
    /// </summary>
    private Vector2 movement;
    
    /// <summary>
    /// Method that set new movement
    /// </summary>
    /// <param name="speedX"> X-axis speed</param>
    /// <param name="speedY"> Y-axis speed</param>
    public void SetMovement(float speedX, float speedY)
    {
        movement = new Vector2(speedX, speedY);
    }
    /// <summary>
    /// Methos that begins the animation
    /// </summary>
    /// <param name="value">Time of animation</param>
    public void SetAnimation(float value)
    {
        isAnimated = true;
        animationTime = value;
    }

    void Start()
    {
        directAnim = 3;
    }
    void Update()
    {
        // Getting value of virtual axis
        float inputX = Input.GetAxis("Horizontal");
        // Rotating player
        if (inputX > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (inputX < 0)
        { 
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        // When cat is animated
        if (isAnimated)
        {
            animationTime -= Time.deltaTime;
            SetMovement(directAnim, 8f);
            directAnim = -directAnim; // player is shaking
            if (animationTime <= 0)
            {
                isAnimated = false;
            }

        }
        else
        {
            SetMovement(speed.x * inputX, speed.y);
            // boarders
            if (((transform.position.x >= 14.9) && (inputX > 0)) || ((transform.position.x <= -14.9) && (inputX < 0)))
            {
                SetMovement(0, speed.y);
            }
        }
    }
    
    void FixedUpdate()
    {
        // Applying movement to the component velocity of Rigidbody
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}

