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
    public float morningTime = 28800f;
    float Hours 
    {
        get { return time /  3600f; }
    }

    float Minutes 
    {
        get { return time % 3600f / 60f; }
    }
    public int days;
    
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
        time -= secondsInDay;
        days += 1; 
    }

    public void SkipTime(float seconds = 0, float minute = 0, float hours = 0)
    {
        float timeToSkip = seconds;
        timeToSkip += minute * 60f;
        timeToSkip += hours * 3600f;

        time += timeToSkip;

    }

    public void SkipToMorning()
    {
        float secondsToSkip = 0f;

        if(time > morningTime)
        {
            secondsToSkip += secondsInDay - time + morningTime;
        }
        else
        {
            secondsToSkip += morningTime - time;
        }

        SkipTime(secondsToSkip);
    }

}
