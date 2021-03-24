using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : PlayerStateMachine
{
    [HideInInspector] public Vector3 Destination { get; set; }
    [HideInInspector] public bool isWalking { get; set; }
    [HideInInspector] public GameObject Target { get; set; }

    public List<GameObject> InteractableObjects { get; private set; }
    public NavMeshAgent NavMeshAgentComponent { get; private set; }

    public InventoryObject inventory;
    public GameObject inventoryUI;

    private int _layerMaskGround;
    private int _layerMaskGardenTile;

    void Awake()
    {
        NavMeshAgentComponent = gameObject.GetComponent<NavMeshAgent>();
        _layerMaskGround = 1 << 8;
        _layerMaskGardenTile = 1 << 10;
        isWalking = false;
        InteractableObjects = new List<GameObject>();
        SetState(new Idle(this));
    }

    void Update()
    {
        UpdateState();

        // TODO: don't move if player clicked on garden tile
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (!isWalking)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _layerMaskGardenTile))
                {
                    Target = hit.collider.gameObject;
                    SetState(new Interact(this));
                }
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _layerMaskGround))
            {
                Destination = hit.point;
                SetState(new Walk(this));
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
        } else
        {
            inventoryUI.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractableObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObjects.Remove(other.gameObject);
    }
}
