using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (SelectedList.instance.selectedList.Contains(gameObject))
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (MouseRaycast.Instance.Walkable())
                    agent.destination = MouseRaycast.Instance.HitPosition();
            }
        }
    }

    public void Wander(Vector3 pos)
    {
        agent.destination = pos;
        if (Vector3.Distance(agent.destination, pos) <= 1)
        {
            agent.destination = pos + Vector3.forward * 4;
        }
    }
}
