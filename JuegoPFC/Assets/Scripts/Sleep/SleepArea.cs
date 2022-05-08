using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepArea : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other) {
        if(Input.GetButton("Interactive"))
        {
            Sleep sleep = other.GetComponent<Sleep>();
            if(sleep != null)
            {
                sleep.DoSleep();
            }
        }
    }
}
