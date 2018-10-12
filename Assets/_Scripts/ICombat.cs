using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICombat
{
    int getLifePoint();
    void setLifePoint(int value);
    int getArmorPoint();
    void setArmorPoint(int value);
    int getAttackPoint();
    void setAttackPoint(int value);

    void receiveDommage(int amountDammage);
    void receiveHealth(int amountHealth);
    bool amIDead();
    string getFeature();
}
