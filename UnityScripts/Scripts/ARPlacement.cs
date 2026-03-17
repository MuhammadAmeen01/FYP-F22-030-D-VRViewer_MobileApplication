// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;

// // public class ARPlacement : MonoBehaviour
// // {


// //     public GameObject arObjectToSpawn;
// //     public GameObject placementIndicator;
// //     private GameObject spawnedObject;
// //     private Pose PlacementPose;
// //     private ARRaycastManager aRRaycastManager;
// //     private bool placementPoseIsValid = false;
// //      List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

// //     void Start()
// //     {
// //         aRRaycastManager = FindObjectOfType<ARRaycastManager>();
// //     }

// //     // need to update placement indicator, placement pose and spawn 
// //     void Update()
// //     {
// //         if(spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
// //         {
// //             ARPlaceObject();
// //         }


// //         UpdatePlacementPose();
// //         UpdatePlacementIndicator();


// //     }
// //     void UpdatePlacementIndicator()
// //     {
// //         if(spawnedObject == null && placementPoseIsValid)
// //         {
// //             placementIndicator.SetActive(true);
// //             placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
// //         }
// //         else
// //         {
// //             placementIndicator.SetActive(false);
// //         }
// //     }

// //     void UpdatePlacementPose()
// //     {
// //         var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

// //         var hits = new List<ARRaycastHit>();
// //         aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

// //         placementPoseIsValid = hits.Count > 0;
// //         if(placementPoseIsValid)
// //         {
// //             PlacementPose = hits[0].pose;
// //         }
// //     }

// //     void ARPlaceObject()
// //     {
// //         // spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
// //         spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
// //     }


// // }



// using System.Collections.Generic;

//2322
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;

// public class ARPlacementAndMovement : MonoBehaviour
// {
//     public GameObject objectToPlace;
//     public GameObject placementIndicator;
//     public GameObject spawnedObject;

//     private ARRaycastManager arRaycastManager;
//     private Pose placementPose;
//     private bool placementPoseIsValid = false;
//     private bool objectSpawned = false;

//     private void Start()
//     {
//         arRaycastManager = FindObjectOfType<ARRaycastManager>();
//     }

//     private void Update()
//     {
//         UpdatePlacementPose();
//         UpdatePlacementIndicator();

//         if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//         {
//             if (!objectSpawned)
//             {
//                 SpawnObject();
//             }
//             else
//             {
//                 SelectObjectAndMove();
//             }
//         }
//     }

//     private void UpdatePlacementPose()
//     {
//         var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
//         var hits = new List<ARRaycastHit>();
//         arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

//         placementPoseIsValid = hits.Count > 0;
//         if (placementPoseIsValid)
//         {
//             placementPose = hits[0].pose;
//         }
//     }

//     private void UpdatePlacementIndicator()
//     {
//         if (placementPoseIsValid)
//         {
//             placementIndicator.SetActive(true);
//             placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
//         }
//         else
//         {
//             placementIndicator.SetActive(false);
//         }
//     }

//     private void SpawnObject()
//     {
//         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//         {
//             spawnedObject = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
//             objectSpawned = true;
//         }
//     }

//     private void SelectObjectAndMove()
//     {
//         RaycastHit hit;
//         Ray ray = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);
//         if (Physics.Raycast(ray, out hit))
//         {
//             if (hit.transform.gameObject == spawnedObject)
//             {
//                 spawnedObject.transform.localScale *= 1.2f;
//                 spawnedObject.transform.position += new Vector3(0.1f, 0.1f, 0.1f);
//             }
//         }
//     }
// }
//2233
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementAndMovement : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public GameObject spawnedObject;

    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool isPlacingObject = false;

    private void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
    }

    private void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            // Adjust the placement pose rotation to match the camera's rotation
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid && !isPlacingObject)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void HandleTouch()
    {
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!isPlacingObject)
            {
                PlaceObject();
            }
            else
            {
                SelectObjectAndMove();
            }
        }
    }

    private void PlaceObject()
    {
        spawnedObject = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        isPlacingObject = true;

        // Disable plane detection for the spawned object
        arPlaneManager.SetTrackablesActive(false);
    }

    private void SelectObjectAndMove()
    {
        RaycastHit hit;
        Ray ray = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == spawnedObject)
            {
                spawnedObject.transform.localScale *= 1.2f;
                spawnedObject.transform.position += new Vector3(10f, 10f, 10f);
            }
        }
    }

    private void LateUpdate()
    {
        HandleTouch();
    }
}
