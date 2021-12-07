using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public Faction faction;
    public enum State { Gathering, Building, Moving, Fighting };
    public State currentState;
    public float foodConsumed = 1;
    public float foodGathered = 0;
    public float gatherAmount = 2;

    private void Start()
    {
        currentState = State.Gathering;
    }

    private void Update()
    {
        if (currentState == State.Gathering)
        {
            if (foodGathered != gatherAmount)
                foodGathered = gatherAmount;
        }
        else
            foodGathered = 0;
    }

    private void OnMouseDown()
    {
        CameraController.instance.followTransform = transform;
    }

    private void OnDestroy()
    {
        faction.population.Remove(gameObject);
    }
}
