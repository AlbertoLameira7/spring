using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _cameraSmoothing = 5f;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - _target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCamPos = _target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, _cameraSmoothing * Time.deltaTime);
    }
}
