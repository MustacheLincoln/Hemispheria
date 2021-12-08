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
            go.AddComponent<SelectionComponent>();
        }
    }

    public void Deselect(int id)
    {
        Destroy(selectedDict[id].GetComponent<SelectionComponent>());
        selectedDict.Remove(id);
    }

    public void DeselectAll()
    {
        foreach (KeyValuePair<int, GameObject> pair in selectedDict)
            if (pair.Value)
                Destroy(selectedDict[pair.Key].GetComponent<SelectionComponent>());
        selectedDict.Clear();
    }
}
