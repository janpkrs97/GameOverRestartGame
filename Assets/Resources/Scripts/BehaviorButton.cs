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
    [SerializeField] private Image img;
    [Space]
    [SerializeField] private Color activeColor = new Color(0.25f, 1, 0.25f, 1);
    [SerializeField] private Color offColor = new Color(1, 1, 1, 1);

    private Behavior behavior;
    private Scenario scenario;

    private bool active = false;
    private bool toggle = false;

    public void Set(Behavior b){
        behavior = b;
        txt.text = behavior.behaviorName;
    }

    public void Set(Scenario s){
        scenario = s;
        txt.text = scenario.scenarioName;
        toggle = true;
    }

    public void Perform(){
        if(behavior){
            for(int i = 0;i < behavior.actions.Count;i++){
                behavior.actions[i].PerformAction();
            }
        }
        else if(scenario){
            if(!active){
                img.color = activeColor;
                active = true;
                SimulationController.Instance.PlayScenario(scenario, this);
            }else{
                img.color = offColor;
                active = false;
                
                // Clear events
                if(scenario.scenarioType == Scenario.ScenarioType.behaviorBased){
                    for(int i = 0;i < scenario.behaviorList.Count - 1;i++){
                        for(int j = 0;j < scenario.behaviorList[i].actions.Count;j++){
                            scenario.behaviorList[i].actions[j].ActionFinished.RemoveAllListeners();
                        }
                    }
                }
                else if(scenario.scenarioType == Scenario.ScenarioType.custom){
                    for(int i = 0;i < scenario.customList.Count - 1;i++){
                        scenario.customList[i].ActionFinished.RemoveAllListeners();
                    }
                }
                
            }
        }
    }

    public void Reset(){
        active = false;
        img.color = offColor;
    }
}
