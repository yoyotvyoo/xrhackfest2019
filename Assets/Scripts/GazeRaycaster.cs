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
    public float gazePointScale = 0.04f;

    private GazeState gazeState;
    private readonly GazeIndex[] gazePriority = new GazeIndex[] { GazeIndex.COMBINE, GazeIndex.LEFT, GazeIndex.RIGHT };
    private FocusInfo focusInfo;
    private Ray gazeRay;
    private float timerOnTarget = 0f;
    private float timerOffTarget = 0f;

    void Start()
    {
		#if UNITY_EDITOR
			gazeData = GazeData.MouseLook;
		#else
			gazeData = GazeData.Eye;
		#endif
		
        gazeState = initialGazeState;
        if (gazeData == GazeData.MouseLook)
        {
            Camera.main.gameObject.AddComponent<MouseLook>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            gazeData = GazeData.HmdForward;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gazeData = GazeData.Eye;
        }

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

        bool isHit = focusInfo.transform != null;
        bool isGazeTarget = false;
        if (isHit)
        {
            isGazeTarget = focusInfo.collider.gameObject.tag == "GazeTarget";

            // Draw the gaze point on the target
            gazePoint.SetActive(true);
            gazePoint.transform.position = focusInfo.point;
            gazePoint.transform.localScale = Vector3.one * focusInfo.distance * gazePointScale;
        }
        else
        {
            var distance = 2000f;
            gazePoint.transform.position = gazeRay.GetPoint(distance);
            gazePoint.transform.localScale = Vector3.one * distance * gazePointScale;
        }

        if (isHit && isGazeTarget)
        {
            timerOffTarget = 0f;
            timerOnTarget += Time.deltaTime;
            if (timerOnTarget > 1.0f && gazeState == GazeState.OffTarget)
            {
                gazeState = GazeState.OnTarget;
                EnterGazeTarget.Invoke();
            }
        }
        else
        {
            timerOnTarget = 0f;
            timerOffTarget += Time.deltaTime;
            if (timerOffTarget > 1.0f && gazeState == GazeState.OnTarget)
            {
                gazeState = GazeState.OffTarget;
                LeaveGazeTarget.Invoke();
            }
        }
    }
}
