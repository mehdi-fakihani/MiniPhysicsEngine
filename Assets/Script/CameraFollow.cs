using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform Sun;
	public Transform Earth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Earth.position +  new Vector3 (0f, 10f, 0f) + ((Earth.position - Sun.position) * 0.05f);
		this.transform.forward = (Sun.position - this.transform.position).normalized;
	}
}
