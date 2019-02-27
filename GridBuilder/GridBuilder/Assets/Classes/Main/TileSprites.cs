using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSprites : MonoBehaviour
{
    public static Sprite[] availableTileSprites;

    void Start()
    {
        availableTileSprites = Resources.LoadAll<Sprite>("Tiles/Tiles");
    }
}
