using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{

    DayTimeController dayTime;
    GameObject player;

    private void Awake() {
        dayTime = GameManager.instance.timeController;
        player = gameObject;
    }
    public void DoSleep(){
        StartCoroutine(SleepRoutine());
    }

    IEnumerator SleepRoutine()
    {

        ScreenTint screenTint = GameManager.instance.screenTint;

        screenTint.Activate();
        screenTint.Tint();

        yield return new WaitForSeconds(2f);

        // dayTime.SkipTime(hours: 8);

        dayTime.SkipToMorning();

        player.GetComponent<PlayerStats>().health = 100f;
        player.GetComponent<PlayerStats>().healthText.text = "100 / 100";

        screenTint.UnTint();

        yield return new WaitForSeconds(2f);
        screenTint.Desactivate();
        yield return null;
    }
}
