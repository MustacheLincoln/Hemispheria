using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public Faction faction;
    public enum State { Idle, Moving, Fighting };
    public State currentState;
    public float foodConsumed = 1;
    public float foodGathered = 0;
    public float IdleFoodGather = 2;

    private void Start()
    {
        currentState = State.Idle;
    }

    private void Update()
    {
        if (currentState == State.Idle)
        {
            if (foodGathered != IdleFoodGather)
                foodGathered = IdleFoodGather;
        }
        else
            foodGathered = 0;
    }

    private void OnDestroy()
    {
        faction.population.Remove(gameObject);
    }
}
