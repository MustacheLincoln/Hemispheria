using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Citizen : MonoBehaviour
{
    public Faction faction;
    public enum State { Gathering, Building, Moving, Fighting };
    public GameObject workplace;
    public State currentState;
    public float foodConsumed = 1;
    public float foodGathered = 0;
    public float gatherAmount = 2;
    Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
        currentState = State.Gathering;
    }

    private void Update()
    {
        if (currentState == State.Gathering)
        {
            if (foodGathered != gatherAmount)
                foodGathered = gatherAmount;
            workplace = faction.gameObject;
            movement.Wander(transform.position);
        }
        else
            foodGathered = 0;
    }
    private void OnDestroy()
    {
        faction.population.Remove(gameObject);
    }
}
