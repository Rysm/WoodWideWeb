/*
 * Plant transportation manager 
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myceliaNet : MonoBehaviour {

	public float myceliaTimer = 0.0f;

	// Use this for initialization
	void Start () {
		
		//get all the plant objects in the scene
		GameObject[] allPlants = FindObjectsOfType<GameObject>();
		//Debug.Log (allPlants);
		//Debug.Log (allPlants[0]);

	}


	/*
	 * Query for objets again in the scene 
	 * 
	*/
	void Query(){
		
		myceliaTimer += Time.deltaTime;
		//query every five seconds
		if (myceliaTimer >= 5) {
			GameObject[] allPlants = FindObjectsOfType<GameObject> ();
			myceliaTimer = 0.0f;
		}

	}
	
	// Update is called once per frame
	void Update () {
		Query ();
	}
}
