/*
 * Plant transportation manager 
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myceliaNet : livingClass {

	//timers
	public float myceliaTimer = 0.0f;
	public float transferTimer = 0.0f;

	//list of plants used in sorting for priority
	public List<GameObject> plantList = new List<GameObject>(); 

	void Start(){
		//get all the plants
		GameObject[] plants = GameObject.FindGameObjectsWithTag ("plant");
		foreach (GameObject plant in plants) {
			plantList.Add (plant);
		}
		plantList.Sort((IComparer<GameObject>)new plantSort());
	}

	private class plantSort : IComparer<GameObject>{
		int IComparer<GameObject>.Compare(GameObject _objA, GameObject _objB) {
			int t1 = _objA.GetComponent<livingClass>().nutri;
			int t2 = _objB.GetComponent<livingClass>().nutri;
			return t1.CompareTo(t2);
		}
	}

	//Query for objets again in the scene 
	//Called in update every 10 seconds.

	void Query(){

		myceliaTimer += Time.deltaTime;
		//query every five seconds
		if (myceliaTimer >= 10) {

			//get all the plants
			GameObject[] plants = GameObject.FindGameObjectsWithTag ("plant");
			foreach (GameObject plant in plants) {
				plantList.Add (plant);
			}

			myceliaTimer = 0.0f;
		}

		//quicksort plant nutri amounts least to greatest

		//check plant states

	}


	/*
	 * Sends whatever in x amount of time based on distance 
	 * 
	*/
	void Transfer(GameObject source, GameObject destination){


		transferTimer += Time.deltaTime;

		//Get it to the target between 1 and 10 seconds
		if (transferTimer >= Random.Range(1, 10) ){
			destination.GetComponent<livingClass>().nutri += 10;
		}

		//take about... random time.

	}

	// Update is called once per frame
	void Update () {
		Query ();
		transferTimer += Time.deltaTime;
		if (transferTimer >= 10) {
			transferTimer = 0.0f;
		} 
	}
}
