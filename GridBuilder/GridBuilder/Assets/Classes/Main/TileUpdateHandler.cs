using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUpdateHandler : MonoBehaviour
{
    public TileGameObjectEventHandler obj;

    void Start()
    {
        obj = GetComponent<TileGameObjectEventHandler>();
    }

    void Update()
    {
        obj.TileUpdate();
    }

    void FixedUpdate()
    {
        obj.TileFixedUpdate();
    }
}
