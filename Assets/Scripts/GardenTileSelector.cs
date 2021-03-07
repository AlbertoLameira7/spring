using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTileSelector : MonoBehaviour
{
    private int _layerMask;

    // Start is called before the first frame update
    void Start()
    {
        _layerMask = 1 << 10;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _layerMask))
            {
                //hit.collider.gameObject.GetComponent<GardenTile>().UseTile();

                Debug.Log(hit.transform.gameObject.layer);
            }
        }
    }
}
