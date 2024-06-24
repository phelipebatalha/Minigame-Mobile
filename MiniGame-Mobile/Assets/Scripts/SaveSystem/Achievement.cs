[System.Serializable]
public class Achievement
{
    public string name;
    public string description;
    public bool unlocked;

    public Achievement(string name, string description)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
    }

    public void Unlock()
    {
        unlocked = true;
    }
}