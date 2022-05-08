using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject thunderMovement;
    [SerializeField] GameObject Movement; //pikachu
    public Transform firePoint; //get rotation of pikachu 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // shoot the pin when Fire1 is pressed
        if (Input.GetButtonDown("Fire1")) {
            Spawn();
        }
    }

    void Spawn() {
        // pin's position should follow by pikachu's position
        // the pin should be produced at the pikachu's current location
        int x = (int)Movement.transform.position.x;
        int y = (int)Movement.transform.position.y;
        Vector2 position = new Vector2(x,y);
        
        // apply the rotation of firePoint(located at pikachu) as the the correct pin's rotation
        Instantiate(thunderMovement, position, firePoint.rotation);
        
    }   
}
