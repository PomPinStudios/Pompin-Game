using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject holder;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else 
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        holder.GetComponent<AimShootBow>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        holder.GetComponent<AimShootBow>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
