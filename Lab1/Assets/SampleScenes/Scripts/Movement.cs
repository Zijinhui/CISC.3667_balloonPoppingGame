using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] float movement;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 600f;
    [SerializeField] bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump")) {
            jumpPressed = true;
        }
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate() {
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (jumpPressed && isGrounded) {
            Jump();
            isGrounded = true; //Additional Line
        }
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight) {
            Flip();
        }
    }

    void Jump() {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
    }

    void Flip() {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
}
