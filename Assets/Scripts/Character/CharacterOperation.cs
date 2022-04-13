using UnityEngine;

public class CharacterOperation : MonoBehaviour
{
    public LayerMask layer;

    private RaycastHit hit;

    public GameObject currentFloor;

    public GameController controller;

    public string floorColorText = "";
    private void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, 10f, layer);

        if (hit.collider != null)
        {
            controller.setCharacterColorFloor = hit.collider.GetComponent<SingleFloorModel>().colorFloorE;
            controller.setCharacterFloor = hit.collider.GetComponentInParent<FloorOperation>().gameObject;   
        }
    }

}
