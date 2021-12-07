using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public Faction faction;

    private void OnDestroy()
    {
        faction.population.Remove(this.gameObject);
    }
}
