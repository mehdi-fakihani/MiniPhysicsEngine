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


	private float xi=0f;
	private float yi=0f;
	private float xf=0f;
	private float yf=0f;
	private bool pressed = false;
	private bool once = true;
	// Use this for initialization
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
		GetInput ();
	}



	private void GetInput(){
		if (Input.GetKey (KeyCode.Space) && can_create) {
			if (once) {
				GameObject.Find ("Aide1").SetActive (false);
				once = false;
			}
			can_create = false;
			Transform clone;
			int negX = (Random.value > 0.5f ?-1:1);
			int negZ = (Random.value > 0.5f ?-1:1);
			float x =Random.Range(9f,25f);
			float z =Random.Range(9f,25f);
			clone = Instantiate (planet, new Vector3 (x*negX, 0f, z*negZ), Quaternion.identity);
			float mat = Random.Range(0f,7.99999f);
			clone.GetComponent<Renderer> ().material = RandMaterial(mat);
			switch ((int)mat) {
			case 0:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = Color.red;
				break;
			case 1:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = Color.blue;
				break;
			case 2:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = Color.yellow;
				break;
			case 3:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = Color.green;
				break;
			case 4:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = new Color (255f, 174f, 00f);
				break;
			case 5:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = new Color (154f, 00f, 234f);
				break;
			case 6:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = new Color (154f, 00f, 234f);
				break;
			case 7:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = new Color (255f, 174f, 00f);
				break;
			default:
				clone.GetChild (0).GetComponent<ParticleSystem> ().startColor = Color.red;
				break;
			}

		}
	}

	private Material RandMaterial(float mat){
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


/*if (Input.GetMouseButtonUp(0)) {
			can_create=true;
			pressed = false;
		}
		if (Input.GetMouseButtonDown(0)  || pressed) {
			pressed = true;
			xi = Input.mousePosition.x;
			yi = Input.mousePosition.y;
			if (Input.GetKey (KeyCode.Space) && can_create) {
				can_create = false;
				xf =Input.mousePosition.x - xi;
				yf =Input.mousePosition.y - yi;
				Transform clone;

				clone = Instantiate (planet, new Vector3 (10f, 0f, 10f), Quaternion.identity);
				clone.GetComponent<Renderer> ().material = RandMaterial();

				clone.gameObject.GetComponent<Object3D> ().speedX = xf/20;
				clone.gameObject.GetComponent<Object3D> ().speedZ = yf/20;

				clone.gameObject.SetActive(true);


			}
		}
*/