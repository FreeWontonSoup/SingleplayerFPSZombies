using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{

    public int currHealth;
    public int maxHealth = 100;

	// Use this for initialization
	void Start () 
    {
        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void changeHealth(int health)
    {
        currHealth += health;
    }
}
