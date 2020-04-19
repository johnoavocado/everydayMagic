using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IC_Lute : ItemController
{
    public override void Start()
    {
        base.Start();
        
        Safe_WT_Types.Add(WorldThing.Type.Field);
    }
    
    public override bool Activate(WorldThing worldThing)
    {
        if (CanActivateWith(worldThing))
        {
            switch (worldThing.type)
            {
                case WorldThing.Type.Field:
                    worldThing.Absorb(WorldThing.Resource.ClassicalMusic);
                    return false;
                default:
                    break;
            }
        }
        
        return false;
    }
}
