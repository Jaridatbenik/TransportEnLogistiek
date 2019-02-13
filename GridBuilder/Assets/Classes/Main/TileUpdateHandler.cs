using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUpdateHandler : MonoBehaviour
{
    public TileGameObject obj;

    void Update()
    {
        obj.TileUpdate();
    }

    void FixedUpdate()
    {
        obj.TileFixedUpdate();
    }
}
