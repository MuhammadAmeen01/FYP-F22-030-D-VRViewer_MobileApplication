// using UnityEngine.XR.ARFoundation;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpawnManager : MonoBehaviour
// {

//     [SerializeField]
//     ARRaycastManager m_RaycastManager;
//     List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
//     [SerializeField]
//     GameObject spawnablePrefab;
//     GameObject spawnedObject;
//     // Start is called before the first frame update
//     void Start()
//     {
//         spawnedObject = null;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.touchCount == 0)
//             return;

//         if(m_RaycastManager.Raycast(Input.GetTouch(0).position,m_Hits)){

//             if(Input.GetTouch(0).phase == TouchPhase.Began){
//                 SpawnPrefab(m_Hits[0].pose.position);
//             }
//             else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null){
//                 spawnedObject.transform.position = m_Hits[0].pose.position;
//             }
//             if(Input.GetTouch(0).phase == TouchPhase.Ended){
//                 spawnedObject = null;
//             }

//         }

//     }
//     private void SpawnPrefab(Vector3 spawnPosition){
//         if(spawnablePrefab==null)
//         {
//             spawnedObject = Instantiate(spawnablePrefab,spawnPosition,Quaternion.identity);
//         }
//     }
// // }
// using UnityEngine.XR.ARFoundation;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpawnManager : MonoBehaviour
// {
//     [SerializeField]
//     ARRaycastManager m_RaycastManager;
//     List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
//     [SerializeField]
//     GameObject spawnablePrefab;
//     GameObject spawnedObject;
//     Touch touch;

//     // Start is called before the first frame update
//     void Start()
//     {
//         spawnedObject = null;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.touchCount == 0)
//             return;

//         touch = Input.GetTouch(0);

//         if (m_RaycastManager.Raycast(touch.position, m_Hits))
//         {

//             if (touch.phase == TouchPhase.Began && spawnedObject == null)
//             {
//                 SpawnPrefab(m_Hits[0].pose.position);
//             }
//             else if (touch.phase == TouchPhase.Moved && spawnedObject != null)
//             {
//                 spawnedObject.transform.position = m_Hits[0].pose.position;
//             }
//             else if (touch.phase == TouchPhase.Ended)
//             {
//                 spawnedObject = null;
//             }

//             // Detect user input for resizing
//             if (spawnedObject != null && touch.phase == TouchPhase.Stationary)
//             {
//                 Vector2 previousTouchPosition = touch.position - touch.deltaPosition;
//                 float touchDeltaMagnitude = (touch.position - previousTouchPosition).magnitude;
//                 float objectScale = spawnedObject.transform.localScale.x + touchDeltaMagnitude * 0.01f;
//                 spawnedObject.transform.localScale = new Vector3(objectScale, objectScale, objectScale);
//             }
//         }
//     }

//     private void SpawnPrefab(Vector3 spawnPosition)
//     {
//     if (spawnablePrefab != null && spawnedObject == null)
//     {
//         spawnedObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
//     }
//     }
// }
