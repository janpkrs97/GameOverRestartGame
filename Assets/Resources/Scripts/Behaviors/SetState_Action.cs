using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SetState_Action : Action
{   
    public StudentAnimationController.States stateToSet;
    public Target target;

    [ShowIf("target", Target.random)] [Range(1, 100)]
    [Tooltip("What percent of the students should have their state changed")]
    public float randomRange;

    [ShowIf("target", Target.unrestLevels)] [Range(0, 1)]
    [Tooltip("What level of unrest do students need to trigger")]
    public float unrestRange;


    public override void PerformAction()
    {
        if(target == Target.selectedStudent)
            SimulationController.Instance.SetStudentState(stateToSet);
        else if(target == Target.all)
            foreach(StudentAnimationController student in SimulationController.Instance.students) student.SetState(stateToSet);
        else if(target == Target.random){
            List<StudentAnimationController> tempList = new List<StudentAnimationController>(SimulationController.Instance.students);

            int percent = (int)(randomRange / tempList.Count);
            for(int i = 0;i < percent;i++){
                int randNum = Random.Range(0, tempList.Count);
                tempList[randNum].SetState(stateToSet);
                tempList.RemoveAt(randNum);
            }
        }
        else if(target == Target.unrestLevels){
            foreach(StudentAnimationController student in SimulationController.Instance.students)
                if(student.Unrest >= unrestRange) student.SetState(stateToSet);
        }
    }   
}
