using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
	public enum Type
	{
		Start,
		Help,
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
				       "\n    - Help: see this help text";
			
			case Type.Start:
				return "OCTAD: Your Octad spaceship has crashed!" +
				       "\n    - try not to die" +
				       "\n    - hint: oxygen is a handy thing when you're on a non-Earth-like planet";
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
