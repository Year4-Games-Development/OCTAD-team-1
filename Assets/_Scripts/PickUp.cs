using System;

enum Type
{
    RecoveryItem,
    Ressource,
    QuestObject
};

public class PickUp {

    int id;
    string name;
    string description;
    Type type;
    float exchangeValue;

	public PickUp () {
		
	}

    void selectType (Type newType)
    {
        type = newType;
    }
}
