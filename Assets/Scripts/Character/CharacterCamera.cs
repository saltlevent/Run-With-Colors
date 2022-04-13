using UnityEngine;

public class CharacterCamera : MonoBehaviour
{

    public Transform Character;
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = Character.TransformPoint(new Vector3(0, .86f, -.68f));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
