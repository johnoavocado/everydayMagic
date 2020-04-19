using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : WorldThing
{
    public PullTabController pullTab;

    public List<PlantRecipe> recipes;

    private void Start()
    {
        pullTab.pullable = false;
    }

    public override void Absorb(Resource resource)
    {
        base.Absorb(resource);

        foreach (var recipe in recipes)
        {
            if (recipe.ingredients.Count > ResourcesAbsorbed.Count) continue;

            int requiredIngredientsRemaining = recipe.ingredients.Count;
            foreach (var ingredient in recipe.ingredients)
            {
                if (ResourcesAbsorbed.Contains(ingredient)) requiredIngredientsRemaining--;
            }
            
            // Create the plant!
            if (requiredIngredientsRemaining <= 0)
            {
                Debug.Log(recipe.result);
                ResourcesAbsorbed.Clear();
                ResourcesAbsorbed.TrimExcess();
                StartCoroutine(pullTab.Expose());
            }
        }
    }
}
