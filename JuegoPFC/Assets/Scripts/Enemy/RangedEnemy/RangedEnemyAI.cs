using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3f;

    [Header("Attack")]
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public Transform target;

    //Arco
    public GameObject arrow;
    [SerializeField] public static float shootForce;

    public Transform aimTransform;
    public Transform bowTransform;
    public Animator aimAnimator;
    private Animator playerAnimator;
    public int horizontal, vertical;

    void Start()
    {
        playerAnimator = this.transform.GetComponent<Animator>();
        shootForce = 15;

    }

    void Update()
    {
        if (target != null)
        {
            AimingBow(target.position);
            ShootArrow(target.position);
            // float step = speed * Time.deltaTime;
            // transform.position = Vector2.MoveTowards(transform.position, target.position, step); //Mueve al player, cambiar por disparar flecha
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // que siga atacando
    }

    void AimingBow(Vector3 playerPosition)
    {
        Vector3 aimDirection = (playerPosition - aimTransform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);


        // playerAnimator.SetFloat("AimX", horizontal);
        // playerAnimator.SetFloat("AimY", vertical);
    }

    void ShootArrow(Vector3 playerPosition)
    {
        // shootForce = Random.Range(2f, 15f);
        Vector3 shootingDirection = (playerPosition - transform.position).normalized;
        shootingDirection.Normalize();
        // if (Input.GetButtonDown("FireArrow"))
        // {
        aimAnimator.SetBool("Aim", true);
        aimAnimator.SetBool("Shoot", false);
        //     playerAnimator.SetBool("AimIdle", true);
        // }

        if (attackSpeed <= canAttack)
        {
            Debug.Log("Primer if");
            if (shootForce != 0f)
            {
                Debug.Log("Crear flecha");
                GameObject shootArrow = Instantiate(arrow, bowTransform.position, Quaternion.identity);
                shootArrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * shootForce * 2;
                shootArrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                Destroy(shootArrow, 10.0f);
                canAttack = 0f;
            }

            aimAnimator.SetBool("Shoot", true);
            aimAnimator.SetBool("Aim", false);
            // playerAnimator.SetBool("AimIdle", false);

            shootForce = 0f;
        }
        else
        {
            canAttack += Time.deltaTime;
        }
    }

}
