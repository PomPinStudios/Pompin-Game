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

    //Dash
    public float dashSpeed;
    public float dashCooldown;
    private float runningDashCooldown;
    public float dashDuration;
    private float runningDashDuration;
    private bool dashUp;
    public AudioSource clip;

    Vector2 direction;

    //Attack
    private Attacker attacker;
    PlayerStats playerStats;
    PlayerSingleton playerSingleton;


    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();

        playerSingleton = PlayerSingleton.instance;
        playerStats = playerSingleton.GetComponent<PlayerStats>();

        animator.SetBool("Bowing", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.stop)
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

        //Attack
        if (Input.GetButtonDown("Fire1") && AttackUnlocker.isUnlocked)
        {
            //animator.SetTrigger("Attack");
            animator.SetBool("Attacking", true);
        }
    }

    private void FixedUpdate()
    {
        if(!GameManager.instance.stop)
        {
            direction = new Vector2(horizontal, vertical).normalized;
            body.velocity = direction * walkSpeed;

            //Dash
            //Establece la duracion del dash
            if (runningDashDuration > 0)
            {
                runningDashDuration -= Time.deltaTime;
                body.velocity = direction * dashSpeed;
            }
            //Establece el cooldown del dash
            if (runningDashCooldown > 0)
            {
                runningDashCooldown -= Time.deltaTime;
            }
            else
            {
                dashUp = true;
            }
            //Activa la duracion del dash si el cooldown ha acabado
            if (Input.GetAxis("Dash") == 1 && dashUp)
            {
                clip.Play();
                runningDashCooldown = dashCooldown;
                runningDashDuration = dashDuration;
                dashUp = false;
            }

        }
        else
        {
           body.velocity = new Vector2(0,0); 
        }
    }

    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }

    void AttackController()
    {
        attacker.Attack(playerInput.lookDirection, playerStats.damage);
        animator.SetBool("Attacking", false);
    }

    
}
