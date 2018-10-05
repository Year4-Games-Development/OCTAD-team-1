using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{

	public int id;
//	public List<Location> exits;

	public Location exitNorth;
	public Location exitSouth;
	
	public bool firstVisit = true;
	public List<PickUp> pickupables;
	// public int[] characters; 
	public string[] descriptions; 
	public string name; 
	public string shortDesc; 


}
