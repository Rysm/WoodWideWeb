using UnityEngine;
using System.Collections;
public class popText : myceliaNet{

	private Vector2 position;
	private string myText;
	private Vector2 screenPointPosition;
	private Camera cameraHold;

	void Start(){
		cameraHold = Camera.main;
		screenPointPosition = cameraHold.WorldToScreenPoint(position);
	}

	public static void showText(string text, Vector2 pos){
		var newInstance = new GameObject ("damage");
		var textPop = newInstance.AddComponent<popText> (); 
		textPop.position = pos;
		textPop.myText = text;
	}

	void Update(){
		screenPointPosition.y -= 1;
	}

	void OnGUI(){
		GUI.Label (new Rect (screenPointPosition.x, screenPointPosition.y, 150, 20), myText);
		Destroy (gameObject, 1);
	}
}