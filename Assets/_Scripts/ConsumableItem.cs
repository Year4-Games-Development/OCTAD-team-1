using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item {
    private int _id;
    private string _name;
    private string _description;

    private int _effect;
    private Player _player;

    public ConsumableItem(int id, string name, string description, int effect, Player player)
    {
        _id = id;
        _name = name;
        _description = description;

        _effect = effect;
        _player = player;
    }

    public int id
    {
        get { return _id; }
        set { _id = value; }
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
        _player.LifePoint +=  _effect;
        _player.inventory.Drop(this);
        return "You recover "+_effect+" HP";
    }
}
