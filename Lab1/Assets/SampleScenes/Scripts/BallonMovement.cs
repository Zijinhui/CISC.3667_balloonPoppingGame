using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallonMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    public float speed = 5f;
    //[SerializeField] Rigidbody2D balloon;
    private float objectWidth;
    private float objectHeight;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    [SerializeField] int level;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;

        if (controller == null){
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }

        // Starting in 0s
        // new balloon will be launched every 1s.
        InvokeRepeating("resizeBalloon", 0, 1);

        level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Level: "+level);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        //Right boundary
        if (transform.position.x >= screenBounds.x - objectWidth-0.53f) {
            isFacingRight = false;
        }
        //Left boundary
        if (transform.position.x <= screenOrigo.x+3) {
            isFacingRight = true;
        }
        //Debug.Log(transform.position.x);

        Debug.Log("Balloon Scale: " + gameObject.transform.localScale);
        // If the balloon increase to a limit scale, destroy it and score=0
        if (gameObject.transform.localScale.x > 3.0f) {
            Destroy(gameObject);
            //restart the current level
            SceneManager.LoadScene(level);
        }
    }

    void FixedUpdate() {
        if (isFacingRight) {
            // change the speed of balloon
            transform.Translate(Vector2.right * Time.deltaTime*1f);
        }
        if (!isFacingRight) {
            transform.Translate(Vector2.left * Time.deltaTime*1f);
    }     
}

    void resizeBalloon() {
        // increase scale just need to fill in change vales into ()
        // like +0.1f || -0.1f
        gameObject.transform.localScale += new Vector3(0.1f,0.1f,0);

        // The value of the balloon will goes down 1 point when each resizing
        controller.GetComponent<ScoreTracker>().ChangeValue();
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        Debug.Log("Add Score!");
        if(collider.gameObject.CompareTag("Pin")) {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            controller.GetComponent<ScoreTracker>().UpdateScore();

            // move to next level
            if (level < 5) {
                SceneManager.LoadScene(level+1);
            }
            
        }    
    }
}
