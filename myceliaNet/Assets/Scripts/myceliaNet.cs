/*
 * Plant transportation manager 
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myceliaNet : MonoBehaviour {

	public float myceliaTimer = 0.0f;

	//creates a dictionary to store everything
	//List<string> myNet = new List<string>();
	Dictionary<string, string> myNet = new Dictionary<string, string>();

	// Use this for initialization
	void Start () {
		
		//get all the plant objects in the scene
		GameObject[] allPlants = FindObjectsOfType<GameObject>();
		//Debug.Log (allPlants);

	}


	/*
	 * Query for objets again in the scene 
	 * Called in update every 10 seconds.
	 * 
	*/
	void Query(){
		
		myceliaTimer += Time.deltaTime;
		//query every five seconds
		if (myceliaTimer >= 10) {
			GameObject[] allPlants = FindObjectsOfType<GameObject> ();
			myceliaTimer = 0.0f;
		}

	}

	/*
	 * Sends whatever in x amount of time based on distance 
	 * 
	*/
	void Transfer(){

		/*
		if (plant.state = "attack") {
			
		} 
		else if (plant.state = "assist") {
			
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		Query ();
	}
}
