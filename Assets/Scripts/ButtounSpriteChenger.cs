using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteChanger : MonoBehaviour
{
    private Button button;           // Reference to the Button component
    public Sprite normalSprite;     // The normal state sprite
    public Sprite clickedSprite;    // The clicked state sprite

    private Image buttonImage;      // Reference to the Image component of the Button

    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetComponent<Button>();
        // Get the Image component from the Button
        buttonImage = button.GetComponent<Image>();

        // Set the normal sprite initially
        buttonImage.sprite = normalSprite;

        // Add a listener to call the ChangeSprite method when the button is clicked
        button.onClick.AddListener(ChangeSprite);
    }

    // This method is called when the button is clicked
    void ChangeSprite()
    {
        // Toggle between the normal and clicked sprites
        if (buttonImage.sprite == normalSprite)
        {
            buttonImage.sprite = clickedSprite;
        }
        else
        {
            buttonImage.sprite = normalSprite;
        }
    }
}
