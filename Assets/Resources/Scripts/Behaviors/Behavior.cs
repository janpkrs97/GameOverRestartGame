using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Behavior", menuName = "New Behavior")]
public class Behavior : ScriptableObject
{
    [Header("Behavior Information")]
    public string behaviorName;
    [Space] [SerializeReference] 
    public List<Action> actions = new List<Action>();
}
