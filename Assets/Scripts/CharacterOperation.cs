using ToolsLevent;
using UnityEngine;

public class CharacterOperation : MonoBehaviour
{
    public LayerMask layer;

    public float speed = 10;

    private RaycastHit hit;

    private ColorFloor _colorFloor;

    private FloorGenerator floorGenerator;

    public GameObject currentFloor;

    void Start()
    {
        floorGenerator = GameObject.Find("FloorGenerator").GetComponent<FloorGenerator>();
    }

    void Update()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, 10f, layer);

        if (hit.collider != null)
        {
            _colorFloor = hit.collider.GetComponent<SingleFloorModel>().colorFloorE;
            currentFloor = hit.collider.GetComponentInParent<FloorOperation>().gameObject;

            if (floorGenerator.lastFloor.name == hit.collider.GetComponentInParent<FloorOperation>().name)
            {
                floorGenerator.splicingNewFloor();
            }
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }

}
