using UnityEngine;
using System.Collections;

public class playAnimation : MonoBehaviour {
	public bool play;
	ParticleSystem[] dust;
	// Use this for initialization
	void Start () {
		dust = GetComponentsInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(play)
		{
			dust[0].Play();
			dust[1].Play();
			play = false;
		}
	}

	void DisableBoard()
	{
		dust[0].Play();
		dust[1].Play();
		gameObject.SetActive (false);
	}

}
