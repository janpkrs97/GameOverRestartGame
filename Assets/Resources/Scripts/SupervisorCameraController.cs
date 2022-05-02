using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupervisorCameraController : MonoBehaviour
{
    public int supervisorCameraCount;
    public int activeSupervisorCamera;

    [SerializeField]
    private GameObject[] supervisorCameras;

    void Start()
    {
        supervisorCameraCount = supervisorCameras.Length;
        DisableAllCameras();
        EnableCamera(0);
        activeSupervisorCamera = 0;
    }

    public void EnableCamera(int camID)
    {
        supervisorCameras[camID].SetActive(true);
    }

    public void DisableAllCameras()
    {
        for (int i = 0; i < supervisorCameraCount; i++)
        {
            supervisorCameras[i].SetActive(false);
        }
    }

    public void SwitchCamera()
    {
        DisableAllCameras();

        int activeCam = activeSupervisorCamera;

        switch (activeCam)
        {
            case 0:
                {
                    EnableCamera(1);
                    activeSupervisorCamera = 1;
                    break;
                }

            case 1:
                {
                    EnableCamera(2);
                    activeSupervisorCamera = 2;
                    break;
                }

            case 2:
                {
                    EnableCamera(0);
                    activeSupervisorCamera = 0;
                    break;
                }

            default:
                {
                    EnableCamera(0);
                    activeSupervisorCamera = 0;
                    break;
                }
        }

        
    }
}
