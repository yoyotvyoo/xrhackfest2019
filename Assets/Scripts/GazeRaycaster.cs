using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ViveSR.anipal.Eye;

public class GazeRaycaster : MonoBehaviour
{
    public enum GazeState { OnTarget = 0, OffTarget = 1 }
    public enum GazeData { Eye = 0, HmdForward = 1, MouseLook = 2 }
    public GazeData gazeData = GazeData.Eye;
    public GameObject gazePoint;
    public static UnityEvent EnterGazeTarget = new UnityEvent();
    public static UnityEvent LeaveGazeTarget = new UnityEvent();
    public static GazeState initialGazeState;

    private GazeState gazeState;
    private readonly GazeIndex[] gazePriority = new GazeIndex[] { GazeIndex.COMBINE, GazeIndex.LEFT, GazeIndex.RIGHT };
    private FocusInfo focusInfo;
    private float gazePointScale = 0.01f;
    private float timerOnTarget = 0f;
    private float timerOffTarget = 0f;

    void Start()
    {
        gazeState = initialGazeState;
        if (gazeData == GazeData.MouseLook)
        {
            Camera.main.gameObject.AddComponent<MouseLook>();
        }
    }

    void Update()
    {
        // Reset the gaze point object
        gazePoint.SetActive(false);
        focusInfo = default(FocusInfo);

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

        if (focusInfo.transform != null)
        {
            if (focusInfo.collider.gameObject.tag == "GazeTarget")
            {
                timerOffTarget = 0f;
                timerOnTarget += Time.deltaTime;
                if (timerOnTarget > 0.5f && gazeState == GazeState.OffTarget)
                {
                    gazeState = GazeState.OnTarget;
                    EnterGazeTarget.Invoke();
                }

                // Draw the gaze point on the target
                gazePoint.SetActive(true);
                gazePoint.transform.position = focusInfo.point;
                gazePoint.transform.localScale = Vector3.one * focusInfo.distance * gazePointScale;
            }
        }
        else
        {
            timerOnTarget = 0f;
            timerOffTarget += Time.deltaTime;
            if (timerOffTarget > 0.5f && gazeState == GazeState.OnTarget)
            {
                gazeState = GazeState.OffTarget;
                LeaveGazeTarget.Invoke();
            }
        }
    }
}
