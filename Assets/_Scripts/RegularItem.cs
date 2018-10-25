using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularItem : Item {
    private int _id;
    private string _name;
    private string _description;

    public RegularItem(int id, string name, string description)
    {
        _id = id;
        _name = name;
        _description = description;
    }

    public int id
    {
        get { return _id;}
        set { _id = value;}
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public string use()
    {
        return Description;
    }



}
