using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR;

public class Seller : WorldThing
{
    public GameObject seedPrefab;

    public GameObject spawnHere;
    public override void Absorb(Resource resource)
    {
        base.Absorb(resource);

        if (ResourcesAbsorbed.Contains(Resource.Money))
        {
            ResourcesAbsorbed.Remove(Resource.Money);
            ResourcesAbsorbed.TrimExcess();
            var go = Instantiate(seedPrefab, null);
            go.transform.position = this.transform.position;
            go.transform.DOMove(spawnHere.transform.position, 0.3f);
        }
    }
}
