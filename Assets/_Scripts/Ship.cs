public class Ship
{
    private float status;
    private string[] tasks;

    public Ship(int status)
    {
        this.SetStatus(status);
        
    }

    public void SetStatus(int status)
    {
        
        switch(status)
        {
            case 3: tasks = new string[]{"Fix reactor", "Get new star map", "Repair life suport system"};
            break;
            case 2: tasks = new string[]{"Get new star map", "Repair life suport system"};
            break;
            case 1: tasks = new string[]{"Repair life suport system"};
            break;
            default: tasks = new string[]{"Ship is fully repaired"};
            break;
        }
        
    }

    public string GetStatus()
    {
        string message = "\n";

        for(int i = 0; i < this.tasks.Length; i++)
        {
            message += "\n - " + this.tasks[i];
        }
        return message;
    }  
}
