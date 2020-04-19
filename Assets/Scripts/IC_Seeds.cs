using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IC_Seeds : ItemController
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
                case WorldThing.Type.Field:
                    worldThing.Absorb(WorldThing.Resource.Seeds);
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
