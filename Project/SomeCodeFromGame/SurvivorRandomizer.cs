using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        SurvivorMR.materials[0].color = ShirtColors[ Random.Range(0, ShirtColors.Length) ];

        SurvivorMR.materials[1].color = SkinColors[ Random.Range(0, SkinColors.Length) ];

        SurvivorMR.materials[2].color = HairColors[ Random.Range(0, HairColors.Length) ];
	}

    public MeshRenderer SurvivorMR;
    public Color[] ShirtColors;
    public Color[] SkinColors;
    public Color[] HairColors;
	
}
