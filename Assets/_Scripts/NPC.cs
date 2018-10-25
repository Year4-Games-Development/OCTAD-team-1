
using System.Collections.Generic;

public class NPC {

    private int id;
    public string name;

    private bool isFirstTimeTalking;

    private Inventory inventory;

    private string _fullIntro;
    public string Intro { get; set; }
    private List<string> questions;
    private List<string> answers;
    private List<Quest> quests;


    
    public NPC(int id, string name)
    {
        this.id = id;
        this.name = name;
        isFirstTimeTalking = true;
        this.inventory = new Inventory(1);
        
        questions = new List<string>();
        answers = new List<string>();
        quests = new List<Quest>();

        UpdateIntro();

    }

    public void UpdateIntro()
    {
        _fullIntro = name + " : "+Intro;
        for (int i = 0; i < questions.Count; i++)
            _fullIntro += "\r\n(" + questions[i] + ")";
    }

    public string GetFullIntro()
    {
        return _fullIntro;
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

    public void addDialog(string question, string answer, Quest quest = null)
    {
        questions.Add(question);
        answers.Add(answer);
        quests.Add(quest);

        UpdateIntro();

    }
    public string dialog(string question, Player player)
    {
        for (int i = 0; i < questions.Count; i++)
            if (questions[i].Equals(question))
            {
                string answer = answers[i];
                if (quests[i] != null)
                {
                    player.quests.Add(quests[i]);
                    questions.RemoveAt(i);
                    answers.RemoveAt(i);
                    quests.RemoveAt(i);
                }
                UpdateIntro();
                return name + " : " + answer;
            }
        return "";
    }
}
