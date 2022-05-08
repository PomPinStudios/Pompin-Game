using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    [SerializeField] ScreenTint screenTint;
    [SerializeField] CameraConfiner cameraConfiner;
    string currentScene;
    AsyncOperation unload;
    AsyncOperation load;
    
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void InitSwitchScene(string toScene, Vector3 targerPosition)
    {
        StartCoroutine(Transition(toScene, targerPosition));
    }


    IEnumerator Transition(string toScene, Vector3 targerPosition)
    {
        screenTint.Activate();
        screenTint.Tint();

        yield return new WaitForSeconds(1f / screenTint.speed + 0.1f);

        switchScene(toScene, targerPosition);

        while (load != null & unload != null)
        {
            if (load.isDone)
            {
                load = null;
            }

            if (unload.isDone)
            {
                unload = null;
            }
            yield return new WaitForSeconds(0.1f);
        }

        cameraConfiner.UpdateBounds();
        screenTint.UnTint();
        screenTint.Desactivate();
    }

    public void switchScene(string toScene, Vector3 targetPosition)
    {
        load = SceneManager.LoadSceneAsync(toScene, LoadSceneMode.Additive);
        unload = SceneManager.UnloadSceneAsync(currentScene);
        currentScene = toScene;
        
        Transform playerTransform = GameManager.instance.player.transform;

        Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();       
        currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(playerTransform, targetPosition - playerTransform.position);

        playerTransform.position = new Vector3(targetPosition.x, targetPosition.y, playerTransform.position.z);

        // GameManager.instance.player.transform.position = targerPosition;
    }
}
