using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IC_Plant : ItemController
{
    public override void Start()
    {
        base.Start();
        
        Safe_WT_Types.Add(WorldThing.Type.Seller);
    }
    
    public override bool Activate(WorldThing worldThing)
    {
        if (CanActivateWith(worldThing))
        {
            switch (worldThing.type)
            {
                case WorldThing.Type.Seller:
                    worldThing.Absorb(WorldThing.Resource.Plant);
                    return true;
                default:
                    break;
            }
        }
        
        return false;
    }
}
