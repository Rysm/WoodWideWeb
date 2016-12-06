/*
 * Main class for living entities
 * by Andy Wang
 */

using UnityEngine;
using System.Collections;

public class livingClass : MonoBehaviour {

	void Start(){
		
	}

	//age
	public float plant_age = 1;

	//produce counter
	public float plantTime = 0.0f;

	//life of plant - 100 alive 0 dead
	public int health = 100;

	//nutrients plant has 
	public int nutri;
	//max capacity for nutrients
	int nutri_cap = 200;
	//amount needed per cycle to maintain or heal
	public int nutri_need;
	//how much is given
	public int nutri_sent = 0; 

	//resources for making nutri
	public int resours;
	//cap for resources
	int resours_cap = 200;
	//needed resources
	public int resours_need;

	//plant state
	//idle or transfer
	public string plant_state = "idle";

	//plant toxic state
	bool plantSick = false;

	void Awake(){
		nutri = Random.Range(1,4) * 20;
		nutri_need = Random.Range(1,4) * 10;
		resours = Random.Range(1,4) * 40;
		resours_need = Random.Range(1,4) * 20;

	}

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
				health -= (nutri_need - nutri);
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

				//gain nutrients not past 
				if (nutri < nutri_cap) {
					nutri += (resours_need);
				}

			}

			//use anyway up if we dont
			else if(resours < resours_need){
				//resours -= resours;
				//nutri += (resours/2);
			}
		}

	}

	//Assess function
	void Assess(){
		
	}

	//Assist plant
	void Assist(){

		//Figure out target?

		//Calculate amount of 
		
		//runs the child transfer function
		//run it in mycelia.
		//childScript.Transfer(douglasFir, paperBirch);
		if (nutri > nutri_need) {
			plant_state = "assist";
		} else {
			plant_state = "idle";
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

	void makeResource(){
		if (resours < resours_cap) {
			resours += Random.Range (10, 20);
		}
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
			makeResource ();
			Grow ();
			//Repair ();
			Assist ();

			/*
			if (plantSick == true){
				Infected ();
			}
			*/

			//die
			if (health <= 0){
				Destroy(this);
			}

			plantTime = 0.0f;
		}

		//Debug.Log ("my pos: " + this.transform.position);

		//Debug.Log ("plant nutrients :" + nutri);
		//Debug.Log ("plant resours :" + resours);
	}
}
