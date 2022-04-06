using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public List<GameObject> FloorModels;

    public List<GameObject> AddedFloors;

    public GameObject lastFloor;

    public int initFloorCount = 5;

    public int lastZPosition = 16;

    public bool createRoad = false;

    private void Start()
    {
        splicingNewFloor();
    }
    private void Update()
    {
        if (createRoad)
        {
            splicingNewFloor();
            createRoad = false;
        }
    }

    public void splicingNewFloor()
    {
        lastZPosition += 4;
        addFloor(Vector3.forward*lastZPosition);
    }

    private void addFloor(Vector3 positionFloor)
    {
        lastFloor = Instantiate(FloorModels[Random.Range(0,FloorModels.Count)],positionFloor,Quaternion.Euler(0,0,0));
    }

}
