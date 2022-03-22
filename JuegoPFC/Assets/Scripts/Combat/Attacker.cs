using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    public float gap = 1f;
    public Vector2 hitBox = new Vector2(1, 1);
    private Vector2 vectorAttackGap;
    private Vector2 attackStart;
    private Vector2 attackEnd;
    private Collider2D[] ataqueColliders = new Collider2D[12];
    private ContactFilter2D attackFilter;
    public LayerMask attackLayer;
    private bool changed = false;

    private void Start()
    {
        attackFilter.useLayerMask = true;
        attackFilter.layerMask = attackLayer;
    }

    public void Update()
    {
        Debug.DrawLine(transform.position, (Vector2)transform.position + vectorAttackGap, Color.magenta);
        Debug.DrawLine(attackStart, attackEnd, Color.red);
    }


    public void Attack(Vector2 attackDirection, int damage)
    {
        crearHitbox(attackDirection);
        Debug.Log("attackDirectionX: " + attackDirection.x + "attackDirectionY: " + attackDirection.y);
        GameObject attackedObject;
        //Nos va a comprobar si una colision esta dentro de los puntos que le hemos pasado como parametro
        int elemenentosAtacados = Physics2D.OverlapArea(attackStart, attackEnd, attackFilter, ataqueColliders);
        Debug.Log("Elementos atacados " + elemenentosAtacados);

        //Para cada elemento que este dentro de la colsion de ataque, va a recibir el ataque
        //si este tiene el componente atacable.
        for (int i = 0; i < elemenentosAtacados; i++)
        {
            attackedObject = ataqueColliders[i].gameObject;
            if (attackedObject.tag == "Enemy")
            {
                attackedObject.GetComponent<EnemyStats>().takeDamage(damage);
            }
        }
    }

    private void crearHitbox(Vector2 attackDirection)
    {
        Vector2 escale = transform.lossyScale;

        if ((attackDirection.x == 1 && attackDirection.y == 0) || (attackDirection.x == -1 && attackDirection.y == 0))
        {
            float x = hitBox.x;
            float y = hitBox.y;
            hitBox.x = y;
            hitBox.y = x;
            changed = true;
        }
        Vector2 escaledHitbox = Vector2.Scale(hitBox, escale);

        vectorAttackGap = Vector2.Scale(attackDirection.normalized * gap, escale);

        attackStart = (Vector2)transform.position + vectorAttackGap - escaledHitbox * 0.5f;
        attackEnd = attackStart + escaledHitbox;

        if (changed)
        {
            float x = hitBox.x;
            float y = hitBox.y;
            hitBox.x = y;
            hitBox.y = x;
            changed = false;
        }
    }
}
