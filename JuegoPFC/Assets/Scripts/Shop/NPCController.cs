using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] Canvas npcShop;
    private Animator NPCAnimator;
    // Start is called before the first frame update
    void Start()
    {
        npcShop.gameObject.SetActive(false);
        NPCAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        gameObject.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + new Vector3(1, 1,0) * 1 * Time.deltaTime);
    }
    void ChangeDirection()
    {
        int direction = Random.Range(0,8);
        int horizontal = 0, vertical = 0;
        switch(direction)
        {
            case 0:
                
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 9:
                break;
        }
        NPCAnimator.SetFloat("X", horizontal);
        NPCAnimator.SetFloat("Y", vertical);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        npcShop.gameObject.SetActive(false);
    }
    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetButton("Interactive"))
        {

            npcShop.gameObject.SetActive(true);

        }
    }
}
