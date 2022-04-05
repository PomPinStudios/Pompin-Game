using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_QuestPointer : MonoBehaviour
{
    public Sprite arrowSprite;
    public Sprite crossSprite;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    private Image pointerImage;

    private void Awake() {
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        pointerImage = transform.Find("Pointer").GetComponent<Image>();
        // targetPosition = new Vector2(-70, 50);
        // Hide();
    }

    private void Update() {
        float borderSize = 100f;

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;
        // Debug.Log(targetPositionScreenPoint);
        if(isOffScreen){
            RotatePointer();
            pointerImage.sprite = arrowSprite;
            pointerRectTransform.sizeDelta = new Vector2(60,40);
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if(cappedTargetScreenPosition.x <= borderSize )
            {
                cappedTargetScreenPosition.x = borderSize;
            }
            if(cappedTargetScreenPosition.x >= Screen.width - borderSize)
            {
                cappedTargetScreenPosition.x = Screen.width - borderSize;
            }
            if(cappedTargetScreenPosition.y <= borderSize )
            {
                cappedTargetScreenPosition.y = borderSize;
            }
            if(cappedTargetScreenPosition.y >= Screen.height - borderSize)
            {
                cappedTargetScreenPosition.y = Screen.height - borderSize;    
            }

            // Vector3 pointerWorldPosition = Camera.main.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = cappedTargetScreenPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        }else{
            pointerImage.sprite = crossSprite;
            pointerRectTransform.sizeDelta = new Vector2(60,60);
            Vector3 pointerWorldPosition = Camera.main.ScreenToViewportPoint(targetPositionScreenPoint);
            pointerRectTransform.position = targetPositionScreenPoint;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
            pointerRectTransform.localEulerAngles = Vector3.zero;

        }

        

    } 

    private void RotatePointer()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }

    public void Show(Vector3 targetPosition){
        gameObject.SetActive(true);
        this.targetPosition = targetPosition;
    }
}
