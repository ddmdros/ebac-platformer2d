using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2(.1f,0);
    public float speed;
    public float forceJump = 2;

    void Update()
    {

        HandleJump();
        HandleMoviment();

    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            // myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(-speed, myRigidbody.linearVelocityY);
        }

        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(speed, myRigidbody.linearVelocityY);
        }

        if (myRigidbody.linearVelocity.x > 0)
        {
            myRigidbody.linearVelocity += friction;
        }
        else if (myRigidbody.linearVelocity.x < 0)
        {
            myRigidbody.linearVelocity -= friction;

        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            myRigidbody.linearVelocity = Vector2.up * forceJump;
        
    }

}
