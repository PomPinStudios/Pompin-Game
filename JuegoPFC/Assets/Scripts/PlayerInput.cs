using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalAxis { get; set; }
    public float verticalAxis { get; set; }
    [HideInInspector]public Vector2 lookDirection = new Vector2(0,-1f);

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        getlookingDirection();
    }

    private void getlookingDirection()
    {
        if(Input.GetAxisRaw("Horizontal")!= 0 || Input.GetAxisRaw("Vertical")!= 0)
        {
            lookDirection.x = horizontalAxis;
            lookDirection.y = verticalAxis;
        }
    }
}
