
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FindLocomotion : MonoBehaviour
{
    public TeleportationArea telArea;

    void Update()
    {
        if (telArea.teleportationProvider == null)
        {
            Debug.Log(FindObjectOfType<TeleportationProvider>());
            telArea.teleportationProvider = FindObjectOfType<TeleportationProvider>();
        }
    }
}