using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
	public enum Type
	{
		Start,
		Help,
		Unknown,
		North,
		South,
		East,
		West
	}
	
	public enum Command
	{
		Quit,
		Help,
		Look,
		North,
		South,
		East,
		West,
		Pickup,
		Drop,
		Unknown        
	}
	
	public enum Noun
	{
		Door,
		Key,
		Unknown
        
	}

	public static string Message(Type t)
	{
		switch (t)
		{
			case Type.Unknown:
				return "UNKNOWN command - please write something I understand";
			
			case Type.Help:
				return "Help:" +
						"\n    - Quit: give up" +
						"\n    - Help: see this help text" +
   						"\n    - Look: describe your current location";

			default:
				/*
				 * TODO: Generate some kind of error event ??
				 */
				return "";				
		}

	}


	public static string ColorText(string t, string color)
	{
		return "<color=" + color + ">" + t + "</color>";
	}
}
