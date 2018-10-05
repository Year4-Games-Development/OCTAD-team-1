using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location {

	public Location() {

	}

	public int id;
	public int[] exits;
	public bool firstVisit = true;
	public List<Pickup> pickupables;
	// public int[] characters; 
	public string[] descriptions; 
	public string name; 
	public string shortDesc; 


}
