using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera cv;
    [HideInInspector] public GameObject player;

    void Start()
    {
        cv = GetComponent<CinemachineVirtualCamera>();
        Transform player = GameManager.instance.player.transform;
        cv.m_Follow = player;
    }

}
