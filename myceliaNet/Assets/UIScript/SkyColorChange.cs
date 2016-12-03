using UnityEngine;
using System.Collections;

public class SkyColorChange : MonoBehaviour {

    public float slider = 0f;
    //UnityEngine.UI.Image image;
    private Color newColour;
    private SpriteRenderer renderer;

    // Use this for initialization
    void Start()
    {
        //image = GetComponent<UnityEngine.UI.Image>();
        //newColour = image.color;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        newColour = renderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        if (slider == 0) //snow
            newColour = new Color(255f / 255f, 250f / 255f, 250f / 255f);
        else if (slider == 1) //deep sky blue
            newColour = new Color(0f / 255f, 191f / 255f, 255f / 255f);
        else if (slider == 2) //dark orange
            newColour = new Color(255f / 255f, 140f / 255f, 0f / 255f);
        renderer.color = Color.Lerp(renderer.color, newColour, Time.deltaTime * 3);
    }

    public void AdjustColor(float newSlider)
    {
        slider = newSlider;
    }
}
