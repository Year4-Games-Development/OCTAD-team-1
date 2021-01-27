using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
	public string name; 
	public string shortDesc;
    public Monster monster;

//	public List<Location> exits;

	public Location exitNorth;
	public Location exitSouth;
	public Location exitEast;
	public Location exitWest;

	public bool conditionMet1 = false;
	public bool conditionMet2 = false;
	public bool conditionMet3 = false;
	
	public bool firstVisit = true;
	public List<Item> pickupables;

    public NPC npc;
	// public int[] characters; 
	public string[] descriptions;

    public Location()
    {
        pickupables = new List<Item>();
        npc = null;
        monster = null;
		
    }

	public string GetName()
	{
		return name;
	}

	public string GetDescription()
	{
		Debug.Log(firstVisit + "");
        string s = "";
        // first visit show first description
        if (firstVisit)
		{
			s =  descriptions[0];
            firstVisit = false;
            
		}
		else
		{
			// choose random description
			int randomIndex = Random.Range(0, descriptions.Length);
			s = descriptions[randomIndex];
			

		}

        if (pickupables.Count > 0)
            for (int i = 0; i < pickupables.Count; i++)
                s += "\r\n(pickup) There is a " + pickupables[i].Name;
        if (npc != null)
            s += "\r\n(talk) " + npc.name + " is facing you";

        if (!name.Equals("In Ship") && !monster.amIDead())
            s += "\r\n(attack) You face " + monster.getName() + " and he has : " + monster.getFeature();

        return Util.ColorTextImportant("> " + s);

        

    }

    public bool CheckCompleted() 
	{


		return true;
	}

	public string GetExitDescriptions()
	{
		string exitList = "";
		int exitCount = 0;

		if (null != exitNorth)
		{
			exitList += "\n> there is an exit to the North";
			exitCount++;
		}

		if (null != exitSouth)
		{
			exitList += "\n> there is an exit to the South";
			exitCount++;
		}

		if (null != exitEast)
		{
			exitList += "\n> there is an exit to the East";
			exitCount++;
		}

		if (null != exitWest)
		{
			exitList += "\n> there is an exit to the West";
			exitCount++;
		}
		
		// string s = "There are " + exitCount + " exits. " + exitList;
		 return Util.ColorTextInteractible(exitList);
	}

	public string GetFullDescription()
	{
		return "\n" + GetDescription() + "\n" + GetExitDescriptions();
	}


}
