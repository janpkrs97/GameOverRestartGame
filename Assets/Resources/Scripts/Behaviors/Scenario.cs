using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Scenario", menuName = "New Scenario")]
public class Scenario : ScriptableObject
{
    public enum ScenarioType{
        behaviorBased,
        custom
    }

    public string scenarioName;
    public ScenarioType scenarioType;

    [ShowIf("scenarioType", ScenarioType.behaviorBased)]
    public List<Behavior> behaviorList = new List<Behavior>();

    [ShowIf("scenarioType", ScenarioType.custom)]
    [SerializeReference] public List<Action> customList = new List<Action>();
}
