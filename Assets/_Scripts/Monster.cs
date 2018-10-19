using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : ICombat
{
    private string name;
    private int _lifePoint;
    private int _armorPoint;
    private int _attackPoint;

    public Monster(string name, int life, int armor, int attack)
    {
        setArmorPoint(armor);
        setLifePoint(life);
        setName(name);
        setAttackPoint(attack);
    }

    public string getName()
    {
        return this.name;
    }

    public void setName(string value)
    {
        this.name = value;
    }

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


    public void receiveHealth(int amountHealth)
    {
        if(!amIDead())
        {
            setLifePoint(getLifePoint() + amountHealth);
        }
        else
        {
            //TODO
            // i am already dead !
        }
    }

    public bool amIDead()
    {
        if(getLifePoint() > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    public string getFeature()
    {
        string message = getArmorPoint() + " armor point , " + getLifePoint() + " hp, " + getAttackPoint() + " dammage point ";
        return message;
    }
}
