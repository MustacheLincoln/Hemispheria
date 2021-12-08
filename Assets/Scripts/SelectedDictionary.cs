using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedDictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedDict = new Dictionary<int, GameObject>();

    public void AddSelected(GameObject go)
    {
        int id = go.GetInstanceID();

        if (!selectedDict.ContainsKey(id))
        {
            selectedDict.Add(id, go);
            go.GetComponent<Renderer>().material.color = Color.yellow;
            CameraController.instance.followTransform = go.transform;
        }
    }

    public void Deselect(int id)
    {
        selectedDict.Remove(id);
        selectedDict[id].GetComponent<Renderer>().material.color = Color.white;
    }

    public void DeselectAll()
    {
        foreach (KeyValuePair<int, GameObject> pair in selectedDict)
            if (pair.Value)
                selectedDict[pair.Key].GetComponent<Renderer>().material.color = Color.white;
        selectedDict.Clear();
    }
}
