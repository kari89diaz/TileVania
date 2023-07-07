using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    Vector2 moveImput;
    Rigidbody2D myRigidBody;
    Animator myanimator;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveImput = value.Get<Vector2>();
        Debug.Log(moveImput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveImput.x*runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        
    }
    
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
            myanimator.SetBool("isRunning", true);
        }
        else
        {
            myanimator.SetBool("isRunning", false);
        }

    }
}
