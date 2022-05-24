using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TransitionType
{
    Warp,
    Scene
}
public class Transition : MonoBehaviour
{
    [SerializeField] TransitionType transitionType;
    [SerializeField] string sceneNameToTransition;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] Collider2D confiner;
    
    CameraConfiner cameraConfiner;
    Transform destination;

    public AudioSource clip;


    // Start is called before the first frame update
    void Start()
    {
        if(confiner != null)
        {
            cameraConfiner = FindObjectOfType<CameraConfiner>();
        }
        destination = transform.GetChild(1);
    }

    public void InitiateTransition(Transform toTransition)
    {
        switch(transitionType)
        {
            case TransitionType.Warp:
                clip.Play();
                StartCoroutine(Tint(toTransition));
                break;
            case TransitionType.Scene:
                GameSceneManager.instance.InitSwitchScene(sceneNameToTransition, targetPosition);
                break;
        }
    }
    

    IEnumerator Tint(Transform toTransition)
    {

        ScreenTint screenTint = GameManager.instance.screenTint;

        screenTint.Activate();
        screenTint.Tint();
        yield return new WaitForSeconds(0.6f);
        Cinemachine.CinemachineBrain currentCamera = Camera.main.GetComponent<Cinemachine.CinemachineBrain>();
        currentCamera.ActiveVirtualCamera.OnTargetObjectWarped(toTransition, destination.position - toTransition.position);
        if(cameraConfiner != null)
        {
            cameraConfiner.UpdateBounds(confiner);
        }
        toTransition.position = new Vector3(destination.position.x, destination.position.y, toTransition.position.z);

        screenTint.UnTint();

        yield return new WaitForSeconds(0.3f);
        screenTint.Desactivate();
        yield return null;
    }


}
