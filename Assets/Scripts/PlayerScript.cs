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

    public bool IsMeetEnemy = false;

    public bool isAnimated = false;

    private float animationTime = 0.5f;
    private int directAnim;
    /// <summary>
    /// New vector of velocity
    /// </summary>
    private Vector2 movement;
    
    public void SetMovement(float speedX, float speedY)
    {
        movement = new Vector2(speedX, speedY);
    }
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

        if (inputX > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (inputX < 0)
        { 
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (isAnimated)
        {
            animationTime -= Time.deltaTime;
            SetMovement(directAnim, 8f);
            directAnim = -directAnim;
            if (animationTime <= 0)
            {
                isAnimated = false;
            }

        }
        else
        {
            SetMovement(speed.x * inputX, speed.y);
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

