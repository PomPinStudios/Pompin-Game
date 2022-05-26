using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject player;
    public ScreenTint screenTint;
    public DayTimeController timeController;
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }
    public GameObject playerPrefab;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        if (player == null)
        {
            player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        }
    }

    void Start()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = playerSpawnPoint.position;
        }
        catch (System.Exception)
        {
            if (player == null)
            {
                player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
            }
        }
    }

}

