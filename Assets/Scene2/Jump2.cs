using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jump2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float fallMultiplier = 1f;
    public float lowJumpMultiplier = 2f;
    private Vector2 startingPosition = new Vector2(-0.52f, 1.27f);
    public TextMeshProUGUI winText;
    public TextMeshProUGUI IntroductionText;
    public Button nextLevelButton;
    
    //See the Light Tangled - Short Version//
    private string[] correctSequence = {"G2", "F2", "E2", "D2", "E2", "D2", "B2", "C2", "G1", "G2", "F2", "E2", "D2", "E2", "D2", "B2", "C2", "A3", "G2", "F2", "B3", "A3", "G2", "C3", "B3", "A3", "E2", "G2", "A3", "B3", "C3", "F2", "F2", "E2", "G2", "E2", "G2", "B3", "A3", "G2", "B3", "B3", "C3"};
   
    private int sequenceIndex = 0;
    //public Text noteText;

    // Track lives
    public int lives = 3;
    public bool winGame;

    Rigidbody2D rb;
    public AudioSource audioC1;
    public AudioSource audioD1;
    public AudioSource audioE1;
    public AudioSource audioF1;
    public AudioSource audioG1;
    public AudioSource audioA2;
    public AudioSource audioB2;
    public AudioSource audioC2;
    public AudioSource audioD2;
    public AudioSource audioE2;
    public AudioSource audioF2;
    public AudioSource audioG2;
    public AudioSource audioA3;
    public AudioSource audioB3;
    public AudioSource audioC3;
    public AudioSource audioD3;
    public AudioSource audioE3;
    public Note note; 
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Moving Mechanics////////
        float x = transform.position.x;
        float y = transform.position.y;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        x += moveHorizontal * speed * Time.deltaTime;
        y += moveVertical * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Reset vertical velocity
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        Vector2 newPos = new Vector2(x, y);
        transform.position = newPos;
        //////////////////////


        //Unhighlighting and Highlighting Notes part///////////
        foreach (string noteName in correctSequence)
        {
            GameObject noteObject = GameObject.Find(noteName);
            Note noteComponent = noteObject.GetComponent<Note>();
            noteComponent.Unhighlight();
        }

        // Find the GameObject of the next note
        GameObject nextNoteObject = GameObject.Find(correctSequence[sequenceIndex]);

        // Get the Note component from the next note GameObject
        Note nextNote = nextNoteObject.GetComponent<Note>();

        // Highlight the next note in the sequence if it exists and hasn't been collided with yet
        if (sequenceIndex < correctSequence.Length)
        {
            nextNote.Highlight();
        }else{
            nextNote.Unhighlight();
        }
        //////////////////////////////
    }
    //Second Song Scene 2 - I See the Light//
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "KeyPressed")
        {
            note = collision.gameObject.GetComponent<Note>();

            // Unhighlight the note after collision, regardless of correctness
            note.Unhighlight();

            //playing the note sounds when collided with
            if (collision.gameObject.name == "C1")
            {
                audioC1.Play();
                
            }
            else if (collision.gameObject.name == "D1")
            {
                audioD1.Play();
                
            }
            else if (collision.gameObject.name == "E1")
            {
                audioE1.Play();
            }
            else if (collision.gameObject.name == "F1")
            {
                audioF1.Play();
            }
            else if (collision.gameObject.name == "G1")
            {
                audioG1.Play();
            }
            else if (collision.gameObject.name == "A2")
            {
                audioA2.Play();
            }
            else if (collision.gameObject.name == "B2")
            {
                audioB2.Play();
            }
            else if (collision.gameObject.name == "C2")
            {
                audioC2.Play();
            }
            else if (collision.gameObject.name == "D2")
            {
                audioD2.Play();
            }
            else if (collision.gameObject.name == "E2")
            {
                audioE2.Play();
            }
            else if (collision.gameObject.name == "F2")
            {
                audioF2.Play();
            }
            else if (collision.gameObject.name == "G2")
            {
                audioG2.Play();
            }
            else if (collision.gameObject.name == "A3")
            {
                audioA3.Play();
            }
            else if (collision.gameObject.name == "B3")
            {
                audioB3.Play();
            }
            else if (collision.gameObject.name == "C3")
            {
                audioC3.Play();
            }
            else if (collision.gameObject.name == "D3")
            {
                audioD3.Play();
            }
            else if (collision.gameObject.name == "E3")
            {
                audioE3.Play();
            }
            // Check if the current key press is correct according to the sequence
            if (collision.gameObject.name == correctSequence[sequenceIndex])
            {

                note.Unhighlight();
                if(sequenceIndex+1 < correctSequence.Length){
                    sequenceIndex++;
                    //note.Highlight();
                }else{ //don't increment and you win

                    winGame = true;
                    Debug.Log("You win!");
                    GameObject lastNoteObject = GameObject.Find(correctSequence[correctSequence.Length-1]);
                    Note lastNote = lastNoteObject.GetComponent<Note>();
                    lastNote.Unhighlight();
                    transform.position = startingPosition;
                    return;
                }
                // Highlight the next note in the sequence if it exists and hasn't been collided with yet
                if (sequenceIndex < correctSequence.Length)
                {
                // Find the GameObject of the next note
                    GameObject nextNoteObject = GameObject.Find(correctSequence[sequenceIndex]);

                    // Get the Note component from the next note GameObject
                    Note nextNote = nextNoteObject.GetComponent<Note>();
                    nextNote.Highlight();

                }
            }
            else
            {
                // Reduce life count
                lives--;
                // Reset the sequence index
                sequenceIndex = 0;
                // Unhighlight all notes
                // Highlight the first note in the sequence
                GameObject firstNoteObject = GameObject.Find(correctSequence[0]);
                Note firstNote = firstNoteObject.GetComponent<Note>();
                firstNote.Highlight();

                foreach (string noteName in correctSequence)
                {
                    GameObject noteObject = GameObject.Find(noteName);
                    Note noteComponent = noteObject.GetComponent<Note>();
                    noteComponent.Unhighlight();
                }

                
                note.Unhighlight();           
                transform.position = startingPosition;
                Debug.Log("Incorrect key pressed. Lives remaining: " + lives);
                
                // Check for game over
                if (lives <= 0)
                {
                    Debug.Log("Game over!");
                    
                }

                
            }
            
        }
    }
}
