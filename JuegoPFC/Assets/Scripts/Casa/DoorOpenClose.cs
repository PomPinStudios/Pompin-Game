using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject closeDoor;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            OpenDoor();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CloseDoor();
        }
    }

    private void CloseDoor()
    {
        closeDoor.SetActive(true);
        openDoor.SetActive(false);
    }

    private void OpenDoor()
    {
        closeDoor.SetActive(false);
        openDoor.SetActive(true);
    }


}
