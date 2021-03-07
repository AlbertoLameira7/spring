using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTile : MonoBehaviour
{
    private Color _defaultColor, _highlightColor;
    private bool _isUsed;


    // Start is called before the first frame update
    void Start()
    {
        _defaultColor = gameObject.GetComponent<Renderer>().material.color;
        _highlightColor = Color.white;
        _isUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseTile()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        _isUsed = true;
    }

    void OnMouseEnter()
    {
        if (!_isUsed)
        {
            gameObject.GetComponent<Renderer>().material.color = _highlightColor;
        }
    }

    void OnMouseExit()
    {
        if (!_isUsed)
        {
            gameObject.GetComponent<Renderer>().material.color = _defaultColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hmmm");
    }
}
