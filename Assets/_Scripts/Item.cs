using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item  {

	int id { get; set; }
	string Name { get; set; }
    string Description { get; set; }
    string use();

}
