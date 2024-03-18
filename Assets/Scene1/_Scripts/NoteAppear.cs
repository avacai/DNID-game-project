using UnityEngine;

public class Note : MonoBehaviour
{
    public Sprite highlightedSprite;
    private Sprite defaultSprite;
    public bool highlighted = false; // Track if the note is highlighted

    public void Start()
    {
        // Store the default sprite of the note
        defaultSprite = GetComponent<SpriteRenderer>().sprite;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collider is the player
        if (collision.gameObject.CompareTag("Bear"))
        {
            // Highlight the note
            Highlight();
        }
    }

    public void Highlight()
    {
        // Change the sprite to the highlighted sprite
        GetComponent<SpriteRenderer>().sprite = highlightedSprite;
        highlighted = true; // Set highlighted to true
    }

    public void Unhighlight()
    {
        // Restore the default sprite
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        highlighted = false; // Set highlighted to false
    }
}
