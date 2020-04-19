using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public List<Effector> Effectors;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Effector>() != null)
        {
            if (Effectors.Contains(other.GetComponent<Effector>()))
            {
                other.GetComponent<Effector>().Activate();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Effector>() != null)
        {
            if (Effectors.Contains(other.GetComponent<Effector>()))
            {
                other.GetComponent<Effector>().Activate();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Effector>() != null)
        {
            if (Effectors.Contains(other.GetComponent<Effector>()))
            {
                other.GetComponent<Effector>().Deactivate();
            }
        }
    }
}
