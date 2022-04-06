using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject character;
    public GameObject floorGenerator;

    private FloorGenerator _floorGenerator;
    private CharacterOperation _characterOperation;
    private void Start()
    {
        _floorGenerator = floorGenerator.GetComponent<FloorGenerator>();
        _characterOperation = character.GetComponent<CharacterOperation>();
    }

    private void Update()
    {
        if(_floorGenerator.lastFloor.GetHashCode() == this._characterOperation.currentFloor.GetHashCode())
        {
            Debug.Log(_characterOperation.currentFloor.name);
        }
    }
}
