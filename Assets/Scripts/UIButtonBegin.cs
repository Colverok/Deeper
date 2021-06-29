using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonBegin : MonoBehaviour
{
    public GameObject Pause;
    public void StartGame()
    {
        Pause.GetComponent<UIPause>().isBegin = true;
    }
}
