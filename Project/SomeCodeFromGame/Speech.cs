using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Speech : MonoBehaviour {

	// Use this for initialization
	void Start () {
        h = GetComponent<Health>();
        fo = GetComponent<FloatingObject>();
        source = GetComponent<AudioSource>();
	}
	
    public AudioClip[] speechClips;

    float speechCooldown = 4;
    float speechTimer = 0;

    Health h;
    FloatingObject fo;
    AudioSource source;

	// Update is called once per frame
	void Update () {
        if(GameManager.isPaused)
            return;

		
        speechTimer -= Time.deltaTime;

        if(
            (fo == null || fo.OnSurface()) &&
            (h == null || h.isDead == false) &&
            speechTimer <= 0 &&
            speechClips != null && speechClips.Length > 0
        )
        {
            speechTimer = Random.Range(speechCooldown, speechCooldown * 1.5f);

            source.PlayOneShot( speechClips[ Random.Range(0, speechClips.Length) ] );
        }

	}
}
