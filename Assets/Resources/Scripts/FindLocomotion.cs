using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FindLocomotion : MonoBehaviour
{
    public TeleportationProvider teleportationProvider;

    void Awake()
    {
        GameObject teleportationArea = GameObject.FindGameObjectWithTag("TeleportationArea");
        //teleportationArea.GetComponent<TeleportationArea>().TeleportationProvider = teleportationProvider;
    }
}
