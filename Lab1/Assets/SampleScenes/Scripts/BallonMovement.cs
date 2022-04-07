using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    public float speed = 1000;
    //[SerializeField] Rigidbody2D balloon;
    private float objectWidth;
    private float objectHeight;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectHeight =transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;

        if (controller == null){
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }

        // Starting in 0s
        // new balloon will be launched every 1s.
        InvokeRepeating("resizeBalloon", 0, 1);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        //Right boundary
        if (transform.position.x >= screenBounds.x - objectWidth) {
            isFacingRight = false;
        }
        //Left boundary
        if (transform.position.x <= screenOrigo.x+3) {
            isFacingRight = true;
        }
        //Debug.Log(transform.position.x);
    }

    void FixedUpdate() {
        if (isFacingRight) {
            // change the spedd pf balloon
            transform.Translate(Vector2.right * Time.deltaTime*35f);
        }
        if (!isFacingRight) {
            transform.Translate(Vector2.left * Time.deltaTime*35f);
    }
}

    void resizeBalloon() {
        // increase scale just need to fill in change vales into ()
        // like +0.1f || -0.1f
        gameObject.transform.localScale += new Vector3(1f,1f,0);
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        Debug.Log("Add Score!");
        if(collider.gameObject.CompareTag("Pin")) {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            controller.GetComponent<ScoreTracker>().UpdateScore();
        }    
    }
}
