using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {

    public MovieTexture BG;
	void Start () {
        GetComponent<Renderer>().material.mainTexture = BG;
        BG.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
