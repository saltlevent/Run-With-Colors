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
        Physics.Raycast(transform.position, Vector3.down, out hit, 100f, layer);

        if (GetComponentInChildren<Animator>().GetBool("Jumping"))
        {
            controller.setCharacterColorFloor = ToolsLevent.ColorFloor.None;
            controller.setCharacterFloor = hit.collider.GetComponentInParent<FloorOperation>().gameObject;
        }
        else if (hit.collider != null)
        {
            controller.setCharacterColorFloor = hit.collider.GetComponent<SingleFloorModel>().colorFloorE;
            controller.setCharacterFloor = hit.collider.GetComponentInParent<FloorOperation>().gameObject;
        }
        else
        {
        }
    }

}
