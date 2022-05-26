using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimShootBow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject crossHair;
    [SerializeField] public static float shootForce;

    private Transform aimTransform;
    private Animator aimAnimator;
    private Animator playerAnimator;
    public int horizontal, vertical;
    public Text arrowCountText;
    public static int playerArrows;

    // Start is called before the first frame update
    void Start()
    {
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        playerAnimator = transform.root.GetComponent<Animator>();
        shootForce = 15;

        playerArrows = 30;
        arrowCountText.text = "x " + playerArrows.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        AimingBow();

        ShootArrow();
    }

    void AimingBow()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        if (angle < 90 && angle > 0)
        {
            if (angle < 90 && angle > 60)
            {
                horizontal = 0;
                vertical = 1;
            }
            if (angle < 60 && angle > 30)
            {
                horizontal = 1;
                vertical = 1;
            }
            if (angle < 30 && angle > 0)
            {
                horizontal = 1;
                vertical = 0;
            }
        }
        if (angle > 90 && angle < 180)
        {
            if (angle > 90 && angle < 120)
            {
                horizontal = 0;
                vertical = 1;
            }
            if (angle > 120 && angle < 150)
            {
                horizontal = -1;
                vertical = 1;
            }
            if (angle > 150 && angle < 180)
            {
                horizontal = -1;
                vertical = 0;
            }
        }
        if (angle < -90 && angle > -180)
        {
            if (angle > -180 && angle < -150)
            {
                horizontal = -1;
                vertical = 0;
            }
            if (angle > -150 && angle < -120)
            {
                horizontal = -1;
                vertical = -1;
            }
            if (angle > -120 && angle < -90)
            {
                horizontal = 0;
                vertical = -1;
            }
        }
        if (angle > -90 && angle < 0)
        {
            if (angle > -90 && angle < -60)
            {
                horizontal = 0;
                vertical = -1;
            }
            if (angle > -60 && angle < -30)
            {
                horizontal = 1;
                vertical = -1;
            }
            if (angle > -30 && angle < 0)
            {
                horizontal = 1;
                vertical = 0;
            }
        }

        playerAnimator.SetFloat("AimX", horizontal);
        playerAnimator.SetFloat("AimY", vertical);
    }

    void ShootArrow()
    {
        Vector3 crossHairDirection = new Vector3(crossHair.transform.position.x, crossHair.transform.position.y, crossHair.transform.position.z);
        Vector3 shootingDirection = (crossHairDirection - transform.position).normalized;
        shootingDirection.Normalize();
        if (Input.GetButtonDown("FireArrow"))
        {
            aimAnimator.SetBool("Aim", true);
            aimAnimator.SetBool("Shoot", false);
            playerAnimator.SetBool("AimIdle", true);
            playerAnimator.SetBool("Aim", true);
            playerAnimator.SetBool("Shoot", false);
            GameManager.instance.estarQuieto();
        }
        if (Input.GetButtonUp("FireArrow"))
        {
            if (shootForce != 0f)
            {
                GameObject shootArrow = Instantiate(arrow, transform.position, Quaternion.identity);
                shootArrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * shootForce * 2;
                shootArrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
                shootArrow.GetComponent<ArrowController>().arrowDamage = shootArrow.GetComponent<ArrowController>().arrowDamage + shootForce;
                Destroy(shootArrow, 10.0f);

                playerArrows -= 1;
                arrowCountText.text = "x " + playerArrows.ToString();
            }

            aimAnimator.SetBool("Shoot", true);
            aimAnimator.SetBool("Aim", false);
            playerAnimator.SetBool("Shoot", true);
            playerAnimator.SetBool("Aim", false);
            playerAnimator.SetBool("AimIdle", false);
            GameManager.instance.NOestarQuieto();

            

            shootForce = 0f;
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
