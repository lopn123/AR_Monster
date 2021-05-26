using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceOnPlace : MonoBehaviour
{
    [SerializeField] private ARRaycastManager arRaycast;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCenterMonster();
    }

    private void UpdateCenterMonster()
    {
        Vector3 center = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if(arRaycast.Raycast(center, hits, TrackableType.Planes))
        {
            Pose placePose = hits[0].pose;

            if(!monster.activeSelf)
            {
                monster.SetActive(true);
            }
            monster.transform.position = placePose.position;
            monster.transform.LookAt(mainCamera.transform);
        }
    }
}
