using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public float gap = 1f;
    public Vector2 hitBox = new Vector2(1,1);
    private Vector2 vectorAttackGap;
    private Vector2 attackStart;
    private Vector2 attackEnd;

    public void Attack(Vector2 attackDirection, int damage)
    {
        crearHitbox(attackDirection);

        Debug.DrawLine(transform.position, (Vector2) transform.position + vectorAttackGap, Color.magenta);
        Debug.DrawLine(attackStart, attackEnd, Color.red);
    }

    public void Update() 
    {
        
    }

    private void crearHitbox(Vector2 attackDirection)
    {
        Vector2 escale = transform.lossyScale;
        Vector2 escaledHitbox = Vector2.Scale(hitBox, escale);
        
        vectorAttackGap = Vector2.Scale(attackDirection.normalized * gap, escale);
        
        attackStart = (Vector2) transform.position + vectorAttackGap - escaledHitbox * 0.5f;
        attackEnd = attackStart + escaledHitbox;
    }
}
