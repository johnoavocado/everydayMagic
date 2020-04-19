using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public CharacterController cc;

    private void Start()
    {
        if (!cc) cc = GetComponentInParent <CharacterController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<ItemController>() != null) cc.AvailableItems.Add(other.GetComponent<ItemController>() );
        Debug.Log("There are " + cc.AvailableItems.Count + " items available.");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<ItemController>() != null) cc.AvailableItems.Remove(other.GetComponent<ItemController>() );
        Debug.Log("There are " + cc.AvailableItems.Count + " items available.");
    }
}
