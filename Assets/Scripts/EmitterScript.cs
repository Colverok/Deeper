using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class describes the behaviour of the emitter of enemies
/// </summary>
public class EmitterScript : MonoBehaviour
{
    /// <summary>
    /// GameObject which represents enemy to emite
    /// </summary>
    public GameObject enemy;
    /// <summary>
    /// The values of minimum and maximum delay between two enemies are instantiated
    /// </summary>
    public float minDelay, maxDelay;

    /// <summary>
    /// Time in which new enemy is instantiated
    /// </summary>
    private float nextLaunchTime;


    void Update()
    {
        if (Time.time > nextLaunchTime)
        {
            float xHalfSize = GetComponent<SpriteRenderer>().bounds.size.x / 2;
            Vector3 position = transform.localPosition + new Vector3(Random.Range(-xHalfSize, xHalfSize), 0, 0);
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-20, 20)));
            Instantiate(enemy, position, rotation);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
