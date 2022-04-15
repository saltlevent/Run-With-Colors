using UnityEngine;

public class CharacterMovementControl : MonoBehaviour
{
    public float speed = 10;
    public float jumpSpeed = 5;

    private Animator characterAnimator;

    private float firstPositionX = 0;

    private Vector3 velocityC = Vector3.zero;
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

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
            {
                Debug.Log("Anlýk: " + Camera.main.ScreenToViewportPoint(touch.position));
                var pos = transform.position;
                pos.x = (Camera.main.ScreenToViewportPoint(touch.position).x - .5f) * 1.8f;
                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocityC, .3f);
            }
            if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
        }
    }
}
