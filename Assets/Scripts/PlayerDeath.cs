using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour 
{
    public GameObject playerCharacter;
    //Camera FPSCam;
    public Camera FPSCam;
    public Camera DeathCam;
    public Transform playerModel;

    //camera rotation
    public float angularSpeed;
    private Vector3 initOffset;
    private Vector3 currOffset;

    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("MainCamera");
        FPSCam = playerCharacter.GetComponent<Camera>();
        currOffset = initOffset;
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel").GetComponent<Transform>();
        DeathCam = GameObject.FindGameObjectWithTag("DeathCamera").GetComponent<Camera>();
    }

    void SetCurrOffset()
    {
        if(playerModel == null)
        {
            return;
        }
        initOffset = DeathCam.transform.position - playerModel.position;
    }

    public void CamSwitch()
    {
        //Debug.Log("here");
        FPSCam.enabled = false;
        //Debug.Log("here");

        DeathCam.enabled = true;
    }

    /*
    void LateUpdate()
    {
        DeathCam.transform.position = playerModel.position + currOffset;

        float movement = Input.GetAxis("Horizontal") * angularSpeed * Time.deltaTime;
        if(!Mathf.Approximately(movement, 0f))
        {
            DeathCam.transform.RotateAround(playerModel.position, Vector3.up, movement);
            currOffset = DeathCam.transform.position - playerModel.position;
        }
    }
    */
       
}
