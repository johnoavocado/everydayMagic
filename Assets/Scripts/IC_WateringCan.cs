using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IC_WateringCan : ItemController
{
    private bool full = false;
    
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
                    if (full)
                    {
                        full = false;
                        worldThing.Absorb(WorldThing.Resource.Water);
                    }

                    break;
                case WorldThing.Type.Fire:
                    if (full)
                    {
                        full = false;
                        worldThing.Absorb(WorldThing.Resource.Water);
                    }

                    break;
                case WorldThing.Type.River:
                    full = true;
                    break;
                default:
                    break;
            }
        }

        return false; // not exhausted
    }
}
