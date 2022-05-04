using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public LayerMask layer;

    public float addTime = 10;

    private RaycastHit hit;

    private GameController controller;


    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        var ray = Physics.Raycast(transform.position, Vector3.back, out hit, .5f, layer);
        Debug.DrawRay(transform.position + Vector3.forward*.2f, Vector3.back * .5f);
        if(ray)
        {
            controller.gameCountdown += addTime;
            Destroy(gameObject);
        }
    }
}
