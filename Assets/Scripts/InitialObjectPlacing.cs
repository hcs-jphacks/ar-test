using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialObjectPlacing : MonoBehaviour
{

    ARRaycastManager raycastManager;
    ARAnchorManager anchorManager;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        anchorManager = GetComponent<ARAnchorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: あとで
    }
}
