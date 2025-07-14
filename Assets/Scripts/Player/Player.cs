using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f,0);
    public float speed;
    public float speedRun;
    public float _currentSpeed;
    public float forceJump = 2; // it should be jumpForce


    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float fallScaleY = 0.7f;
    public float jumpScaleX = 0.7f;
    public float fallScaleX = 1.5f;
    public float jumpAnimationDuration = .3f;
    public float fallAnimationDuration = .1f;
    public Ease ease = Ease.OutBack;
    private bool hasLanded = false;

    void Update()
    {

        HandleJump();
        HandleMoviment();

    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else 
            _currentSpeed = speed;
        
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            // myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(-_currentSpeed, myRigidbody.linearVelocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.linearVelocity = new Vector2(_currentSpeed, myRigidbody.linearVelocity.y);
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
        {
            hasLanded = false;

            myRigidbody.linearVelocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidbody.transform);
           
            
            HandleScaleJump();

        }
    }

    private void HandleScaleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.transform.DOScaleY(jumpScaleY, jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease); 
            myRigidbody.transform.DOScaleX(jumpScaleX, jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease); 
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !hasLanded)
        {
            hasLanded = true;

            DOTween.Kill(myRigidbody.transform);
            myRigidbody.transform.DOScaleY(fallScaleY, fallAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            myRigidbody.transform.DOScaleX(fallScaleX, fallAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        }

    
    }
}
