using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBeltData : MonoBehaviour
{
    TileGameObjectEventHandler handler;
    Tile tile;

    void Start()
    {
        handler = transform.parent.GetComponent<TileGameObjectEventHandler>();
        tile = transform.parent.GetComponent<TileGameObject>().assosiatedTile;
        handler.updateEvent.AddListener(ConveyerUpdate);
    }

    public void ConveyerUpdate()
    {
        
    }
}