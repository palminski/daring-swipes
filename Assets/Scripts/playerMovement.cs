using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D Rigidbody;


    public bool canMove =true;
    private Vector2 still = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            ProcessInput();
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Hit wall");
        canMove = true;
    }

    void ProcessInput()
    {
        bool left = Input.GetKeyDown(KeyCode.LeftArrow);
        bool right = Input.GetKeyDown(KeyCode.RightArrow);
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        bool down = Input.GetKeyDown(KeyCode.DownArrow);

        if (left)
        {
            Leap(new Vector2(-moveSpeed, 0));
        }
        else if (right)
        {
            Leap(new Vector2(moveSpeed, 0));
        }
        else if (up)
        {
            Leap(new Vector2(0, moveSpeed));
        }
        else if (down)
        {
            Leap(new Vector2(0, -moveSpeed));
        }
    }

    private void Leap(Vector2 direction)
    {
        if (Rigidbody.velocity != still)
        {
            canMove = false;
        }
        Rigidbody.velocity = still;
        Rigidbody.AddForce(direction);
    }
}
