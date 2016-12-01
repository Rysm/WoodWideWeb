using UnityEngine;
using System.Collections;

public class LandColorChange : MonoBehaviour {

    public float color = 0f;
    public UnityEngine.UI.Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<UnityEngine.UI.Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (color == 10f) {
            image.color = Color.red;
        }
    }

    public void AdjustColor (float newColor) {
        color = newColor;
    }
}
