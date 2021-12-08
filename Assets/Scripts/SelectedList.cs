using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedList : MonoBehaviour
{
    public static SelectedList instance;

    public List<GameObject> selectedList;

    private void Awake()
    {
        if (instance && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void AddSelected(GameObject go)
    {
        int id = go.GetInstanceID();

        if (!selectedList.Contains(go))
        {
            selectedList.Add(go);
            go.GetComponent<Renderer>().material.color = Color.yellow;
            CameraController.instance.followTransform = go.transform;
        }
    }

    public void Deselect(GameObject go)
    {
        selectedList.Remove(go);
        go.GetComponent<Renderer>().material.color = Color.white;
    }

    public void DeselectAll()
    {
        foreach (GameObject selection in selectedList)
            selection.GetComponent<Renderer>().material.color = Color.white;
        selectedList.Clear();
    }

    private void OnDestroy()
    {
        if (this == instance)
            instance = null;
    }
}
