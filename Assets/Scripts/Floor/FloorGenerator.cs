using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameController controller;

    public List<GameObject> FloorModels;

    public List<GameObject> AddedFloors;

    public GameObject lastFloor;

    public int initFloorCount = 5;

    public int lastZPosition = 16;

    public GameObject itemObject;

    private void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        controller.FloorGeneration += Controller_FloorGeneration;

        splicingNewFloor(3);
    }

    private void Controller_FloorGeneration(object sender, System.EventArgs e)
    {
        splicingNewFloor(3);
    }

    public void splicingNewFloor(int count)
    {
        if (count > 0)
        {
            lastZPosition += 4;
            //ControllerLastFloor;
            controller.setLastFloor = addFloor(Vector3.forward * lastZPosition);

            if (count > 1)
            {
                for (int i = 0; i < count; i++)
                {
                    lastZPosition += 4;
                    addFloor(Vector3.forward * lastZPosition);
                }
                AddItem(.5f);
            }
        }

    }

    private GameObject addFloor(Vector3 positionFloor)
    {
        var floorObject = Instantiate(FloorModels[Random.Range(0, FloorModels.Count)], positionFloor, Quaternion.Euler(0, 0, 0));
        return floorObject;
    }

    private void AddItem(float chance)
    {
        var _chance = Random.Range(0f, 1f);
        if (chance < _chance)
        {
            var floorObject = Instantiate(itemObject, Vector3.forward * lastZPosition + Vector3.right * Random.Range(-.6f, .6f) + Vector3.up * .3f, Quaternion.Euler(0, 0, 0));

        }
    }
}
