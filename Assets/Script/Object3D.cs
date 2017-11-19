using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Notre classe d'objets
 * C'est elle qui possède du coup le spropriétés importante d'un objte donc pos, speed, et acceleration
 */

public class Object3D : MonoBehaviour{

	public float speedX;
	public float speedY;
	public float speedZ;

	//la position est celle du centrede masse
	Vector position{ get; set; }
	Vector speed{ get; set; }
	Vector acceleration{ get; set;}

	private float mass{ get; set; }

	OurCollider collider{ get; set; }


	//GETTERS AND SETTERS
	public Vector Position {get{return position;} set{ position = value;}}
	public Vector Speed {get{return speed;} set{ speed = value;}}
	public Vector Acceleration {get{return acceleration;} set{ acceleration = value;}}


	public void updateObject(Vector acc_for_this_frame)
	{
		this.acceleration = new Vector(acc_for_this_frame.X, acc_for_this_frame.Y, acc_for_this_frame.Z);
		this.speed = this.speed + this.acceleration * EngineScript.dt;
		this.position = this.position + this.speed * EngineScript.dt;
		this.transform.position= new Vector3(this.position.X, this.position.Y, this.position.Z);
	}

	// Use this for initialization
	void Start () {
		this.position = new Vector (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.speed = new Vector (speedX, speedY, speedZ);
		this.acceleration = Vector.Zero();
		//this.updateObject (new Vector(1f,0f,0f));
	}

	// Update is called once per frame
	void Update () {
		//this.updateObject(Vector.Zero());

		/*Ordre des actions à effectuer :
		 * Est-ce qu'il y a une collision en cours ?
		 * Si oui la résoudre
		 * Appliquer toutes les forces qu'il faut sur tout les Objects3D
		 * calculer les nouvelles positions
		 * Appliquer aux positions de unity*/
	}
}
