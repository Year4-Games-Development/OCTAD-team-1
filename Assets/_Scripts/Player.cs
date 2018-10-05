using System;
using System.Collections;
using System.Collections.Generic;


public class Player {

//    float hp;
//    float maxHp;
    float oxygenLevel;
    
    /*
     * can infer from oxygen level ...
    bool isDead;
     */

    List<PickUp> items;
//    List<int> quests;
    float amountOfMoney;  

	public Player() {
        oxygenLevel = 1.0f;

//	    hp = 10;
//	    maxHp = 10;
//      isDead = false;
	}



    void addItem(PickUp item)
    {
        items.Add(item);
    }

    void removeItem(PickUp item)
    {
        items.Remove(item);
    }

    /*
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
*/
}
