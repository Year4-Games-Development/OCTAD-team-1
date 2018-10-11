using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{

    private int size;
    private List<Item> items;

    public Inventory(int size)
    {
        this.size = size;
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void Drop(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (id == items[i].id)
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
            result += items[i].name + " ";
        }
        return result;
    }






}
