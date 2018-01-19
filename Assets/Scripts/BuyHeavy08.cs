using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHeavy08 : MonoBehaviour 
{
    public float distance;
    public Transform player;
    public PlayerCanvas pc;
    	
	// Update is called once per frame
	void Update () 
    {
        distance = Vector3.Distance(player.position, transform.position);
        if(distance < 2.5)
        {
            pc.SetHeavyActive(true);
        }
        else if(distance >= 2.5)
        {
            pc.SetHeavyActive(false);
        }
	}

    public void BuyGun()
    {
        
    }
}
