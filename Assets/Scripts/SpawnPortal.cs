using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnPortal : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private GameObject spawnedObject;

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, hitResults, TrackableType.All))
        {
            Pose hitPose = hitResults[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectPrefab, hitResults[0].pose.position, Quaternion.identity);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = Quaternion.identity;
            }
        }
    }
}
