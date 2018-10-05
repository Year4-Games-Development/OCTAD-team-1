using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        TwoWordCommandParser parser = new TwoWordCommandParser();

        CommandNounPair result = parser.Parse("pickup", "key");

        Debug.Log("result = " + result.ToString());
		
	}

}   
