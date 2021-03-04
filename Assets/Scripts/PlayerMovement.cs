using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _nav;
    private int _layerMask;

    // Start is called before the first frame update
    void Start()
    {
        _nav = gameObject.GetComponent<NavMeshAgent>();
        _layerMask = 1 << 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _layerMask))
            {
                Vector3 lookAtAngle = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(lookAtAngle);
                _nav.destination = hit.point;
            }
        }
    }
}
