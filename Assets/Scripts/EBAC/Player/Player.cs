using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Vector2 velocity;
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)||(Input.GetKey(KeyCode.A)))
        {
            // myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(-speed, myRigidbody.linearVelocityY);
        }
        
        if (Input.GetKey(KeyCode.RightArrow)||(Input.GetKey(KeyCode.D)))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(speed, myRigidbody.linearVelocityY);

        }
    }
}
