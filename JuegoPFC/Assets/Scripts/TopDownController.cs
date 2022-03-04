using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public float walkSpeed;
    private float horizontal;
    private float vertical;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = playerInput.horizontalAxis;
        vertical = playerInput.verticalAxis;


        if (horizontal != 0 || vertical != 0)
        {
            SetXYAnimator();
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    private void FixedUpdate()
    {
        direction = new Vector2(horizontal, vertical).normalized;
        body.velocity = direction * walkSpeed;
    }

    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }
}
