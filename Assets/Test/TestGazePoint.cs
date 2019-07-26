//========= Copyright 2018, HTC Corporation. All rights reserved. ===========
using System;
using UnityEngine;

namespace ViveSR.anipal.Eye
{
    public class TestGazePoint : MonoBehaviour
    {
        private FocusInfo FocusInfo;
        private readonly float MaxDistance = 20;
        private readonly GazeIndex[] GazePriority = new GazeIndex[] { GazeIndex.COMBINE, GazeIndex.LEFT, GazeIndex.RIGHT };

        public GameObject gazePoint;

        private bool useHmdForward = false;

        private void Start()
        {
            if (!SRanipal_Eye_Framework.Instance.EnableEye)
            {
                enabled = false;
                return;
            }
        }

        private void Update()
        {
            gazePoint.SetActive(false);

            if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING &&
                SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT) return;

            foreach (GazeIndex index in GazePriority)
            {
                Ray GazeRay;
                if (SRanipal_Eye.Focus(index, out GazeRay, out FocusInfo, MaxDistance))
                {
                    if (FocusInfo.transform != null)
                    {
                        gazePoint.SetActive(true);
                        gazePoint.transform.position = FocusInfo.point;
                        var gazePointScale = FocusInfo.distance * 0.01f;
                        gazePoint.transform.localScale = new Vector3(gazePointScale, gazePointScale, gazePointScale);
                    }

                    // DartBoard dartBoard = FocusInfo.transform.GetComponent<DartBoard>();
                    // if (dartBoard != null) dartBoard.Focus(FocusInfo.point);
                    break;
                }
            }
        }
    }
}