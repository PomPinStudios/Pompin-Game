using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    public Color nightLightColor;
    public Color dayLightColor = Color.white;
    public  AnimationCurve nightTimeCurve; 
    public float time;
    public float timeScale = 60f;
    public Text textTime;
    public Light2D globalLigth;
    float Hours 
    {
        get { return time /  3600f; }
    }

    float Minutes 
    {
        get { return time % 3600f / 60f; }
    }
    private int days;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * timeScale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        textTime.text = hh.ToString("00") + ":" + mm.ToString("00");
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLigth.color = c;
        if(time > secondsInDay){
            NextDay();
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1; 
    }
}
