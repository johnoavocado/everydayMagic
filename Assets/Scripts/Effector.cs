using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour
{
    public List<WorldThing> affected;

    public WorldThing.Resource effect;
    
    public virtual void Activate()
    {
        foreach (var affectee in affected)
        {
            affectee.Absorb(effect);
        }
    }

    public virtual void Deactivate()
    {
        foreach (var affectee in affected)
        {
            affectee.Deabsorb(effect);
        }
    }
}
