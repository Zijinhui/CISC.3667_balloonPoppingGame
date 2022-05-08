using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    public float speed = 12f;
    [SerializeField] Rigidbody2D rigid;
    private float objectWidth;
    private float objectHeight;
    [SerializeField] bool isFacingRight = true;
    public Collider2D coll;
    

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectHeight =transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;

        if (coll.gameObject.tag == "Player") {
            coll.isTrigger = !coll.isTrigger;
            Debug.Log(coll.isTrigger);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Pin: "+objectWidth);
        if (transform.position.x >= screenBounds.x - objectWidth - 0.06) {
            isFacingRight = false;
            Destroy(gameObject);
        }
        if (transform.position.x <= screenBounds.x*-1 + objectWidth + 0.06) {
            isFacingRight = true;
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
    //     if (isFacingRight) {
    //         transform.Translate(Vector2.right * Time.deltaTime*9f);
    //     }
    //     if (!isFacingRight) {
    //         transform.Translate(Vector2.left * Time.deltaTime*9f);
    // }
}

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Target")) {
           Destroy(gameObject); 
        }
    }
   
}
