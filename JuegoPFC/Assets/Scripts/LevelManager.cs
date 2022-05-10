using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnGame()
    {
        SceneManager.LoadScene("House");
        SceneManager.LoadScene("Essential", LoadSceneMode.Additive);
    }

    public void NewGame()
    {
        this.ReturnGame();
    }

    public void ExitTittle()
    {
        SceneManager.LoadScene("Tittle");
    }

    public void GoOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
