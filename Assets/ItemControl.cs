using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public LayerMask layer;

    private RaycastHit hit;

    public GameController controller;
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Physics.Raycast(transform.position + Vector3.left * .2f + Vector3.back * .2f, Vector3.right, out hit, .5f, layer);
        if(hit.collider != null)
        {
            controller.gameCountdown += 5;
            Destroy(gameObject);
        }
    }
}
