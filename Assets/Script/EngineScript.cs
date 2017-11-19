using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Le moteur !!
 * Il doit trouver tous les objets ou alors on lui donne au choix.
 * Dans le update on a la boucle principale du moteur !
 * */
public class EngineScript : MonoBehaviour {

	//a definir comment le calculer correctement mais ça sera notre durée de frame
	//On doit en aprler de ça ça va etre chelou à calculer
	public static float dt{ get; set; }

	public Transform Soleil;

	//testing les forces
	public Transform t1;
	private Object3D o1;

	// Use this for initialization
	void Start () {
		dt = 0.2f;
		//On get tous les Object3D
		o1 = t1.GetComponent<Object3D>();
		o1.updateObject (new Vector(1f,0f,0f));
	}
	
	// Update is called once per frame
	void Update () {
		Force centripete = new Force (Vector.Zero (), Soleil.transform.position.x - o1.Position.X, Soleil.transform.position.y - o1.Position.Y, Soleil.transform.position.z - o1.Position.Z);
		o1.updateObject(centripete.Normalized);

		/*Ordre des actions à effectuer :
		 * Est-ce qu'il y a une collision en cours ?
		 * Si oui la résoudre
		 * Appliquer toutes les forces qu'il faut sur tout les Objects3D
		 * calculer les nouvelles positions
		 * Appliquer aux positions de unity*/
	}
}
