using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Random
{
    public static Vector3 GetRandomPosition()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int t = UnityEngine.Random.Range(0, navMeshData.indices.Length - 3);

        Vector3 pos = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], UnityEngine.Random.value);
        Vector3.Lerp(pos, navMeshData.vertices[navMeshData.indices[t + 2]], UnityEngine.Random.value);

        return pos;
    }
}
