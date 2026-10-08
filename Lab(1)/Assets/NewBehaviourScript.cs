using System. Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float moveSpeed;
public float jumpHeight; 
public KeyCode Spacebar; 
public KeyCode L;
public KeyCode R;

public Transform groundCheck;
public float groundCheckRadius;
public LayerMask whatIsGround; 
private bool grounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(Spacebar) && grounded)
      {
         Jump();
      } 

      if (Input.GetKey(L)){
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().linearVelocity.y);

        if(GetComponent<SpriteRenderer>() != null){
            GetComponent<SpriteRenderer>().flipX = true;
        }
      }

      if (Input.GetKey(R)){
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().linearVelocity.y);

        if(GetComponent<SpriteRenderer>() != null){
            GetComponent<SpriteRenderer>().flipX = false;
        }
      }
      
    }

    void Jump(){
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, jumpHeight);
    }

    void FixedUpdate(){
      grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);  
    }

}
