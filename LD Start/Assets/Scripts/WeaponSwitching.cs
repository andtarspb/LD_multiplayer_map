using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    public int avaiableWeapons = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSeletedWeapon = selectedWeapon;

        HandleScrollWheel();

        HandleKeys();

        if (previousSeletedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void HandleKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && avaiableWeapons >= 1)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && avaiableWeapons >= 2)
        {
            selectedWeapon = 2;
        }
    }

    void HandleScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //if (selectedWeapon >= transform.childCount - 1)
            if (selectedWeapon >= avaiableWeapons)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
            {
                //selectedWeapon = transform.childCount - 1;
                selectedWeapon = avaiableWeapons;
            }
            else
            {
                selectedWeapon--;                
            }
        }
    }

    public void AddWeapon()
    {
        avaiableWeapons++;
    }

    public void SelectWeapon()
    {

        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
