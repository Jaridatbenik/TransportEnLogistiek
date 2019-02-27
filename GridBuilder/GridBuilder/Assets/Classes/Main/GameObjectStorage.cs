using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectStorage : MonoBehaviour
{
    public static GameObject[] availablePrefabs;

    void Start()
    {
        availablePrefabs = Resources.LoadAll<GameObject>("Prefabs/");
        foreach(GameObject obj in availablePrefabs)
        {
            Debug.Log(obj.name);
        }
    }
}
