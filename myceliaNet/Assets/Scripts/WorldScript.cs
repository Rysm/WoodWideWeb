/*
 * Manage the environment around the plants
 */

using UnityEngine;
using System.Collections;

public class worldScript : MonoBehaviour {

	//the timer of the world
	//cannot globalize everything so giving up for now.
	public float worldTime = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		//increment the timer
		worldTime += Time.deltaTime;

	}
}