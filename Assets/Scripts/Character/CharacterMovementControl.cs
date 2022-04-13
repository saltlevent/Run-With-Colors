using UnityEngine;

public class CharacterMovementControl : MonoBehaviour
{
    public float speed = 10;

    private Animator characterAnimator;

    private void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {

#if UNITY_EDITOR
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            characterAnimator.SetBool("Running", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            characterAnimator.SetBool("Running", true);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            characterAnimator.SetBool("Running", true);
            transform.Translate(Vector3.left * Time.deltaTime);
        }
#endif

        //#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
            {
                Debug.Log("Anlýk: " + touch.position);
            }
            else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {

            }
        }
        //#endif
    }
}
