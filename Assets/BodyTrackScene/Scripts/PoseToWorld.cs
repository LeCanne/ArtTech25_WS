using Bonjour;
using Mediapipe.BlazePose;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PoseToWorld : MonoBehaviour
{
    public UserController poseController;
    public Transform[] poseTransforms = new Transform[32];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PoseOutput(); 
    }

    void PoseOutput()
    {
        for (int i = 11; i <= 32; i++)
        {
            if (poseController.GetFilteredPoseWorldLandmark(i).w >= 0.99f)
            {


                Debug.Log("Reproducing Pose" + i);
                poseTransforms[i - 11].localPosition = new Vector3(poseController.GetPoseWorldLandmark(i).x, poseController.GetPoseWorldLandmark(i).y, poseController.GetPoseWorldLandmark(i).z) * 0.001f;
            }
        }
    }
}
