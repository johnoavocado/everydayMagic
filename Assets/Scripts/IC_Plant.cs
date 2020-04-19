using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IC_Plant : ItemController
{
    public override void Start()
    {
        base.Start();
    }
    
    public override bool Activate(WorldThing worldThing)
    {
        if (CanActivateWith(worldThing))
        {
            switch (worldThing.type)
            {
                case WorldThing.Type.Buyer:
                    worldThing.Absorb(WorldThing.Resource.Plant);
                    return true;
                default:
                    break;
            }
        }
        
        return false;
    }
}
