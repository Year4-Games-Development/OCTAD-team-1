using System;
using System.Collections;
using System.Collections.Generic;


public class Player //: ICombat
{

    public Inventory inventory;

    private int lifePoint;
    public int LifePoint {
        get {
            return lifePoint;
        }
        set {
            this.lifePoint = value;
            if (lifePoint > MaxLifePoint)
                lifePoint = MaxLifePoint;
        } }
    public int MaxLifePoint { get; set; }
    public int ArmorPoint { get; set; }


    public int AttackPoint { get; set; }

    private float oxygenLevel;
    public float MaxOxygenLevel { get; set; }
    
    public List<Quest> quests { get; set; }
    //float AmountOfMoney { get; set; }

    public Player()
    {
        MaxLifePoint = 15;
        LifePoint = MaxLifePoint;
        ArmorPoint = 5;

        AttackPoint = 5;

        oxygenLevel = 1.0f;
        MaxOxygenLevel = 5.0f; // ???

        //this.items = new List<Item>();
        this.inventory = new Inventory(10);

        quests = new List<Quest>();

        //AmountOfMoney = 0.0f;
    }



    public void addItem(Item item)
    {
        inventory.AddItem(item);
        UpdateAllQuests();
    }

    public void removeItem(Item item)
    {
        inventory.Drop(item);
    }

    public void OxygenTickDown(float amount)
    {
      if(this.oxygenLevel >= 0.1f)
      {
          this.oxygenLevel -= amount;
      }
    }

    public float GetOxygenLevel()
    {
        return this.oxygenLevel * 100;
    }


    public string GetStatus()
    {
        return   "Oxygen : " + Math.Floor(this.GetOxygenLevel()).ToString() + "%" 
            +"\r\nHP     : " + LifePoint + "/"+MaxLifePoint
            +"\r\nArmor  : " + ArmorPoint
            +"\r\nDamage : " + AttackPoint; 
    }

    public void ReplenishOxygen()
    {
        this.oxygenLevel = 1.0f;
    }



    public void receiveDommage(int amountDammage)
    {
        if (!isDead())
        {
            if (ArmorPoint > 0)
            {
                if (ArmorPoint - amountDammage >= 0)
                {
                    ArmorPoint -= amountDammage;
                }
                else if (ArmorPoint - amountDammage < 0)
                {
                    int lifePointLost = amountDammage - ArmorPoint;
                    ArmorPoint = 0;
                    LifePoint = LifePoint - lifePointLost;
                }
            }
            else
            {
                LifePoint -= amountDammage;
            }
        }
        else
        {
            //TODO
            //the monster is already dead
        }
    }

    public bool isDead()
    {
        if (LifePoint > 0 && this.oxygenLevel >= 0.1f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void receiveHealth(int amountHealth)
    {
        if (!isDead())
        {
            LifePoint += amountHealth;
        }
        else
        {
            //TODO
            // i am already dead !
        }
    }

    public void UpdateAllQuests()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            quests[i].UpdateStatus();
            if (quests[i].Status == Quest.QuestStatus.Close)
                quests.RemoveAt(i);
        }
    }
    
}
