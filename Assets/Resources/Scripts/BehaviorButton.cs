using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BehaviorButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button btn;
    [SerializeField] private TMP_Text txt;

    private Behavior behavior;

    public void Set(Behavior b){
        behavior = b;

        txt.text = behavior.behaviorName;
    }

    public void Perform(){
        for(int i = 0;i < behavior.actions.Count;i++){
            behavior.actions[i].PerformAction();
        }
    }
}
