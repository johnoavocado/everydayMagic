using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FieldSpawner : Effector
{
    public GameObject plantToSpawn = null;
    
    public GameObject spawnZone1;

    public AudioSource audioSource;

    public List<AudioClip> GrowClips;
    public override void Activate()
    {
        if (plantToSpawn == null) return;

        var go = Instantiate(plantToSpawn);
        go.transform.position = this.transform.position;
        go.transform.DOMove(spawnZone1.transform.position, 0.5f);

        audioSource.clip = GrowClips[Random.Range(0, GrowClips.Count-1)];
        audioSource.Play();

        plantToSpawn = null;
    }

    public override void Deactivate()
    {
        // do nothing
    }
}
