using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverController : MonoBehaviour
{

    public GameObject player;
    public GameObject gameManager;

    Inventory inventory;
    InventorySingleton inventorySingleton;
    // Start is called before the first frame update
    void Start()
    {
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GuardarDatos()
    {
        SaveManager.SavePlayerData(
                player.GetComponent<TopDownController>(),
                player.GetComponent<PlayerStats>(),
                gameManager.GetComponent<DayTimeController>()
                );

        GameData.instance.ClearAllDataList();
        inventory.InventoryToData();
        GameData.instance.Save();

        Debug.Log("Datos Guardados");

    }


    public void CargarDatos()
    {
        Debug.Log("primera vez");
        PlayerData playerData = SaveManager.LoadPlayerData();
        Debug.Log(playerData.position[0] + " " + playerData.position[1]);
        player.transform.position = new Vector3(playerData.position[0], playerData.position[1], 0);

        player.GetComponent<PlayerStats>().health = playerData.health;
        player.GetComponent<PlayerStats>().maxHealth = playerData.maxHealth;
        player.GetComponent<PlayerStats>().damage = playerData.damage;
        player.GetComponent<PlayerStats>().money = playerData.money;
        player.GetComponent<PlayerStats>().currExp = playerData.currExp;
        player.GetComponent<PlayerStats>().maxExp = playerData.maxExp;
        player.GetComponent<PlayerStats>().level = playerData.level;
        player.GetComponent<PlayerStats>().currentStatPoints = playerData.currentStatPoints;
        player.GetComponent<PlayerStats>().armor = playerData.armor;

        gameManager.GetComponent<DayTimeController>().time = playerData.time;
        gameManager.GetComponent<DayTimeController>().days = playerData.days;

        inventory.DataToInventory();
        inventory.cargando = true;
        GameData.instance.Load();


        // Debug.Log("Datos Cargados");
    }
}
