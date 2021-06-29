using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the motion of background
/// </summary>
public class ScrollingScript : MonoBehaviour
{
    /// <summary>
    /// Background speed
    /// </summary>
    public float speed;
    /// <summary>
    /// Direction of motion 
    /// </summary>
    public int direction;
    /// <summary>
    /// Point in which the second background(child) has center 
    /// </summary>
    public float centerOfChild = 18.036f;

    /// <summary>
    /// Start position of motion
    /// </summary>
    private Vector3 startPosition;
    /// <summary>
    /// Covered distance
    /// </summary>
    private float offset;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        offset = Time.time * speed;
        //Looping the position of background 
        float positionY = Mathf.Repeat(offset, centerOfChild);
        transform.position = startPosition + direction *  new Vector3(0, positionY, 0);
    }

}