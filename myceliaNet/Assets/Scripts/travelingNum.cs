//visual prefab for sending text around

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class travelingNum : myceliaNet { 

	GameObject myself;

	Text sending;

	void Start () {
		sending = GetComponent<Text>();
	}

	//opacity of text
	float alpha = 1f;

	//font color
	Color textColor = Color.white;

	//get parent class position values
	Vector2 fromPlant;
	Vector2 targetPlant;

	void travel(){
		
		fromPlant = this.transform.parent.GetComponent<myceliaNet>().sourcePos;

		targetPlant = this.transform.parent.GetComponent<myceliaNet>().destPos;

		sending.text = sending.transform.parent.GetComponent<myceliaNet> ().send_nutri.ToString();

		//Vector2 towards = targetPlant - fromPlant;
		while(fromPlant != targetPlant){
			Vector2.MoveTowards(fromPlant, targetPlant, 10 * Time.deltaTime);
		}

	}

	void Update(){
		travel ();
	}

	//Create text value

}
