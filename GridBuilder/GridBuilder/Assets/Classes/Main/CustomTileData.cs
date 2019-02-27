using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomTileData : MonoBehaviour
{
    public Inventory inv = new Inventory();
    public virtual TileGameObject GetTileGameObject() { return transform.parent.GetComponent<TileGameObject>(); }
    public virtual void RequestInventory() { }

    public abstract void Test();

}





