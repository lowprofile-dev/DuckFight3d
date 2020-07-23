using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        floatingObject = GetComponent<FloatingObject>();

	}

    GameObject thePlayer;
    FloatingObject floatingObject;

    public float Speed = 1;
    public float TurningSpeed = 180;
	
	// Update is called once per frame
	void Update () {
        if(GameManager.isPaused)
            return;

        if(GetComponent<FloatingObject>().OnSurface() == false)
        {
            return;
        }
		
        if(thePlayer == null)
        {
            thePlayer = GameObject.FindWithTag("Player");
            if(thePlayer == null)
                return;
        }

        if(GetComponent<Health>() != null && GetComponent<Health>().isDead == true)
        {
            return;
        }


        Vector3 direction = thePlayer.transform.position - this.transform.position;

        floatingObject.Facing = Quaternion.RotateTowards( 
            this.transform.transform.rotation, 
            Quaternion.LookRotation(direction),
            TurningSpeed * Time.deltaTime
        );
        floatingObject.Acceleration = floatingObject.Facing * Vector3.forward * Speed;


	}
}
