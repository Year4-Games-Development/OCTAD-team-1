using System;
using System.Collections;
using System.Collections.Generic;


public class Player
{

    public Inventory inventory;
    private float hp;
    private float maxHp;
    private float oxygenLevel;
    private bool isDead;
    private float maxOxygenLevel;
    /*
     * can infer from oxygen level ...
    bool isDead;
     */

    List<Item> items;
    List<int> quests;
    float amountOfMoney;

    public Player()
    {
        this.items = new List<Item>();
        this.oxygenLevel = 1.0f;
        this.inventory = new Inventory(10);
        this.hp = 1.0f;
        this.maxHp = 1.0f;
        this.isDead = false;
        this.maxOxygenLevel = 5.0f;
    }



    public void addItem(Item item)
    {
        inventory.AddItem(item);
        //items.Add(item);
    }

    public void removeItem(Item item)
    {
        items.Remove(item);
    }

    public void OxygenTickDown(float amount)
    {
        this.oxygenLevel -= amount;
    }

    public float GetOxygenLevel()
    {
        return this.oxygenLevel * 100;
    }

    public float GetHp()
    {
        return this.hp * 100;
    }

    public string GetStatus()
    {
        return "Oxygen: " + Math.Floor(this.GetOxygenLevel()).ToString() + "%" +  "\n" + "HP: " + Math.Floor(GetHp()).ToString() + "%"; 
    }

    public void ReplenishOxygen()
    {
        this.oxygenLevel = 1.0f;
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
