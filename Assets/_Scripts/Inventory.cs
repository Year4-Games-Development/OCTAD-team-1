using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{

    private int size;

    public List<Item> items;

    public Inventory(int size)
    {
        this.size = size;
        items = new List<Item>();
        // items.Add(new Item(1,"To Do List"));
        // items.Add(new Item(2,"Wrench"));

    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }


    public void Drop(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (item.id == items[i].id)

            {
                items.RemoveAt(i);
                return;
            }
        }
    }

    public string ShowInventory()
    {
        if(items.Count < 1)
            return "Your inverntory is empty";

        string result = "";

        for (int i = 0; i < items.Count; i++)
        {
            result += items[i].name + "\n";
        }
        return result;
    }


    public bool isInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (item.name == items[i].name)
                return true;
        return false;
    }






}
