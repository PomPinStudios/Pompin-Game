using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaIA : MonoBehaviour
{
    public float movementSpeed;
    public Transform[] movementPoints;
    public float minimunDistance;
    private SpriteRenderer spriteRenderer;
    private int nextStep = 0;

    private DayTimeController dayTimeController;
    private bool startMoving;
    private bool finishMoving;
    private Vector3 inicialPosition;
    private Animator sellerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        dayTimeController = GameManager.instance.timeController;
        spriteRenderer = GetComponent<SpriteRenderer>();
        inicialPosition = gameObject.transform.position;
        sellerAnimator = gameObject.GetComponent<Animator>();
        sellerAnimator.SetFloat("X", 0); 
        sellerAnimator.SetFloat("Y", -1); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[nextStep].position, movementSpeed * Time.deltaTime);

        Vector3 dir = (movementPoints[nextStep].position - transform.position).normalized;
        
        sellerAnimator.SetFloat("X", dir.x); 
        sellerAnimator.SetFloat("Y", dir.y); 

        if(Vector2.Distance(transform.position, movementPoints[nextStep].position) < minimunDistance)
        {
            Debug.Log("a");
            nextStep += 1;
            if(nextStep >= movementPoints.Length)
            {
                nextStep = 0;
            }
        }
    }
}
