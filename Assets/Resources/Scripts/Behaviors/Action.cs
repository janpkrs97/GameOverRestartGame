using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Action
{
    public enum Target{
        selectedStudent,
        all,
        random,
        unrestLevels
    }


    public virtual void PerformAction(){}
}
