using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViveSR.anipal.Eye;

public class GazeRaycaster : MonoBehaviour
{
    public enum GazeData { Eye = 0, HmdForward = 1, MouseLook = 2 }
    public GazeData gazeData = GazeData.Eye;
    public GameObject gazePoint;

    private readonly GazeIndex[] gazePriority = new GazeIndex[] { GazeIndex.COMBINE, GazeIndex.LEFT, GazeIndex.RIGHT };
    private FocusInfo focusInfo;
    private float gazePointScale = 0.01f;
    private float timerOnTarget = 0f;
    private float timerOffTarget = 0f;

    void Start()
    {
        if (gazeData == GazeData.MouseLook)
        {
            Camera.main.gameObject.AddComponent<MouseLook>();
        }
    }

    void Update()
    {
        // Get FocusInfo for the gameobject being gazed
        if (gazeData == GazeData.Eye)
        {
            if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING &&
                SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT) return;

            foreach (GazeIndex index in gazePriority)
            {
                Ray gazeRay;
                if (SRanipal_Eye.Focus(index, out gazeRay, out focusInfo, Mathf.Infinity))
                {
                    // Got one. Ready to go.
                    break;
                }
            }
        }
        else
        {
            // Just use the camera's transform for case HmdForward and MouseLook
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                focusInfo = new FocusInfo
                {
                    point = hit.point,
                    normal = hit.normal,
                    distance = hit.distance,
                    collider = hit.collider,
                    rigidbody = hit.rigidbody,
                    transform = hit.transform
                };
            }
        }

        // Draw the gaze point on the gazed point
        if (focusInfo.transform == null)
        {
            gazePoint.SetActive(false);
            return;
        }
        else
        {
            gazePoint.SetActive(true);
            gazePoint.transform.position = focusInfo.point;
            gazePoint.transform.localScale = Vector3.one * focusInfo.distance * gazePointScale;
        }
    }
}
