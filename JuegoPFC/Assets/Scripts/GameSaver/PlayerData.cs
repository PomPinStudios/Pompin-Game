[System.Serializable]
public class PlayerData
{
   public float health;
   public float[] position = new float[2];

    public PlayerData(TopDownController player)
    {
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }

}
