using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM4 : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
        rb.velocity = movement;
    }

    



    
}
