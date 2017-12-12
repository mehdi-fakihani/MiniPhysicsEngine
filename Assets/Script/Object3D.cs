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
	public static float dt =0.2f;

    //The position corresponds to the object's center of mass
    private Vector position;
    private Vector speed;
    private float mass;

	//GETTERS AND SETTERS
	public Vector Position {get{return position;} set{ position = value;}}
	public Vector Speed {get{return speed;} set{ speed = value;}}
	public float Mass {get{return mass;} set{ mass = value;}}

	// Use this for initialization
	void Start () {
		this.Mass = setMass;
		this.Position = new Vector (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.Speed = new Vector (speedX, speedY, speedZ);
	}

	// Update is called once per frame
	void Update () {
		Force total = new Force (Vector.Zero (), 0, 0, 0);
        GameObject[] others = GameObject.FindGameObjectsWithTag("Planet");

        for (int i = 0; i < others.Length; i++) // Think to replace this old for loop with the foreach syntax
        {
            Object3D other = others[i].GetComponent<Object3D>();

            if(other != this)
				total = Force.Gravity (this, other) + Force.ImpulseIfCollision(this, other);
		}

		if(!this.name.Equals("Soleil")) //Why is there no force applied on the Sun ?
			this.updateObject(total/Mass);
	}

    public void updateObject(Vector acceleration)
    {
		this.speed += acceleration * dt;
		this.position += this.speed * dt;
        this.transform.position = new Vector3(this.position.X, this.position.Y, this.position.Z);
    }
}
