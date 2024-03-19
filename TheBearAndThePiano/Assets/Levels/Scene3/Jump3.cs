using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Jump3 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float fallMultiplier = 1f;
    public float lowJumpMultiplier = 2f;
    private Vector2 startingPosition = new Vector2(-0.52f, 1.27f);
    public TextMeshProUGUI winText;
    public TextMeshProUGUI IntroductionText;
    public Button nextLevelButton;
    public HealthManager healthManager;
    
    //Remember Me Coco- Short Version//
    private string[] correctSequence = {"D2", "E2", "C2", "G1", "E1" ,"F1", "C2","C2", "D2", "D2", "E2", "E2", "D2", "G1",
"E2", "F2", "E2","E2", "D2", "D2", "B2", "C2", "A3", "A3", "G2", "G2","E2","E2", "C2",
"G2", "F2", "F2","E2","E2", "A2", "G2", "G2", "F2", "F2","E2","E2", "C2","E2","D2", "D2",
"C2", "E2", "C2", "G1"};
   
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

        // Check if the player is out of bounds
        if (!IsInBounds(new Vector3(x, y)))
        {
            // Move the player back to the starting position
            transform.position = startingPosition;

            Debug.Log("You're out of bounds! Stop!");
            return;
        }

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

       
        if (sequenceIndex < correctSequence.Length)
        {
            nextNote.Highlight();
        }else{
            nextNote.Unhighlight();
        }
        if (winGame)
        {
            StartCoroutine(TransitionToNextScene());
            winGame = false; // Prevent this from running again
        }
        IEnumerator TransitionToNextScene()
    {
        
        yield return new WaitForSeconds(2f); 

        // Load the next scene by index or name
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        //////////////////////////////
    }
    bool IsInBounds(Vector3 position)
    {
        //Hard Code 
        float rightBoundX = 8.99f;
        float leftBoundX = -9.62f;
        float lowerBoundY = -5.14f;
        float upperBoundY = 9f;//a little above the screen to ensure the bear reaches piano tiles far 

        // Check if the player's position is within the bounds
        return position.x >= leftBoundX && position.x <= rightBoundX && position.y >= lowerBoundY && position.y <= upperBoundY;
    }
    //First Song Scene 1 - Itsy Bitsy Spider//
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
                
                healthManager.health--;
                healthManager.UpdateHearts();
                healthManager.CheckGameOver();
                
                // Check for game over
                if (healthManager.health <= 0)
                {
                    Debug.Log("Game over!");
                    
                }
                else
                {
                    // If not game over, reset the sequence or handle as necessary
                    ResetSequence();
                }
            }
        }
    }
    private void ResetSequence()
    {
        sequenceIndex = 0;

        // Unhighlight all notes
        foreach (string noteName in correctSequence)
        {
            GameObject noteObject = GameObject.Find(noteName);
            if (noteObject != null)
            {
                Note noteComponent = noteObject.GetComponent<Note>();
                noteComponent.Unhighlight();
            }
        }

        // Highlight the first note in the sequence
        GameObject firstNoteObject = GameObject.Find(correctSequence[0]);
        if (firstNoteObject != null)
        {
            Note firstNote = firstNoteObject.GetComponent<Note>();
            firstNote.Highlight();
        }

        // Reset the player position if needed
        transform.position = startingPosition;

        Debug.Log("Incorrect key pressed. Lives remaining: " + healthManager.health);
    }
}
