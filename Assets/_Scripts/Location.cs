using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
	public string name; 
	public string shortDesc;

//	public List<Location> exits;

	public Location exitNorth;
	public Location exitSouth;

	public Location exitEast;

	public Location exitWest;
	
	public bool firstVisit = true;
	public List<PickUp> pickupables;
	// public int[] characters; 
	public string[] descriptions;

	public string GetName()
	{
		return name;
	}

	public string GetDescription()
	{
		// first visit show first description
		if (firstVisit)
		{
			return descriptions[0];
		}
		else
		{
			// choose random description
			int randomIndex = Random.Range(0, descriptions.Length);
			return descriptions[randomIndex];
		}
	}

	public string GetExitDescriptions()
	{
		string exitList = "";
		int exitCount = 0;

		if (null != exitNorth)
		{
			exitList += "\n there is an exit to the North";
			exitCount++;
		}

		if (null != exitSouth)
		{
			exitList += "\n there is an exit to the South";
			exitCount++;
		}

		if (null != exitEast)
		{
			exitList += "\n there is an exit to the East";
			exitCount++;
		}

		if (null != exitWest)
		{
			exitList += "\n there is an exit to the West";
			exitCount++;
		}
		return "There are " + exitCount + " exits. " + exitList;
	}

	public string GetFullDescription()
	{
		return GetDescription() + "\n" + GetExitDescriptions();
	}


}
