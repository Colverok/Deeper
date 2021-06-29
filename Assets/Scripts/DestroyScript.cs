using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class describes the behaviour of area that destroys objects beyond its borders
/// </summary>
public class DestroyScript : MonoBehaviour
{
    public string BadEndScene;
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(BadEndScene);
        }
    }
}
