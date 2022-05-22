using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerHandler : MonoBehaviour
{
    public Window_QuestPointer window_QuestPointer;
    public GameObject pointerPosition;

    private Vector2 pointerTransformPosition;
    void Start()
    {
        pointerTransformPosition = new Vector2(pointerPosition.transform.position.x, pointerPosition.transform.position.y);
        window_QuestPointer.Show(pointerTransformPosition);


    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Camera.main.transform.position, pointerTransformPosition) < 11)
        {
            window_QuestPointer.Hide();
        }
    }
}
