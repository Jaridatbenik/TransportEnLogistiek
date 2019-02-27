using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprites : MonoBehaviour
{
    public static Sprite[] availableItemSprites;

    void Start()
    {
        availableItemSprites = Resources.LoadAll<Sprite>("Items/Items");
    }
}
