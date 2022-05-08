using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            transform.parent.GetComponent<Transition>().InitiateTransition(other.transform);
        }
    }
}
