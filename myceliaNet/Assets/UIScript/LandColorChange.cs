using UnityEngine;
using System.Collections;

public class LandColorChange : MonoBehaviour {

    float slider = 0f, t = 0f, duration;
    UnityEngine.UI.Image image;
    Color color1, color2;

    Color temp1 = Color.red, temp2 = Color.blue;

	// Use this for initialization
	void Start () {
        image = GetComponent<UnityEngine.UI.Image>();
        image.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
        Color color = Color.Lerp(temp1, temp2, t);
        t += Time.deltaTime * 2;
        image.color = color;
    }

    public void AdjustColor (float newSlider) {
        slider = newSlider;
        color1 = image.color;
        if (slider == 0) {
            color2 = new Color(0f / 255f, 139f / 255f, 139f / 255f);
        } else if (slider == 1) {
            color2 = new Color(34f / 255f, 139f / 255f, 34f / 255f);
        } else if (slider == 2) {
            color2 = new Color(255f / 255f, 248f / 255f, 220f / 255f);
        }
    }
}
