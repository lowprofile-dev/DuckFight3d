using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //float damageRange = 0.5f;
	
	// Update is called once per frame
	void Update () {
        if(GameManager.isPaused)
            return;


        FloatingObject[] fos = GameObject.FindObjectsOfType<FloatingObject>();

        foreach(FloatingObject fo in fos)
        {
            if(fo.enabled == false || fo.AffectedByExplosions == false || fo.OnSurface() == false )
            {
                continue;
            }

            Rigidbody r = fo.GetComponent<Rigidbody>();

            if(r == null || r.isKinematic)
                continue;

            // First, pull object closer.

            Vector3 dir = this.transform.position - fo.transform.position;
            dir.y = 0;

            float force = 10;// * (1 - dir.magnitude / 75);
            if(force < 0)
                continue;

            r.AddForce( dir.normalized * force );

            if(dir.magnitude < 1)
            {
                // Caught in the whirlpool.  Spin, then destroy.
                r.AddTorque( new Vector3(0, 100, 0) );
                Destroy(r.gameObject, 2);
            }
        }
		
	}
}
