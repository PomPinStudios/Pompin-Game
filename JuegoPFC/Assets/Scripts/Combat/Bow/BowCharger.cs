using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowCharger : MonoBehaviour
{
    // Start is called before the first frame update

    float MaxBowCharge = 1.15f, BowCharge;
    [SerializeField] Slider BowPowerSlider;

    public Vector3 offset;

    public AudioSource clip1;
    public AudioSource clip2;

    void Start()
    {
        BowPowerSlider.value = 0f;
        BowPowerSlider.maxValue = MaxBowCharge;
        BowPowerSlider.gameObject.SetActive(false);      
    }

    // Update is called once per frame
    void Update()
    {
        BowPowerSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        if(Input.GetButtonDown("FireArrow"))
        {
            clip1.Play();
        }

        if(Input.GetButton("FireArrow"))
        {
            BowPowerSlider.gameObject.SetActive(true);
            ChargeBow();
        }

        if(Input.GetButtonUp("FireArrow"))
        {
            clip2.Play();
            BowCharge = 0f;
            BowPowerSlider.value = 0f;
            BowPowerSlider.gameObject.SetActive(false);        
        }
    }


    void ChargeBow()
    {
        BowCharge += Time.deltaTime;

        BowPowerSlider.value = BowCharge;

        if(BowCharge > MaxBowCharge)
        {
            BowPowerSlider.value = MaxBowCharge;
        }
    }
}
