using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnPortal : MonoBehaviour
{
    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private Camera arCamera;

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

    void Start()
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
                // position、rotationを設定
                hitPose.position.y = hitPose.position.y - 1;
                var rotation = Quaternion.identity;
                rotation.y = arCamera.transform.rotation.y;

                // ポータルPrefabのインスタンスをspawnedObjectに代入
                spawnedObject = Instantiate(objectPrefab, hitPose.position, rotation);
            }
            else
            {
                // positionの再設定
                hitPose.position.y = hitPose.position.y - 1;
                spawnedObject.transform.position = hitPose.position;

                // rotationの再設定
                var rotation = Quaternion.identity;
                rotation.y = arCamera.transform.rotation.y;
                spawnedObject.transform.rotation = rotation;
            }
        }
    }
}
