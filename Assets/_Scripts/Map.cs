using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
	private Location startInShip;

	private List<Location> locations;
	
	public Location GetStartLocation()
	{
		return startInShip;
	}

	
	public Map() {
		startInShip =  new Location();
		Location outsideShip = new Location();
		Location cave = new Location();
		Location forest = new Location(); 
		Location town = new Location();
		Location tavern = new Location();
		Location scrapyard = new Location();
		Location market = new Location();

		locations = new List<Location>();
		locations.Add(startInShip);
		locations.Add(outsideShip);
		locations.Add(cave);
		locations.Add(forest);
		locations.Add(town);
		locations.Add(tavern);
		locations.Add(scrapyard);
		locations.Add(market);
		

		startInShip.name = "In Ship";
		startInShip.exitSouth = outsideShip;
		startInShip.pickupables = new List<PickUp>();
		startInShip.descriptions = new string[]
		{
			"This is your ship, it looks damaged.", 
			"If somehow i could find out what's wrong with this ship",
			"There is no way i am getting off this planet right now."
		};
		startInShip.shortDesc = "This is your ship.";
			

		outsideShip.name = "Outside Ship";
		outsideShip.exitNorth = startInShip;
		outsideShip.exitSouth = cave;
		outsideShip.exitWest = forest;
		outsideShip.exitEast = town;
		outsideShip.pickupables = new List<PickUp>();
		outsideShip.descriptions = new string[]
		{
			"You are outside your ship."
		};
		outsideShip.shortDesc = "The land around you is barren. Maybe you should explore.";


		cave.name = "Cave";
		cave.exitNorth = outsideShip;
		cave.pickupables = new List<PickUp>();
		cave.descriptions = new string[]
		{
			"You come across a dark cave. You can't see anything without a light."
		};
		cave.shortDesc = "";


		forest.name = "Forest";
		forest.exitEast = outsideShip;
		forest.pickupables = new List<PickUp>();
		forest.descriptions = new string[]
		{
			"You arrive at a seeminly endless forest. It doesnt seem save to traverse unprepared."
		};
		forest.shortDesc = "";

		town.name = "Town";
		town.exitWest = outsideShip;
		town.exitNorth = market;
		town.exitSouth = scrapyard;
		town.exitEast = tavern;
		town.pickupables = new List<PickUp>();
		town.descriptions = new string[]
		{
			"You reach a small, but busy town."
		};
		town.shortDesc = "";


		market.name = "Market";
		market.exitSouth = town;
		market.pickupables = new List<PickUp>();
		market.descriptions = new string[]
		{
			"You arrive at a small town market. You see 4 market stalls."
		};
		market.shortDesc = "";


		tavern.name = "Tavern";
		tavern.exitWest = town;
		tavern.pickupables = new List<PickUp>();
		tavern.descriptions = new string[]
		{
			"You step inside the taven."
		};
		tavern.shortDesc = "";


		scrapyard.name = "Scrapyard";
		scrapyard.exitNorth = town;
		scrapyard.pickupables = new List<PickUp>();
		scrapyard.descriptions = new string[]
		{
			"You Walk into the scarpyard."
		};
		scrapyard.shortDesc = "";
		/*
		//In ship
			new Location() {
				id = 1,
				name = "In Ship", 
				exits = new int[]{2},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"This is your ship, it looks damaged.", "If somehow i could find out what's wrong with this ship", "There is no way i am getting off this planet right now."},
				shortDesc = "This is your ship."


			},
			//Outshide Ship
			new Location() {
				id = 2,
				name = "Outside Ship", 
				exits = new int[]{1,3,4,5},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"You are outside your ship."},
				shortDesc = "The land around you is barren. Maybe you should explore."

			}, 

			//Town
			new Location() {
				id = 3,
				name = "Town", 
				exits = new int[]{2,6,7,8},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"You arrived at the town.", ""},
				shortDesc = "The town is loud and busy"

			}, 

			//Tavern
			new Location() {
				id = 1,
				name = "Tavern", 
				exits = new int[]{3,6},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"You enter the tavern."},
				shortDesc = "There is a bar maid behind the counter"

			}, 

			//Market
			new Location() {
				id = 6,
				name = "Market", 
				exits = new int[]{3,7},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"You enter the market"},
				shortDesc = "There are four market stalls"

			}, 

			//Scrapyard
			new Location() {
				id = 8,
				name = "Scrapyard", 
				exits = new int[]{3,7},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"You enter the scrapyard"},
				shortDesc = "There is a small shack. maybe you should go inside"

			}, 

			//Forest
			new Location() {
				id = 5,
				name = "Forest", 
				exits = new int[]{2},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"You step into the forest."},
				shortDesc = "The forest seems eerie."

			}, 
	
			//Cave
			new Location() {
				id = 4,
				name = "Cave", 
				exits = new int[]{2},
				firstVisit = false,
				pickupables = new List<Pickup>(),
				descriptions = new string[]{"You enter the cave"},
				shortDesc = "It is pitch dark. perhaps you could use a light"

			}, 
		};
		
		*/
		
		
	}



}
