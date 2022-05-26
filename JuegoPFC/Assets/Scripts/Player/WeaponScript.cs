using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex = 0;
    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentWeapon;
    public GameObject canvas;

    public AudioSource clip;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            // Debug.Log(weapons[i]);
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeaponIndex < totalWeapons - 1)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                weapons[currentWeaponIndex].SetActive(true);
                currentWeapon = weapons[currentWeaponIndex];
                if (currentWeapon.tag == "Aim")
                {
                    animator.SetBool("Bowing", true);
                    this.GetComponent<AimShootBow>().enabled = true;
                    canvas.SetActive(true);
                }
                else
                {
                    animator.SetBool("Bowing", false);
                    this.GetComponent<AimShootBow>().enabled = false;
                    canvas.SetActive(false);
                }
            }
        }

        if (Input.GetButtonDown("Fire1") && AttackUnlocker.isUnlocked)
        {
            if (currentWeapon.tag != "Aim")
            {
                clip.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeaponIndex > 0)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                weapons[currentWeaponIndex].SetActive(true);
                currentWeapon = weapons[currentWeaponIndex];
                if (currentWeapon.tag == "Aim")
                {
                    animator.SetBool("Bowing", true);
                    this.GetComponent<AimShootBow>().enabled = true;
                    canvas.SetActive(true);
                }
                else
                {
                    animator.SetBool("Bowing", false);
                    this.GetComponent<AimShootBow>().enabled = false;
                    canvas.SetActive(false);
                }
            }
        }
    }
}
