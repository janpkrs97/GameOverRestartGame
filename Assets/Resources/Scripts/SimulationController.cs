using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

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
    [SerializeField] private Slider currStudentUnrestSlider;
    
    [Space] [SerializeField] private Transform scenarioContainer;

    [HideInInspector] public List<StudentAnimationController> students = new List<StudentAnimationController>();
    public float GlobalUnrest {get;set;}

    void Start(){    
        SetupUI();
        if(students.Count <= 0) students = FindObjectsOfType<StudentAnimationController>().ToList();
    }

    private void SetupUI(){
        if(behaviorContainer && behaviorBtnPrefab){
            List<Behavior> behaviors = Resources.LoadAll<Behavior>("Behaviors/Student").ToList();
            for(int i = 0;i < behaviors.Count;i++){
                BehaviorButton btn = Instantiate(behaviorBtnPrefab, behaviorContainer);
                btn.Set(behaviors[i]);
            }
        }

        if(scenarioContainer){
            List<Scenario> scenarios = Resources.LoadAll<Scenario>("Behaviors/Scenarios").ToList();
            for(int i = 0;i < scenarios.Count;i++){
                BehaviorButton btn = Instantiate(behaviorBtnPrefab, scenarioContainer);
                btn.Set(scenarios[i]);
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

    public void SetCurrentStudentUnrest(){
        if(currSelectedStudent) currSelectedStudent.Unrest = currStudentUnrestSlider.value;
    }

    public void SetActiveStudent(StudentAnimationController student){
        currSelectedStudent = student;
        studentTitle.text = "Selected Student: " + currSelectedStudent.studentID;
        currStudentUnrestSlider.value = student.Unrest;
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

    public void SetSelectedSliderValue(float v) => currStudentUnrestSlider.value = v;

    public void PlayScenario(Scenario scenario, BehaviorButton btn){
        if(scenario.scenarioType == Scenario.ScenarioType.custom){
            for(int i = 0;i < scenario.customList.Count - 1;i++){
                // clear any previously existing listeners from the last time the scenario was ran
                scenario.customList[i].ActionFinished.RemoveAllListeners();

                scenario.customList[i].ActionFinished.AddListener(scenario.customList[i+1].PerformAction);
            }

            scenario.customList[scenario.customList.Count-1].ActionFinished.AddListener(btn.Reset);
            scenario.customList[0].PerformAction();
        }
        else if(scenario.scenarioType == Scenario.ScenarioType.behaviorBased){
            for(int i = 0;i < scenario.behaviorList.Count - 1;i++){
                for(int j = 0;j < scenario.behaviorList[i].actions.Count;j++){
                    // clear any previously existing listeners from the last time the scenario was ran
                    scenario.behaviorList[i].actions[j].ActionFinished.RemoveAllListeners();

                    if(j == scenario.behaviorList[i].actions.Count-1){
                        scenario.behaviorList[i].actions[j]
                                        .ActionFinished.AddListener(scenario.behaviorList[i+1].actions[0].PerformAction);
                    }else{
                        scenario.behaviorList[i].actions[j]
                                        .ActionFinished.AddListener(scenario.behaviorList[i].actions[j+1].PerformAction);
                    }
                    
                }
            }

            int n = scenario.behaviorList.Count-1;
            scenario.behaviorList[n].actions[scenario.behaviorList[n].actions.Count-1].ActionFinished.AddListener(btn.Reset);
            scenario.behaviorList[0].actions[0].PerformAction();
        }
    }
}