using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOperation : MonoBehaviour
{
    public LayerMask layer;

    private RaycastHit hit;

    private FloorOperation.ColorFloor _colorFloor;
    void Start()
    {
        
    }

    void Update()
    {   
        Physics.Raycast(transform.position,Vector3.down,out hit,10f,layer);
        _colorFloor = hit.collider.GetComponent<FloorOperation>().colorFloor;
        Debug.Log(_colorFloor.ToString());

    }

}
