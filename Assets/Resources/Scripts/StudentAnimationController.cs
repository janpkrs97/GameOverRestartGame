using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAnimationController : MonoBehaviour
{
    public SimulationController simulationController;
    public int studentID;

    public bool talkingAnimation;
    public bool shoutAnimation;
    public bool raiseHandAnimation;
    public bool idleAnimation;

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
        simulationController.currSelectedStudentID = studentID;
    }

    public void LevelOfUnrest()
    {

    }

    public void PlayIdleAnimation()
    {
        talkingAnimation = false;
        shoutAnimation = false;
        raiseHandAnimation = false;
        idleAnimation = true;
    }
}
