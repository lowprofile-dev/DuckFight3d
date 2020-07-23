using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHP : MonoBehaviour {

	// Use this for initialization
	void Start () {
        h = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
	}

    Health h;
	
	// Update is called once per frame
	void Update () {
        if(h == null)
        {
            gameObject.SetActive(false);
            return;
        }

        GetComponent<Text>().text = "LIFE: " + h.hitPoints + "/" + h.initialHitPoints;
	}
}
