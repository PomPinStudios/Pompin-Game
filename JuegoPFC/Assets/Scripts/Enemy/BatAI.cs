using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3f;

    [Header("Attack")]
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public Transform target;
    private Animator sellerAnimator;
    
    private void Start()
    {
        sellerAnimator = gameObject.GetComponent<Animator>();
        sellerAnimator.SetFloat("X", 0); 
        sellerAnimator.SetFloat("Y", -1); 
    }

    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            Vector3 dir = (target.position - transform.position).normalized;
            
            sellerAnimator.SetFloat("X", dir.x); 
            sellerAnimator.SetFloat("Y", dir.y); 
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
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

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerStats>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}