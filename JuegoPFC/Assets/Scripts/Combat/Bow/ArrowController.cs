using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    private GameObject player, crossHair;
    private Collider2D myCollider;
    private Rigidbody2D rb;
    private float crossHairX;
    private bool hasHit, isPositive, touchingArrow;
    private Text arrowCountText;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        myCollider = transform.GetComponent<Collider2D>();
        crossHair = GameObject.FindGameObjectWithTag("CrossHair");
        player = GameObject.FindGameObjectWithTag("Player");

        //Posicion real del punto de mira respecto al player
        float realPosition = crossHair.transform.position.x - player.transform.position.x;
        if(realPosition > 0)
        {
            crossHairX = crossHair.transform.position.x;
            isPositive = true;
        }else
        {
            crossHairX = crossHair.transform.position.x * -1;
            isPositive = false;
        }

        arrowCountText = GameObject.Find ("Canvas/ArrowsCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if(isPositive == false)
        {
            if(crossHairX < transform.position.x * -1)
            {
                hasHit = true;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                gameObject.layer = 8;

                Destroy(gameObject, 15f);
            }
        }
        else
        {
            if(crossHairX < transform.position.x)
            {
                hasHit = true;
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                gameObject.layer = 8;

                Destroy(gameObject, 15f);
            }
        }


        if(touchingArrow)
        {
            if(Input.GetButton("Interactive")){
                AimShootBow.playerArrows += 1;
                arrowCountText.text = "x " + AimShootBow.playerArrows.ToString();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Arrow")
        {
            hasHit = true; 
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            Destroy(gameObject, 15f);
        }

        if(other.tag == "Player")
        {
            touchingArrow = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            touchingArrow = false;
        }
    }
}
