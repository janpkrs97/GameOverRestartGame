using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Unrest_Action : Action
{
    public Target target;
    [Range(0,1)] public float unrest;
    [ShowIf("target", Target.random)] [Range(1, 100)] public float randomRange;

    public override void PerformAction()
    {
        if(target == Target.selectedStudent)
            SimulationController.Instance.currSelectedStudent.Unrest = unrest;
        else if(target == Target.all)
            foreach(StudentAnimationController student in SimulationController.Instance.students) student.Unrest = unrest;
        else if(target == Target.random){
            List<StudentAnimationController> tempList = new List<StudentAnimationController>(SimulationController.Instance.students);

            int percent = (int)(randomRange / tempList.Count);
            for(int i = 0;i < percent;i++){
                int randNum = Random.Range(0, tempList.Count);
                tempList[randNum].Unrest = unrest;
                tempList.RemoveAt(randNum);
            }
        }
        else
            Debug.LogWarning("No implementation for unrest targetting " + target.ToString());
    }
}
