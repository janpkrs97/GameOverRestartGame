using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimulationController : Singleton<SimulationController>
{
    public StudentAnimationController currSelectedStudent;
    public GameObject[] studentBehaviourCanvases;

    [Header("References")]
    [SerializeField] private Slider unrestSlider;
    [SerializeField] private TMP_Text studentTitle;
    [SerializeField] private GameObject studentControlBox;

    private List<StudentAnimationController> students = new List<StudentAnimationController>();
    private float globalUnrest;

    void Start(){
        if(!currSelectedStudent) studentControlBox.SetActive(false);
    }

    public void GlobalUnrest(){
        // in the demo the slider seemed to control how many students were in an unrested state, rather than the unrest of them all.
        // we can change this in another branch when we have a more concrete direction
        globalUnrest = unrestSlider.value;
        if(students.Count <= 0) students = FindObjectsOfType<StudentAnimationController>().ToList();
        foreach(StudentAnimationController student in students) student.Unrest = globalUnrest;
    }

    public void SetStudentState(string strState){
        if(!currSelectedStudent) return;

        if(strState == StudentAnimationController.States.idle.ToString())
            currSelectedStudent.SetState(StudentAnimationController.States.idle);
        else if(strState == StudentAnimationController.States.shouting.ToString())
            currSelectedStudent.SetState(StudentAnimationController.States.shouting);
        else if(strState == StudentAnimationController.States.talking.ToString())
            currSelectedStudent.SetState(StudentAnimationController.States.talking);
        else if(strState == StudentAnimationController.States.raisingHand.ToString())
            currSelectedStudent.SetState(StudentAnimationController.States.raisingHand);
    }

    public void SetStudentState(StudentAnimationController.States state){
        if(!currSelectedStudent) return;
        currSelectedStudent.SetState(state);
    }

    public void SetActiveStudent(StudentAnimationController student){
        currSelectedStudent = student;
        studentTitle.text = "Selected Student: " + currSelectedStudent.studentID;
        if(currSelectedStudent && !studentControlBox.activeInHierarchy) studentControlBox.SetActive(true);
    }
}