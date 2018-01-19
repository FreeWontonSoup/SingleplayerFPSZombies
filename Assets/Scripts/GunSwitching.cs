using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour 
{
    public int currentGunIndex = 0;
    float countTime = 0;
    int touchCount = 0;

	// Use this for initialization
	void Start () 
    {
        SelectGun();
	}
	
	// Update is called once per frame
	void Update () 
    {
        int prevGunIndex = currentGunIndex;

        if(countTime > 0 && touchCount == 1)
        {
            countTime -= Time.deltaTime;
        }
        else if(countTime > 0 && touchCount == 2)
        {
            countTime = 0;
            touchCount = 0;

            if(currentGunIndex >= transform.childCount-1)
            {
                currentGunIndex = 0;
            }
            else
            {
                currentGunIndex++;
            }
        }
        else
        {
            countTime = 0;
            touchCount = 0;
        }

        /*
        //scrolling forward to switch weapons past the last weapon, want it to wrap around back to first
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(currentGunIndex >= transform.childCount-1)
            {
                currentGunIndex = 0;
            }
            else
            {
                currentGunIndex++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(currentGunIndex <= 0)
            {
                currentGunIndex = transform.childCount-1;
            }
            else
            {
                currentGunIndex--;
            }
        }
        */

        //actually allows to switch between weapons (the visual can be seen)
        if(prevGunIndex != currentGunIndex)
        {
            SelectGun();
        }
	}

    void SelectGun()
    {
        int i = 0;
        //loop through children of weaponholder
        foreach (Transform weapon in transform)
        {
            if(i == currentGunIndex)
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

    public void OnSwitchButtonTouch()
    {
        touchCount++;
        countTime = 1;
        Debug.Log("tester");
    }
}
