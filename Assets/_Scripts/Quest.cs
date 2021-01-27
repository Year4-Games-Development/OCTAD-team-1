using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

    public enum QuestStatus
    {
        New,
        Completed,
        Close
    }

    public QuestStatus Status;
    private Player _player;
    private Item _condition;
    private Item _reward;
    public string Description { get; set; }

    public Quest(Player player, Item condition,Item reward, string description)
    {
        Status = QuestStatus.New;
        _player = player;
        _condition = condition;
        _reward = reward;
        Description = description +"\r\n\tYou need a "+_condition.Name+" to complete the quest\r\n\tReward :"+_reward.Name;
    }

    public void UpdateStatus()
    {
        if(Status != QuestStatus.Close)
            if (_player.inventory.isInInventory(_condition))
            {
                Status = QuestStatus.Close;
                _player.inventory.Drop(_condition);
                _player.inventory.AddItem(_reward);
            }                
            else
                Status = QuestStatus.New;        
    }
}
