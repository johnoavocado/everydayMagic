using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WorldThing : MonoBehaviour
{
    public enum Type
    {
        Field,
        Fire,
        River,
        Nothing,
        Buyer,
        Seller,
        FireCave,
        ClassicRadio,
        MetalRadio
    }

    public enum Resource
    {
        Water,
        Dryness,
        Poison,
        HeavyMusic,
        ClassicalMusic,
        Sunshine,
        Darkness,
        Fertiliser,
        Seeds,
        Fire,
        Money,
        Bubbles
    }

    public List<Resource> ResourcesAbsorbed;

    public Type type;

    public void Highlight(bool enabled)
    {
        // start animating
        // play sound
    }

    public virtual void Absorb( Resource resource )
    {
        if (!ResourcesAbsorbed.Contains(resource))
        {
            ResourcesAbsorbed.Add(resource);
        }
    }

    public virtual void Deabsorb(Resource resource)
    {
        if (ResourcesAbsorbed.Contains(resource))
        {
            ResourcesAbsorbed.Remove(resource);
            ResourcesAbsorbed.TrimExcess();
        }
    }
}
