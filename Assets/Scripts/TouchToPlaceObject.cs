using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TouchToPlaceObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.All))
            {
                Instantiate(objectPrefab, hitResults[0].pose.position, Quaternion.identity);
            }
        }
    }
}
