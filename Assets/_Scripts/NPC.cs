
public class NPC {

    private int id;
    private string name;

    private bool isFirstTimeTalking;

    private Inventory inventory;

    //private List<Quest> quests;

    
    public NPC(int id, string name)
    {
        this.id = id;
        this.name = name;
        isFirstTimeTalking = true;
        this.inventory = new Inventory(1);

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
}
