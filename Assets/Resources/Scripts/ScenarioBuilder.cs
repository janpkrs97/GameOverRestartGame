using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ScenarioBuilder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_Text scenarioOrderText;
    [SerializeField] Transform scenarioContainer;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] BehaviorButton btnPrefab;

    [Header("Keys")]
    [SerializeField] string saveLocation;

    List<Behavior> newScenario = new List<Behavior>();

    void Start(){
        List<Behavior> behaviors = Resources.LoadAll<Behavior>("").ToList();
        for(int i = 0;i < behaviors.Count;i++){
            BehaviorButton btn = Instantiate(btnPrefab, scenarioContainer);
            btn.Set(behaviors[i]);
            btn.GetComponent<Button>().onClick.AddListener(() => AddBehavior(btn));
        }

        gameObject.SetActive(false);
    }

    public void AddBehavior(BehaviorButton behaviorBtn){
        newScenario.Add(behaviorBtn.GetBehavior());
        UpdateText();
    }

    private void UpdateText(){
        scenarioOrderText.text = "";
        for(int i = 0;i < newScenario.Count;i++){
            if(i == newScenario.Count-1)
                scenarioOrderText.text += newScenario[i].behaviorName;
            else
                scenarioOrderText.text += newScenario[i].behaviorName + " -> ";
        }
    }

    public void Clear(){
        newScenario.Clear();
        scenarioOrderText.text = "Empty";
        inputField.text = "";
    }

    public void Build(){
        // Instance of Scenario SO
        Scenario scenario = ScriptableObject.CreateInstance<Scenario>();

        // Fill scenario info
        scenario.scenarioType = Scenario.ScenarioType.behaviorBased;
        scenario.scenarioName = inputField.text;
        for(int i = 0;i < newScenario.Count;i++){
            scenario.behaviorList.Add(newScenario[i]);
        }

        // Save Asset
        if(Debug.isDebugBuild){
            AssetDatabase.CreateAsset(scenario, saveLocation + "/" + inputField.text + ".asset");
            AssetDatabase.SaveAssets();
        }
        else{
            SimulationController.Instance.customScenarioList.Add(scenario);
        }

        // System Updates
        Debug.Log(inputField.text + " scenario created");
        SimulationController.Instance.RebuildScenarioButtons();
    }

    private void OnEnable() {
        Clear();
    }
}
