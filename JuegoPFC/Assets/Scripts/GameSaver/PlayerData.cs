[System.Serializable]
public class PlayerData
{
    //stats
    public float health;
    public float maxHealth;
    public int damage;
    public float money;
    public float currExp;
    public float maxExp;
    public int level;
    public int currentStatPoints;
    public int armor;

    //DayTimeController
    public float time;
    public int days;

    //player
    public float[] position = new float[2];

    public PlayerData(TopDownController player, PlayerStats stats, DayTimeController DTcontroller)
    {
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;

        health = stats.health;
        maxHealth = stats.maxHealth;
        damage = stats.damage;
        money = stats.money;
        currExp = stats.currExp;
        maxExp = stats.maxExp;
        level = stats.level;
        currentStatPoints = stats.currentStatPoints;
        armor = stats.armor;

        time = DTcontroller.time;
        days = DTcontroller.days;
    }

}
