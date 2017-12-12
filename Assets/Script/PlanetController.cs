using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

	public Transform planetReady;
	private float xi=0f;
	private float yi=0f;
	private float xf=0f;
	private float yf=0f;

	// Use this for initialization
	void Start () {

	}

	public void OnMouseDown(){
		xi = Input.mousePosition.x;
		yi = Input.mousePosition.y;
	}

	public void OnMouseUp(){
		xf =Input.mousePosition.x - xi;
		yf =Input.mousePosition.y - yi;
		this.gameObject.GetComponent<Object3D> ().speedX = xf/20;
		this.gameObject.GetComponent<Object3D> ().speedZ = yf/20;
		this.gameObject.GetComponent<Object3D> ().enabled = true;

		GameController.can_create = true;
		Destroy (this);
	}
	
	// Update is called once per frame
	void Update () {

	}


}
