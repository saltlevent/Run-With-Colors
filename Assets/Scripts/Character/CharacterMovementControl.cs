using UnityEngine;

public class CharacterMovementControl : MonoBehaviour
{
    public float speed = 10;
    public float jumpSpeed = 5;
    public float JumpTime = 1;

    private Animator characterAnimator;

    private float firstPositionX = 0;

    private Vector3 velocityC = Vector3.zero;
    private float jumpTimeCounter = 0;

    GameController gameController;

    private void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();

        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        firstPositionX = transform.position.x;

    }
    private void Update()
    {
        switch (gameController.gameState)
        {
            case ToolsLevent.GameState.Paused:
                break;
            case ToolsLevent.GameState.Stopped:
                break;
            case ToolsLevent.GameState.Playing:
                movement();
                break;
            case ToolsLevent.GameState.Finished:
                break;
            default:
                break;
        }
    }


    void movement()
    {

        characterAnimator.SetBool("Running", true);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Began)
            {
                characterAnimator.SetBool("Jumping", false);
                gameController.characterIsGrounded = true;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                var pos = transform.position;
                pos.x = (Camera.main.ScreenToViewportPoint(touch.position).x - .5f) * 1.8f;
                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocityC, .3f);
            }
            else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                characterAnimator.SetBool("Jumping", true);
                gameController.characterIsGrounded = false;
                jumpTimeCounter = 0;
            }
        }
        else if (characterAnimator.GetBool("Jumping"))
        {
            jumpTimeCounter += Time.deltaTime;

            if (jumpTimeCounter >= JumpTime)
            {
                characterAnimator.SetBool("Jumping", false);
                gameController.characterIsGrounded = true;
                jumpTimeCounter = 0;
            }
        }
    }
}
