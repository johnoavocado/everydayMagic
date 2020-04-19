using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Vector3 putdownposition;

    public List<WorldThing.Type> Safe_WT_Types;
    
    public virtual void Start()
    {
        putdownposition = transform.position;
    }
    
    public virtual bool CanActivateWith(WorldThing worldThing)
    {
        foreach (var WT_Type in Safe_WT_Types)
        {
            if (worldThing.type == WT_Type) return true;
        }
        
        return false;
    }

    public virtual bool Activate(WorldThing worldThing)
    {
        // ... do your thang
        return false; // Not exhausted
    }

    public void PutDown(Vector3 position)
    {
        Vector3 tmp_pos = transform.position;
        tmp_pos.y = position.y;
        transform.position = tmp_pos;
    }
}
