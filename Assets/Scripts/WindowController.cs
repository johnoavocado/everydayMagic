using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Effector>() != null)
        {
            other.GetComponent<Effector>().Activate();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Effector>() != null)
        {
            other.GetComponent<Effector>().Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Effector>() != null)
        {
            other.GetComponent<Effector>().Deactivate();
        }
    }
}
