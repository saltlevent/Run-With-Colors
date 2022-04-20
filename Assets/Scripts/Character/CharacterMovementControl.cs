using UnityEngine;

public class CharacterMovementControl : MonoBehaviour
{
    public float speed = 10;
    public float jumpSpeed = 5;
    public float JumpTime = 3;

    private Animator characterAnimator;

    private float firstPositionX = 0;

    private Vector3 velocityC = Vector3.zero;
    private float jumpTimeCounter = 0;

    private void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();
        firstPositionX = transform.position.x;
    }
    private void Update()
    {
        characterAnimator.SetBool("Running", true);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Began)
            {
                characterAnimator.SetBool("Jumping", false);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                var pos = transform.position;
                pos.x = (Camera.main.ScreenToViewportPoint(touch.position).x - .5f) * 1.8f;
                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocityC, .3f);
            }
            else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                characterAnimator.SetBool("Jumping", true);
                jumpTimeCounter = 0;
            }
        }
        else if(characterAnimator.GetBool("Jumping"))
        {
            jumpTimeCounter += Time.deltaTime;
            Debug.Log((int)jumpTimeCounter);
            if (jumpTimeCounter >= JumpTime)
            {
                characterAnimator.SetBool("Jumping", false);
                jumpTimeCounter = 0;
            }
        }
    }
}
