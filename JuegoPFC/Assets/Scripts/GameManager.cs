using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject player;
    private Animator playerAnimator;
    public ScreenTint screenTint;
    public DayTimeController timeController;
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }
    public GameObject playerPrefab;

    public bool stop = false;

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
        if (ShouldLoadInventary.shouldLoadInventory)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            try
            {
                player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = playerSpawnPoint.position;
                playerAnimator = player.GetComponent<Animator>();

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


    public void estarQuieto()
    {
        stop = true;
    }

    public void NOestarQuieto()
    {
        stop = false;
    }

}

