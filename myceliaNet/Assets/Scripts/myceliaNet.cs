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
			plantList.Sort((IComparer<GameObject>)new plantSort());

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
		if (transferTimer >= Random.Range(1, 5) ){
			destination.GetComponent<livingClass>().nutri += destination.GetComponent<livingClass>().nutri_need ;
			source.GetComponent<livingClass>().nutri -= destination.GetComponent<livingClass>().nutri_need;
		}

		//take about... random time.

	}

	// Update is called once per frame
	void Update () {
		Query ();
		transferTimer += Time.deltaTime;

		if ((plantList [plantList.Count - 1].GetComponent<livingClass> ().plant_state == "assist") && (plantList[plantList.Count - 1].GetComponent<livingClass>().nutri > plantList[0].GetComponent<livingClass>().nutri)) {
			//Debug.Log ("We're in, patching you through now.");
			Transfer (plantList [plantList.Count - 1], plantList [0]);
		}

		if ((plantList [0].GetComponent<livingClass> ().plant_state == "assist") && (plantList[0].GetComponent<livingClass>().nutri > plantList[plantList.Count - 1].GetComponent<livingClass>().nutri)) {
			//Debug.Log ("We're in, patching you through now.");
			Transfer (plantList [0], plantList [plantList.Count - 1]);
		}

		//
		if (transferTimer >= 10) {
			transferTimer = 0.0f;
		} 
		if (plantList[1].GetComponent<livingClass>().health <= 0){
			Destroy(plantList[1]);
		}
		if (plantList[0].GetComponent<livingClass>().health <= 0){
			Destroy(plantList[0]);
		}

		//Debug.Log ("same : " + plantList[0].GetComponent<livingClass>().nutri);
		//Debug.Log ("same : " + plantList[1]);
	}
}
