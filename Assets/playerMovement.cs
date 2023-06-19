using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D Rigidbody;

    private bool canMove;
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
        if (Rigidbody.velocity == still) canMove = true;
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
        if (right)
        {
            Leap(new Vector2(moveSpeed, 0));
        }
        if (up)
        {
            Leap(new Vector2(0, moveSpeed));
        }
        if (down)
        {
            Leap(new Vector2(0, -moveSpeed));
        }
    }

    private void Leap(Vector2 direction)
    {
        Rigidbody.velocity = still;
        Rigidbody.AddForce(direction);
        canMove = false;
    }
}
