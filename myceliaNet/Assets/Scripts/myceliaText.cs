using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIText : myceliaNet {

	//Text stuff
	public Text sendText;

	Vector2 textSrc, textDest;

	// Use this for initialization
	void Start () {
		//
		sendText = GetComponent<UnityEngine.UI.Text>();

		//set text to the amount of nutrients currently being transferred
		myceliaNet myParent = transform.parent.GetComponent<myceliaNet>();
		sendText.text = myParent.send_nutri.ToString();
		textSrc = myParent.sourcePos;
		textDest = myParent.destPos;
	}


	// Update is called once per frame
	void Update () {
		//make the Text move towards the destination point?
		Vector2.MoveTowards(textSrc, textDest, 10 * Time.deltaTime);
	}
}
