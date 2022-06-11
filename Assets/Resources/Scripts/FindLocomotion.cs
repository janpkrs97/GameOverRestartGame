
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FindLocomotion : MonoBehaviour
{
    public GameObject telProvObj;

    void Awake()
    {
        telProvObj = GameObject.FindGameObjectWithTag("TeleportationProvider");
        Debug.Log(telProvObj);
        TeleportationProvider telProv = telProvObj.GetComponent<TeleportationProvider>();
        //this.gameObject.GetComponent<TeleportationArea>().TeleportationProvider = telProv;
    }
}