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
        supervisorCameraCount = 3;
        activeSupervisorCamera = 1;
        DisableAllCameras();
        EnableCamera(1);
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
        int activeCam = 0;

        switch (activeCam)
        {
            case 1:
                {
                    break;
                }

            case 2:
                {
                    break;
                }

            case 3:
                {
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
}
