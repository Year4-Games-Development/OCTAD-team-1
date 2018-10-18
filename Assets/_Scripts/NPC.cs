
using System.Collections.Generic;

public class NPC {

    private int id;
    public string name;

    private bool isFirstTimeTalking;

    private Inventory inventory;

    public string intro;
    private List<string> questions;
    private List<string> answers;

    //private List<Quest> quests;

    
    public NPC(int id, string name, string intro)
    {
        this.id = id;
        this.name = name;
        isFirstTimeTalking = true;
        this.inventory = new Inventory(1);
        this.intro = intro;
        questions = new List<string>();
        answers = new List<string>();

        //quests.Clear();
    }

    public void addItem(Item item)
    {
        this.inventory.AddItem(item);
    }

    public Item pickup(Player player)
    {
        player.inventory.AddItem(inventory.items[0]);
        return inventory.items[0];
    }

    public void giveItem(Player player, Item item)
    {
        if (this.inventory.isInInventory(item))
        {
            player.inventory.AddItem(item);
            this.inventory.Drop(item);
        }
    }

    public void recieveItem(Player player, Item item)
    {
        if (player.inventory.isInInventory(item))
        {
            this.inventory.AddItem(item);
            player.inventory.Drop(item);
        }
    }

    public void addDialog(string question, string answer)
    {
        questions.Add(question);
        answers.Add(answer);
    }

    public string dialog(string playerQuestion)
    {
        if(questions.Count == 0)
        {
            return "I have nothing to say !";
        }

        for(int i = 0; i < questions.Count; i++)
        {
            if (questions[i].Equals(playerQuestion))
                return answers[i];
        }

        return "Sorry, I don't understand what you said.";
    }

}
