using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForce : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator aimAnimator;
    void Start()
    {
        aimAnimator = transform.GetComponent<Animator>();
    }

    void FirstFrame()
    {
        AimShootBow.shootForce = 0f;
    }
    void SecordFrame()
    {
        AimShootBow.shootForce = 7f;
    }

    void ThirdFrame()
    {
        AimShootBow.shootForce = 9f;
    }
    void FourthFrame()
    {
        AimShootBow.shootForce = 11f;
    }
    void FifthFrame()
    {
        AimShootBow.shootForce = 13f;
    }
}
