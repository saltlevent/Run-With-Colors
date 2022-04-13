using UnityEngine;

public class CharacterOperation : MonoBehaviour
{
    public LayerMask layer;

    private RaycastHit hit;

    public GameObject currentFloor;

    void Update()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, 10f, layer);

        if (hit.collider != null)
        {
            currentFloor = hit.collider.GetComponentInParent<FloorOperation>().gameObject;
        }
    }

}
