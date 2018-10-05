using System;

public class Player {

    float hp;
    float maxHp;
    float oxygenLevel;
    bool isDead;

    List<int> inventory;
    List<int> quests;
    float amountOfMoney;   

	public Player() {
        hp = 10;
        maxHp = 10;
        oxygenLevel = 1.0;
        isDead = false;
	}

    void takeDamages(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            isDead = true;
    }

    void recoverHp(float heal)
    {
        hp += heal;
        if (hp > maxHp)
            hp = maxHp;
    }

    void addItem(int itemId)
    {
        inventory.Add(itemId);
    }

    void removeItem(int itemId)
    {
        inventory.Remove(itemId);
    }

    void addQuest(int questId)
    {
        quests.Add(questId);
    }

    void removeQuest(int questId)
    {
        quests.Remove(questId);
    }

    void earnMoney(float money)
    {
        amountOfMoney += money;
    }

    void looseMoney(float money)
    {
        amountOfMoney -= money;
    }

}
