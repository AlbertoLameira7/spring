using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : PlayerStateMachine
{
    [HideInInspector] public NavMeshAgent NavMeshAgentComponent { get; private set; }
    [HideInInspector] public Vector3 Destination { get; set; }
    [HideInInspector] public bool isWalking { get; set; }
    [HideInInspector] public GameObject Target { get; set; }

    private int _layerMask;
    private int _layerMask2;


    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgentComponent = gameObject.GetComponent<NavMeshAgent>();
        _layerMask = 1 << 8;
        _layerMask2 = 1 << 10;
        isWalking = false;
        SetState(new Idle(this));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (!isWalking)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _layerMask2))
                {
                    Target = hit.collider.gameObject;
                    SetState(new Interact(this));
                }
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _layerMask))
            {
                Destination = hit.point;
                SetState(new Walk(this));
            }
        }
    }

    public void ShowInventory()
    {

    }
}
