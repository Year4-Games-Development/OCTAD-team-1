﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
	private Location startInShip;

	private List<Location> locations;
    private List<Item> items;

    public Ship ship;
	public Location GetStartLocation()
	{
		return startInShip;
	}

	
	public Map(Player player) {        
		ship = new Ship(3);
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


        //items
        RegularItem todolist = new RegularItem(1, "todolist", ship.GetStatus());
        Debug.Log("ship : " + ship.GetStatus());
        RegularItem flower = new RegularItem(2, "flower", "It's a beautiful flower");
        ConsumableItem potion = new ConsumableItem(3, "potion", "recover 5 hp", 5, player);


        items = new List<Item>();
        items.Add(todolist);
        items.Add(potion);

        //quests
        Quest bobsFlower = new Quest(player, flower, potion, "Bob wants a flower for his wife.");

        //npcs
        NPC bob = new NPC(1, "Bob");
        bob.Intro = "Hi foreigner ! I'm Bob.";
        bob.addDialog("info", "This town is a good place if you want to find some scraps."
            + "\r\nBe careful, there is an evil citizen !");
        bob.addDialog("request", "Today it's my wife birthday. Can you bring me some flower ?", bobsFlower);



        //Item todoList

        startInShip.name = "In Ship";
		// ship.SetStatus(3);
		Debug.Log(ship.GetStatus());
		startInShip.exitSouth = outsideShip;
		startInShip.pickupables = new List<Item>();
        
        startInShip.pickupables.Add(todolist);

        startInShip.descriptions = new string[]
		{
			"This is your ship, it looks damaged. Maybe there is something you can do to repair it.\nYou hear a buzz and notice your computer has printed out a piece of paper before shutting off completely.", 
			"If somehow i could find out what's wrong with this ship",
			"There is no way i am getting off this planet right now."
		};
		startInShip.shortDesc = "This is your ship.";
	
		outsideShip.name = "Outside Ship";
		outsideShip.exitNorth = startInShip;
		outsideShip.exitSouth = cave;
		outsideShip.exitWest = forest;
		outsideShip.exitEast = town;
		outsideShip.pickupables = new List<Item>();		
		outsideShip.descriptions = new string[]
		{
			"You are outside your ship."
		};
		outsideShip.shortDesc = "The land around you is barren. Maybe you should explore.";
        outsideShip.monster = new Monster("Evil Guard", 10, 0, 2);

        cave.name = "Cave";
		cave.exitNorth = outsideShip;
		cave.pickupables = new List<Item>();
		cave.descriptions = new string[]
		{
			"You come across a dark cave. You can't see anything without a light."
		};
		cave.shortDesc = "";
        cave.monster = new Monster("Cave troll", 13, 1, 3);


        forest.name = "Forest";
		forest.exitEast = outsideShip;
		forest.pickupables = new List<Item>();
		forest.descriptions = new string[]
		{
			"You arrive at a seeminly endless forest. It doesnt seem save to traverse unprepared."
		};
		forest.shortDesc = "";
        forest.pickupables.Add(flower);
        forest.monster = new Monster("Enchanted tree", 7, 0, 1);

        town.name = "Town";
		town.exitWest = outsideShip;
		town.exitNorth = market;
		town.exitSouth = scrapyard;
		town.exitEast = tavern;
		town.pickupables = new List<Item>();
        town.descriptions = new string[]
		{
			"You reach a small, but busy town."
		};
        town.shortDesc = "";
        town.npc = bob;
        town.shortDesc = "";
        town.monster = new Monster("Evil Citizen", 10, 0, 3);

        ////

        ////


        market.name = "Market";
		market.exitSouth = town;
		market.pickupables = new List<Item>();
		market.descriptions = new string[]
		{
			"You arrive at a small town market. You see 4 market stalls."
		};
		market.shortDesc = "";
        market.monster = new Monster("Mad Seller", 15, 0, 1);


        tavern.name = "Tavern";
		tavern.exitWest = town;
		tavern.pickupables = new List<Item>();
		tavern.descriptions = new string[]
		{
			"You step inside the taven."
		};
		tavern.shortDesc = "";
        tavern.monster = new Monster("Cyclope", 10, 0, 6);


        scrapyard.name = "Scrapyard";
		scrapyard.exitNorth = town;
		scrapyard.pickupables = new List<Item>();
		scrapyard.descriptions = new string[]
		{
			"You Walk into the scarpyard."
		};
		scrapyard.shortDesc = "";
        scrapyard.monster = new Monster("scrap dealer", 12, 0, 4);
        


    }



}
