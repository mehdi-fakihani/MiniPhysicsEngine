using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

	private bool launched=false;

	private float x=0f;
	private float z=0f;

	// Use this for initialization
	void Start () {
		
	}

	public void OnMouseDown(){
		
	}

	public void OnMouseUp(){
		x = this.gameObject.transform.position.x - Input.mousePosition.x;
		z = this.gameObject.transform.position.z - Input.mousePosition.z;
		this.gameObject.GetComponent<Object3D> ().speedX = x;
		this.gameObject.GetComponent<Object3D> ().speedZ = z;
		this.gameObject.GetComponent<Object3D> ().enabled = true;
		this.gameObject.tag="Planet";
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
