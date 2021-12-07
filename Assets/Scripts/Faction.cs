using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour
{
    public GameObject citizen;
    public List<GameObject> population;
    public float baseHappiness = 4;
    public float happiness;
    public float timeBetweenCitizens;
    public float timeToNextCitizen;
    public float timeToNextCitizenMax;

    private void Update()
    {
        CalculateHappiness();
        CalculateTimeBetweenCitizens();

        if (timeToNextCitizen <= 0)
        {
            SpawnCitizen();
            CalculateHappiness();
            CalculateTimeBetweenCitizens();
            timeToNextCitizenMax = timeBetweenCitizens;
            timeToNextCitizen = timeToNextCitizenMax;
        }
        timeToNextCitizen -= Time.deltaTime;
    }

    private void CalculateHappiness()
    {
        happiness = baseHappiness - population.Count;
    }

    private void CalculateTimeBetweenCitizens()
    {
        timeBetweenCitizens = 100 / happiness;
    }

    private void SpawnCitizen()
    {
        GameObject newCitizen = Instantiate(citizen);
        population.Add(newCitizen);
        newCitizen.GetComponent<Citizen>().faction = this;
    }
}
