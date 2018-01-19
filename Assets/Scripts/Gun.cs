using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
    public float dmg = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public ParticleSystem muzzleFlash;
    public GameObject particleImpact;
    public GameObject Gunshot;

    public Camera fpsCam;

//    private int gunshotDelay = 1;
//    private int currentShot = 0;
    	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if(Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }
	}

    public void Shoot()
    {
        muzzleFlash.Play();

        //if(currentShot == 0)
        //{
            GameObject gunShot = Instantiate(Gunshot, this.transform.position, this.transform.rotation) as GameObject;
            gunShot.transform.parent = this.transform;
        //    currentShot = gunshotDelay;
        //}
        //else
        //{
        //    currentShot--;
        //}

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if(target != null)
            {
                target.ApplyDmg(5);
            }
            GameObject impactObject = Instantiate(particleImpact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject, .5f);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
    }
}
