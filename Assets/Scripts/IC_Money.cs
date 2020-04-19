using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IC_Money : ItemController
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
                case WorldThing.Type.Seller:
                    worldThing.Absorb(WorldThing.Resource.Money);
                    return true;
                case WorldThing.Type.Fire:
                    return true; // destroyed you idiot
                default:
                    break;
            }
        }

        return false; // not exhausted
    }
}
