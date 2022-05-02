using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAnimationController : MonoBehaviour
{
    public SimulationController simulationController;
    public int studentID;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("student selected: " + studentID);
    }
}
