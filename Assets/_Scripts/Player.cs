using System;
using System.Collections;
using System.Collections.Generic;


public class Player //: ICombat
{

    public Inventory inventory;
    private float hp;
    private float maxHp;
    private float oxygenLevel;
    public bool isDead;
    private float maxOxygenLevel;
    //    float hp;
    //    float maxHp;
    // float oxygenLevel;
    private int _lifePoint;
    private int _armorPoint;
    private int _attackPoint;

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
        oxygenLevel = 1.0f;
        inventory = new Inventory(10);
        setLifePoint(15);
        setArmorPoint(5);
        setAttackPoint(5);
        //	    hp = 10;
        //	    maxHp = 10;
        //      isDead = false;
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
      if(this.oxygenLevel >= 0.1f)
      {
          this.oxygenLevel -= amount;
      } else 
      {
          this.isDead = true;
      }
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

    
    
    // void takeDamage(float dmg)

    
    public int getLifePoint()
    {
        return this._lifePoint;
    }

    public void setLifePoint(int value)
    {
        this._lifePoint = value;
    }

    public int getArmorPoint()
    {
        return this._armorPoint;
    }

    public void setArmorPoint(int value)
    {
        this._armorPoint = value;
    }

    public int getAttackPoint()
    {
        return this._attackPoint;
    }

    // void recoverHp(float heal)

    public void setAttackPoint(int value)
    {
        this._attackPoint = value;
    }

    public void receiveDommage(int amountDammage)
    {
        if (!amIDead())
        {
            if (getArmorPoint() > 0)
            {
                if (getArmorPoint() - amountDammage >= 0)
                {
                    setArmorPoint(getArmorPoint() - amountDammage);
                }
                else if (getArmorPoint() - amountDammage < 0)
                {
                    int lifePointLost = amountDammage - getArmorPoint();
                    setArmorPoint(0);
                    setLifePoint(getLifePoint() - lifePointLost);
                }
            }
            else
            {
                setLifePoint(getLifePoint() - amountDammage);
            }
        }
        else
        {
            //TODO
            //the monster is already dead
        }
    }

    public bool amIDead()
    {
        if (getLifePoint() > 0)
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
        if (!amIDead())
        {
            setLifePoint(getLifePoint() + amountHealth);
        }
        else
        {
            //TODO
            // i am already dead !
        }
    }
    
    public string getFeature()
    {
        string message = getArmorPoint() + " armor point , " + getLifePoint() + " hp, " + getAttackPoint() + " dammage point ";
        return message;
    }

    /*
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
