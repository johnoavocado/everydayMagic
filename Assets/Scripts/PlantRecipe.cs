using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "ScriptableObjects/PlantRecipe")]
public class PlantRecipe : ScriptableObject
{
    public List<WorldThing.Resource> ingredients;
    public string result;
    public GameObject plantPrefab;
}