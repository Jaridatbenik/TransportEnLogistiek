using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryComponents
{



}

public class Inventory : InventoryComponents
{


    public Inventory()
    {

    }


}

public class ItemStack
{
    public Item item;
    public Color textColor = Color.black;
    public string flavorText = "";

    public ItemStack(Item item)
    {
        this.item = item;
    }

    public ItemStack(Item item, Color textColor)
    {
        this.item = item;
    }

    public static ItemStack operator +(ItemStack a, ItemStack b)
    {

        return null;
    }
}

public class Item
{
    public int itemID = -1;
    public int itemAmount = -1;
    public string itemName = "";

    public ItemObject itemObject;

    public Item(int id, int amount)
    {
        itemID = id;
        itemAmount = amount;
    }

    public Item(int id, int amount, string name)
    {
        itemID = id;
        itemAmount = amount;
        itemName = name;
    }

    public Item(int id, int amount, bool spawnObject)
    {
        itemID = id;
        itemAmount = amount;

        if (spawnObject)
        {
            ShowItemObject();
        }
    }

    public Item(int id, int amount, string name, bool spawnObject)
    {
        itemID = id;
        itemAmount = amount;
        itemName = name;

        if (spawnObject)
        {
            ShowItemObject();
        }
    }

    public ItemObject setItemObject
    {
        get { return itemObject; }
        set { this.itemObject = value; }
    }

    public void ShowItemObject()
    {
        RemoveItemObject();

        //link this item object to game Object


        GameObject obj = MonoBehaviour.Instantiate(GameObjectStorage.availablePrefabs[0]);
        obj.GetComponent<ItemObject>().showThisItem = this;
    }

    public void RemoveItemObject()
    {
        try
        {
            MonoBehaviour.Destroy(itemObject.gameObject);
        }catch { }
    }

}
