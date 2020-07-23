using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject AmmoIconPrefab;
    PlayerCannon cannon;
    public GameObject NoAmmo;
	
	// Update is called once per frame
	void Update () {
        if(cannon == null)
        {
            cannon = GameObject.FindObjectOfType<PlayerCannon>();
            if(cannon == null)
                return;
        }

        if(cannon.Ammo <= 0)
        {
            NoAmmo.SetActive(true);
        }
        else
        {
            NoAmmo.SetActive(false);
        }

        while(cannon.Ammo > this.transform.childCount)
        {
            // Spawn some icons
            Instantiate(AmmoIconPrefab, this.transform);
        }
        while(cannon.Ammo < this.transform.childCount)
        {
            Transform t = this.transform.GetChild(0);
            t.SetParent(null);
            Destroy(t.gameObject);
        }
	}
}
