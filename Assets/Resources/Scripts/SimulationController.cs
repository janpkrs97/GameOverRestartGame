using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SimulationController : Singleton<SimulationController>
{
    public int currSelectedStudentID = 0;
    public GameObject[] studentBehaviourCanvases;

    [Header("References")]
    [SerializeField] private Slider unrestSlider;

    private List<StudentAnimationController> students = new List<StudentAnimationController>();
    private float globalUnrest;

    public void GlobalUnrest(){
        // in the demo the slider seemed to control how many students were in an unrested state, rather than the unrest of them all.
        // we can change this in another branch when we have a more concrete direction
        globalUnrest = unrestSlider.value;
        if(students.Count <= 0) students = FindObjectsOfType<StudentAnimationController>().ToList();
        foreach(StudentAnimationController student in students) student.Unrest = globalUnrest;
    }
}