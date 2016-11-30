/*
 * Parent class for living entities
 * by Andy Wang
 */

using UnityEngine;
using System.Collections;

public class plantClass : MonoBehaviour {

	GameObject theWorld = GameObject.Find("theWorld");
	WorldScript worldScript = theWorld.GetComponent<WorldScript>();

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
	int resours_need = 40;

	//worldTime
	//float worldTime = 0.0f;

	/*
	// Use this for initialization
	void Start () {
	}
	*/

	/*
	 * Plants need to eat like other living things
	 * Plant takes damage if it's not eating
	 */
	void Consume(){

		//if we can eat
		if(nutri > 0){
			
			//after 5 seconds
			if( (worldScript.worldTime%5.0f)==0){
			
				//consume the food if we have more than/at needed
				if (nutri >= nutri_need) {
					nutri -= nutri_need;
				} 

				//if we have less than needed - get by
				else if (nutri < nutri_need) {
					nutri -= nutri;
				}
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

			//every 10 seconds
			if ( (worldScript.worldTime%10.0f) == 0){

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

	}

	//Plants grow
	void Grow(){
		
	}

	//plant heals itself over time
	void Repair(){
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
