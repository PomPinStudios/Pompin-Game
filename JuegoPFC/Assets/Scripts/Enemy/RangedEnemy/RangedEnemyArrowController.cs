using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyArrowController : MonoBehaviour
{
    private GameObject player;
    private CircleCollider2D myCollider;
    private Rigidbody2D rb;
    private bool hasHit, isPositive, touchingArrow;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        myCollider = transform.GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Arrow" && other.tag != "RangedEnemy" && other.tag != "Player")
        {
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            Destroy(gameObject, 15f);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "RangedEnemy")
        {
            Debug.Log(other.gameObject.tag);
            other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (other.gameObject.tag == "Player")
        {
            GameObject attackedObject = other.gameObject;
            if (attackedObject.tag == "Player")
            {
                attackedObject.GetComponent<PlayerStats>().UpdateHealth(-20);
            }
            Destroy(gameObject);
        }
        else
        {
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            rb.freezeRotation = true;
            Destroy(gameObject, 15f);
        }

    }
}
