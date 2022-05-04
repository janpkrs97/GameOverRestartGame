using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [HideInInspector] public UnityEvent ActionFinished = new UnityEvent();
}
