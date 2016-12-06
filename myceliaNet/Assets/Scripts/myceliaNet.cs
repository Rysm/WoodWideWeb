/*
 * Plant transportation manager 
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myceliaNet : livingClass {

	//Text stuff
	public Text sendText;

	//opacity of text
	//float alpha = 1f;

	Vector2 targetPos;

	//timers
	public float myceliaTimer = 0.0f;
	public float transferTimer = 0.0f;

	//vector 2's that find the positions of both plants involved
	public Vector2 sourcePos;
	public Vector2 destPos;

	//how much to send
	public int send_nutri;

	bool ready = false;

	//if it's not in the middle of transferring
	bool transferring = false;

	//dank
	int transferTime;

	//list of plants used in sorting for priority
	public List<GameObject> plantList = new List<GameObject>(); 

	void Start(){
		
		sendText = GetComponent<UnityEngine.UI.Text>();

		//get all the plants
		GameObject[] plants = GameObject.FindGameObjectsWithTag ("plant");
		foreach (GameObject plant in plants) {
			plantList.Add (plant);
		}
		plantList.Sort((IComparer<GameObject>)new plantSort());
		ready = true;
		transferTime = Random.Range(3, 7);

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

		//if we aint transferring already
		if (transferring == false) {

			//Get it to the target between 1 and 10 seconds
			if (transferTimer >= Random.Range(1, 5) ){

				transferring = true;

				sourcePos = destination.transform.position;
				destPos = source.transform.position;

				//get their needed val
				send_nutri = destination.GetComponent<livingClass>().nutri_need;

				//exchange values as needed
				destination.GetComponent<livingClass>().nutri += send_nutri ;
				source.GetComponent<livingClass>().nutri -= send_nutri;

				//stuff
				targetPos = destPos - sourcePos;
				sendText.text = send_nutri.ToString(); //???

				//Debug.Log (send_nutri);
			}

		}
		//take about... random time.

	}

	// Update is called once per frame
	void Update () {
		Query ();
		transferTimer += Time.deltaTime;

		if (ready) {

			if ((plantList [plantList.Count - 1].GetComponent<livingClass> ().plant_state == "assist") && (plantList[plantList.Count - 1].GetComponent<livingClass>().nutri > plantList[0].GetComponent<livingClass>().nutri)) {
				//Debug.Log ("We're in, patching you through now.");
				Transfer (plantList [plantList.Count - 1], plantList [0]);
			}

			if ((plantList [0].GetComponent<livingClass> ().plant_state == "assist") && (plantList[0].GetComponent<livingClass>().nutri > plantList[plantList.Count - 1].GetComponent<livingClass>().nutri)) {
				//Debug.Log ("We're in, patching you through now.");
				Transfer (plantList [0], plantList [plantList.Count - 1]);
			}

		}

		//
		if (transferTimer >= transferTime) {
			transferTimer = 0.0f;
			transferTime = Random.Range(3, 7);
		}

		/*
		if (health <= 0){
			Destroy(this);
		}
		*/

		//Debug.Log ("same : " + plantList[0].GetComponent<livingClass>().nutri);
		//Debug.Log ("same : " + plantList[1]);
	}
}
