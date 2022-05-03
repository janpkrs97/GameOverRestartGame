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
    [Space] [SerializeField] private Transform behaviorContainer;
    [SerializeField] private BehaviorButton behaviorBtnPrefab;

    [HideInInspector] public List<StudentAnimationController> students = new List<StudentAnimationController>();
    public float GlobalUnrest {get;set;}

    void Start(){    
        if(behaviorContainer && behaviorBtnPrefab){
            List<Behavior> behaviors = Resources.LoadAll<Behavior>("Behaviors/Student").ToList();
            for(int i = 0;i < behaviors.Count;i++){
                BehaviorButton btn = Instantiate(behaviorBtnPrefab, behaviorContainer);
                btn.Set(behaviors[i]);
            }
        }

        studentControlBox.SetActive(false);
    }

    public void SetGlobalUnrest(){
        // in the demo the slider seemed to control how many students were in an unrested state, rather than the unrest of them all.
        // we can change this in another branch when we have a more concrete direction
        GlobalUnrest = unrestSlider.value;
        if(students.Count <= 0) students = FindObjectsOfType<StudentAnimationController>().ToList();
        foreach(StudentAnimationController student in students) student.Unrest = GlobalUnrest;
    }

    public void SetActiveStudent(StudentAnimationController student){
        currSelectedStudent = student;
        studentTitle.text = "Selected Student: " + currSelectedStudent.studentID;
        if(currSelectedStudent && !studentControlBox.activeInHierarchy) studentControlBox.SetActive(true);
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
}