using UnityEngine;
using System.Collections;

public class LandColorChange : MonoBehaviour {

    public float slider = 0f;
    UnityEngine.UI.Image image;
    private Color newColour;

	// Use this for initialization
	void Start () {
        image = GetComponent<UnityEngine.UI.Image>();
        //image.color = Color.red;
        newColour = image.color;
    }
	
	// Update is called once per frame
	void Update () {
        //image.color = Color.Lerp(color1, color2, Time.deltaTime);
        //t += Time.deltaTime * 2;
        ChangeColor();//image.color = color;
    }

    void ChangeColor () {
        if (slider == 0) //powder blue
            newColour = new Color(176f / 255f, 224f / 255f, 230f / 255f);
        else if (slider == 1) //forest green
            newColour = new Color(34f / 255f, 139f / 255f, 34f / 255f);
        else if (slider == 2) //corn silk
            newColour = new Color(255f / 255f, 248f / 255f, 220f / 255f);
        image.color = Color.Lerp(image.color, newColour, Time.deltaTime * 2);
    }

    public void AdjustColor (float newSlider) {
        slider = newSlider;
    }
}
