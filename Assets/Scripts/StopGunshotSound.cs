using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGunshotSound : MonoBehaviour 
{
    private float totalTimeBefore;

	// Use this for initialization
	void Start () 
    {
        AudioSource sound = this.GetComponent<AudioSource>();
        totalTimeBefore = sound.clip.length;
	}
	
	// Update is called once per frame
	void Update () 
    {
        totalTimeBefore -= Time.deltaTime;

        if(totalTimeBefore <= 0f)
        {
            Destroy(this.gameObject);
        }
	}
}
