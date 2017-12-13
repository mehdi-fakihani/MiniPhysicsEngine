using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Notre classe d'objets
 * C'est elle qui possède les propriétés importantes d'un objet dont la position, la vitesse, et l'acceleration
 */

public class Object3D : MonoBehaviour{

    //Fields exposed in the editor (there's maybe a cleaner way to do this)
	public float speedX;
	public float speedY;
	public float speedZ;
	public float setMass;
    public float setRadius;


    //The position corresponds to the object's center of mass
    private Vector position;
    private Vector speed;
    private float mass;
    private float radius;

	//GETTERS AND SETTERS
	public Vector Position {get{return position;} set{ position = value;}}
	public Vector Speed {get{return speed;} set{ speed = value;}}
	public float Mass {get{return mass;} set{ mass = value;}}
    public float Radius { get { return radius; } set { radius = value; } }



	// Use this for initialization
	void Start () {
		this.Mass = setMass;
		this.Position = new Vector (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.Speed = new Vector (speedX, speedY, speedZ);
		this.radius = setRadius;
		//EngineScript.others = GameObject.FindGameObjectsWithTag ("Planet");
	}

	// Update is called once per frame
	void Update () {
			Force total = new Force (Vector.Zero (), 0, 0, 0);
			for (int i = 0; i < EngineScript.others.Length; i++) { // Think to replace this old for loop with the foreach syntax
				Object3D other = EngineScript.others [i].GetComponent<Object3D> ();
                if (other != this)
                {
                    total = Force.Gravity(this, other);
				if (EngineScript.collisionsActivated)
                        total += Force.ImpulseIfCollision(this, other);
				print ((this.position-other.position).Length);
                }
			}

			this.updateObject (total / Mass);
	}

    public void updateObject(Vector acceleration)
    {
		this.speed += acceleration * EngineScript.dt;
		this.position += this.speed * EngineScript.dt;
        this.transform.position = new Vector3(this.position.X, this.position.Y, this.position.Z);
    }
}
