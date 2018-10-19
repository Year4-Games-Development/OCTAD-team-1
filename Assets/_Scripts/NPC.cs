
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


    
    public NPC(int id, string name)
    {
        this.id = id;
        this.name = name;
        isFirstTimeTalking = true;
        this.inventory = new Inventory(1);
        intro = name + " : Hello, I'm " + name;

        questions = new List<string>();
        answers = new List<string>();

        //quests.Clear();
    }

    public void changeIntro(string newIntro)
    {
        if (newIntro.Contains("<name>"))
            newIntro.Replace("<name>", name);
        intro = name + " : "+newIntro;
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
    public string dialog(string question)
    {
        for (int i = 0; i < questions.Count; i++)
            if (questions[i].Equals(question))
                return name+" : "+answers[i];
        return "";
    }
}
