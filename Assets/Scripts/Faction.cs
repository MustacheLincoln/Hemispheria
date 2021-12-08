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
    public float foodChange;
    public float foodMax = 500;
    public float food;
    public float timeBetweenCitizens;
    public float timeToNextCitizen;
    public float timeToNextCitizenMax;
    public float timeToNextCitizenLimit = 100;
    public float tickMax = 1;
    public float tick;

    private void Start()
    {
        tick = tickMax;
    }

    private void Update()
    {
        tick -= Time.deltaTime;
        if (tick <= 0)
        {
            tick = tickMax;
            CalculateHappiness();
            CalculateTimeBetweenCitizens();
            CalculateFood();

            timeToNextCitizen -= 1;
            if (timeToNextCitizen <= 0)
            {
                SpawnCitizen();
                CalculateHappiness();
                CalculateTimeBetweenCitizens();
                timeToNextCitizenMax = timeBetweenCitizens;
                timeToNextCitizen = timeToNextCitizenMax;
            }
        }
    }

    private void CalculateFood()
    {
        food += foodChange;
        if (food > foodMax)
            food = foodMax;
        foodChange = 0;
        foreach (GameObject pop in population)
        {
            Citizen citizen = pop.GetComponent<Citizen>();
            foodChange += citizen.foodGathered;
            foodChange -= citizen.foodConsumed;
        }
    }

    private void CalculateHappiness()
    {
        happiness = baseHappiness - population.Count;
    }

    private void CalculateTimeBetweenCitizens()
    {
        timeBetweenCitizens = timeToNextCitizenLimit / happiness;
        if (timeToNextCitizenMax > timeBetweenCitizens)
        {
            timeToNextCitizenMax = timeBetweenCitizens;
            if (timeToNextCitizen > timeToNextCitizenMax)
                timeToNextCitizen = timeToNextCitizenMax + 1;
        }
    }

    private void SpawnCitizen()
    {
        GameObject newCitizen = Instantiate(citizen);
        population.Add(newCitizen);
        newCitizen.GetComponent<Citizen>().faction = this;
    }
}
