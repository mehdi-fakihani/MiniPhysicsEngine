using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Transform planet;
	public Material red;
	public Material blue;
	public Material yellow;
	public Material green;
	public Material purple;
	public Material orange;
	public Material brown;
	public Material pink;

	public static bool can_create = true;

	// Use this for initialization
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
		GetInput ();
	}

	private void GetInput(){
		if (Input.GetKey (KeyCode.Space) && can_create) {
			can_create = false;
			Transform clone;
			clone = Instantiate (planet, new Vector3 (10f, 0f, 10f), Quaternion.identity);
			clone.GetComponent<Renderer> ().material = RandMaterial();
		}
	}

	private Material RandMaterial(){
		float mat = Random.Range(0f,7.99999f);
		switch ((int)mat) {
		case 0:
			return red;
			break;
		case 1:
			return blue;
			break;
		case 2:
			return yellow;
			break;
		case 3:
			return green;
			break;
		case 4:
			return brown;
			break;
		case 5:
			return purple;
			break;
		case 6:
			return pink;
			break;
		case 7:
			return orange;
			break;
		default:
			return red;
			break;
		}
	}
}
