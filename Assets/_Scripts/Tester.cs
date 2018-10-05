using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        CommandParser parser = new CommandParser();

	    CommandAndOtherWords result = parser.Parse("pickup key");

        Debug.Log("result = " + result.ToString());
		
	}

}   
