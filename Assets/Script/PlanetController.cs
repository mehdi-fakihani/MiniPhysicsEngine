using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

	public Transform planetReady;
	private LineRenderer line;
	private float xi=0f;
	private float yi=0f;
	private float xf=0f;
	private float yf=0f;
	private bool pressed = false;

	// Use this for initialization
	void Start () {
		line = GameObject.Find ("Canvas/Line").GetComponent<LineRenderer>();
		line.material = this.gameObject.GetComponent<Renderer> ().material;
	}

	public void OnMouseDown(){
		pressed = true;
		xi = Input.mousePosition.x;
		yi = Input.mousePosition.y;
	}

	public void OnMouseUp(){
		pressed = false;
		line.GetComponent<LineRenderer> ().SetPosition (0, new Vector3 (0f, 0f, 0f));
		line.GetComponent<LineRenderer> ().SetPosition (1, new Vector3 (0f, 0f, 0f));
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
		if (pressed) {
			line.GetComponent<LineRenderer> ().SetPosition (0, new Vector3 (this.transform.position.x, 0f, this.transform.position.z));
			line.GetComponent<LineRenderer> ().SetPosition (1, new Vector3 (this.transform.position.x + (xi - Input.mousePosition.x)/10, 0f, this.transform.position.z + (yi - Input.mousePosition.y)/10));
		}
	}


}
