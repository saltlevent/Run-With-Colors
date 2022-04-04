using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsLevent;

public class CharacterOperation : MonoBehaviour
{
    public LayerMask layer;

    public float speed=10;

    private RaycastHit hit;

    private ColorFloor _colorFloor;

    void Start()
    {
        
    }

    void Update()
    {   
        Physics.Raycast(transform.position,Vector3.down,out hit,10f,layer);
        _colorFloor = hit.collider.GetComponent<SingleFloorModel>().colorFloorE;

        //transform.Translate(Vector3.forward*speed*Time.deltaTime,Space.World);
        GetComponent<Rigidbody>().AddTorque(Vector3.right,ForceMode.Force);
    }

}
