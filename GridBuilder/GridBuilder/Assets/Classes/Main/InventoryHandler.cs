using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryHandler
{
    public static void RemoveItemFromInventory(Inventory inv, ItemStack item)
    {
        try
        {
            inv.items.Remove(item);
        }catch { Debug.Log("item doesnt exist"); }
    }

    public static void RemoveItemFromInventory(Inventory inv, int i)
    {
        try
        {
            inv.items.RemoveAt(i);
        }
        catch { Debug.Log("item doesnt exist"); }
    }

    public static void DropItem(Inventory inv, ItemStack item, Vector2 position)
    {
        if(item.item.itemObject != null)
        {
            Debug.Log("Already dropped");
            return;
        }else
        {
            RemoveItemFromInventory(inv, item);
            InventoryHandler.SpawnItemObject(item);
        }
    }

    public static void DropItem(Inventory inv, int i, Vector2 position)
    {
        ItemStack item = inv.GetItemStack(i);

        if (item != null)
        {

            if (item.item.itemObject != null)
            {
                Debug.Log("Already dropped");
                return;
            }
            else
            {
                RemoveItemFromInventory(inv, item);
                InventoryHandler.SpawnItemObject(item);
            }
        }
        else
        {
            Debug.Log(i + " is out of index");
            return;
        }
    }

    public static void SpawnItemObject(ItemStack item)
    {
        RemoveItemObject(item);
        //link this item object to game Object


        GameObject obj = MonoBehaviour.Instantiate(GameObjectStorage.availablePrefabs[0]);
        obj.GetComponent<ItemObject>().showThisItem = item.item;
    }

    public static void SpawnItemObject(ItemStack item, Vector2 position)
    {
        RemoveItemObject(item);

        //link this item object to game Object


        GameObject obj = MonoBehaviour.Instantiate(GameObjectStorage.availablePrefabs[0]);
        //GameObject obj = MonoBehaviour.Instantiate();
        obj.transform.position = new Vector3(position.x, position.y, -1);
        obj.GetComponent<ItemObject>().showThisItem = item.item;
    }

    public static void RemoveItemObject(ItemStack item)
    {
        try
        {
            MonoBehaviour.Destroy(item.item.itemObject.gameObject);
        }
        catch { }
    }

    public static void AddToInventory(ItemStack item, Inventory inv)
    {
        RemoveItemObject(item);

        inv.AddItem(item);
    }
}
