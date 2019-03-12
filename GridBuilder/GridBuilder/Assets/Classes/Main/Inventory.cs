using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryComponents
{



}

public class Inventory : InventoryComponents
{

    public List<ItemStack> items = new List<ItemStack>();

    public Inventory()
    {

    }

    public Inventory(ItemStack stack)
    {
        items.Clear();
        items.Add(stack);
    }

    public Inventory(List<ItemStack> stack)
    {
        items.Clear();
        items = stack;
    }

    public Inventory(Item item)
    {
        items.Clear();
        items.Add(new ItemStack(item));
    }

    public ItemStack GetItemStack(int num)
    {
        try
        {
            return items[num];
        }
        catch
        {
            return new ItemStack();
        }
    }

    public void AddItem(Item item)
    {
        items.Add(new ItemStack(item));
    }

    public void AddItem(ItemStack item)
    {
        items.Add(item);
    }
}

public class ItemStack
{
    public Item item;
    public Color textColor = Color.black;
    public string flavorText = "";

    public ItemStack()
    {

    }

    public ItemStack(Item item)
    {
        this.item = item;
    }

    public ItemStack(Item item, Color textColor)
    {
        this.item = item;
        this.textColor = textColor;
    }

    public ItemStack(Item item, Color textColor, string flavor)
    {
        this.item = item;
        this.textColor = textColor;
        this.flavorText = flavor;
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

    public Item(int id, int amount, Vector2 spawnPos)
    {
        itemID = id;
        itemAmount = amount;

        
            InventoryHandler.SpawnItemObject(new ItemStack(this, Color.black, "Dit is de flavor text" ), spawnPos);
        
    }

    public Item(int id, int amount, string name, Vector2 spawnPos)
    {
        itemID = id;
        itemAmount = amount;
        itemName = name;

            InventoryHandler.SpawnItemObject(new ItemStack(this, Color.black, "Dit is de flavor text"), spawnPos);
        
    }

    public ItemObject setItemObject
    {
        get { return itemObject; }
        set { this.itemObject = value; }
    }

   

}
