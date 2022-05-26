using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedArrowForce : MonoBehaviour
{
    public Animator aimAnimator;
    void Start()
    {
        aimAnimator = transform.GetComponent<Animator>();
    }

    void FirstFrame()
    {
        RangedEnemyAI.shootForce = 0f;
    }
    void SecordFrame()
    {
        RangedEnemyAI.shootForce = 5f;
    }

    void ThirdFrame()
    {
        RangedEnemyAI.shootForce = 7f;
    }
    void FourthFrame()
    {
        RangedEnemyAI.shootForce = 9f;
    }
    void FifthFrame()
    {
        RangedEnemyAI.shootForce = 11f;
    }
}
