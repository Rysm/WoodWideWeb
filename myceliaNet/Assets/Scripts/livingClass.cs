/*
 * Main class for living entities
 * by Andy Wang
 */

using UnityEngine;
using System.Collections;

public class livingClass : MonoBehaviour {

	//age
	public float plant_age = 1;

	//produce counter
	public float plantTime = 0.0f;

	//life of plant - 100 alive 0 dead
	int health = 100;

	//nutrients plant has 
	int nutri = 20;
	//max capacity for nutrients
	int nutri_cap = 200;
	//amount needed per cycle to maintain or heal
	int nutri_need = 10;

	//resources for making nutri
	int resours = 40;
	//cap for resources
	int resours_cap = 200;
	//needed resources
	int resours_need = 20;

	//plant state
	public string plant_state = "idle";

	//plant toxic state
	bool plantSick = false;

	/*
	 * Plants need to eat like other living things
	 * Plant takes damage if it's not eating
	 */
	void Consume(){

		//if we can eat
		if(nutri > 0){

			//consume the food if we have more than/at needed
			if (nutri >= nutri_need) {
				nutri -= nutri_need;
			} 

			//if we have less than needed - get by
			else if (nutri < nutri_need) {
				nutri -= nutri;
			}

		}

		//we're starving - taking damage
		else {
			health -= nutri_need;
		}

	}


	/* Make nutrients
	 * 
	 */
	void Produce(){

		//if we can make nutrients
		if (resours > 0){

			//if we have more than we need
			if (resours >= resours_need){
				resours -= resours_need;
				nutri += (resours_need/2);
			}

			//use anyway up if we dont
			else if(resours < resours_need){
				resours -= resours;
				nutri += (resours/2);
			}
		}

	}

	//Plants grow
	void Grow(){
		plant_age += 0.01f;
	}

	//Plants take damage
	void Infected(){
		
		health -= nutri;

	}

	//plant heals itself over time
	void Repair(){

		//Shitty repairing
		if (health < 100) {
			health += 01;
		}
	}

	// Update is called once per frame
	void Update () {

		//increment timer
		plantTime += Time.deltaTime;

		//Debug.Log ("Round plant time" + Mathf.Round(plantTime));

		if (plantTime >= 5) {
			Produce ();
			Consume ();

			if (plantSick == true){
				Infected ();
			}

			plantTime = 0.0f;
		} 

		Grow ();
		Repair ();
		//Debug.Log ("plant nutrients :" + nutri);
		//Debug.Log ("plant resours :" + resours);
	}
}
