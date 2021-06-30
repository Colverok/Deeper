using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class describes the behaviour of area that destroys objects beyond its borders
/// </summary>
public class DestroyScript : MonoBehaviour
{
    /// <summary>
    /// Name of scene which contains bad end 
    /// </summary>
    public string BadEndScene;

    //When object with DestroyScript faces another object, another object will be destroyed
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
        // If "Player" was destroyed, loading "bad end"
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(BadEndScene);
        }
    }
}
