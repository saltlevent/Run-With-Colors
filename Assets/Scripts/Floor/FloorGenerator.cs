using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public List<GameObject> FloorModels;

    public List<GameObject> AddedFloors;

    public int initFloorCount = 5;

    public int lastZPosition = 0;


    private void Start()
    {
        initFloor();
        for(int i=0;i<100;i++)
        splicingNewFloor();
    }

    private void splicingNewFloor()
    {
        lastZPosition += 4;
        addFloor(Vector3.forward*lastZPosition);
    }

    private void addFloor(Vector3 positionFloor)
    {
        Instantiate(FloorModels[Random.Range(0,FloorModels.Count)],positionFloor,Quaternion.Euler(0,0,0));
    }

    private void initFloor()
    {
        for(int i = 0; i < initFloorCount; i++)
        {
            addFloor(Vector3.forward*i*4);
            lastZPosition = i * 4;
        }
    }

}
