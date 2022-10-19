using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbPlayer;
   
    public float speed = 10.0f;
    public GameObject attack;
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Health();
    }

    public void Health()
    { 
        currentHealth = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {


        // rbPlayer.AddForce(direction * speed, ForceMode.Acceleration);  [this was used on a previous movement method that didn't work]
        AttackPower();
        LimitMovement();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed); // This code was used on the previous project.
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed); // Now added the float before name (Maybe this new version needs it?)

    }

    public void AttackPower()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            Instantiate(attack, transform.position, attack.transform.rotation);
        }
     

    }

    private void LimitMovement()
    {
        if (transform.position.z > 100)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 100);
        }
        else if (transform.position.z < 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        }

        if (transform.position.x > 50)
        {
            transform.position = new Vector3(50, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -50)
        {
            transform.position = new Vector3(-50, transform.position.y, transform.position.z);
        }
    }
}

