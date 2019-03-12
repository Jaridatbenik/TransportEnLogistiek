using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public List<ItemDataValues> itemValues;
}

[System.Serializable]
public class ItemDataValues
{
    [SerializeField]
    public int maxItemStack;
    [SerializeField]
    public Sprite itemSprite;
}

