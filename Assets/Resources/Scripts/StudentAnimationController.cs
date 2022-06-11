using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Unity.XR.CoreUtils;

public class StudentAnimationController : MonoBehaviour
{
    public int studentID;

    [Header("Unrest Handling")] // should contain some noise/randomness so not all students are changing unrest at the same pace
    [SerializeField] private float unrestCatchup;
    [SerializeField] private float unrestDecrease;
    
    private float currentUnrest;
    public float Unrest {get;set;} // max unrest

    int UnrestHash; // faster than string comparison

    [Header("References")]
    [SerializeField] MultiAimConstraint aim;
    [SerializeField] RigBuilder rig;

    public enum States{
        idle,
        shouting,
        talking,
        raisingHand
    }

    [Header("State Management")]
    [SerializeField] private States state;

    private bool idle;
    private bool shouting;
    private bool talking;
    private bool raiseHand;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        UnrestHash = Animator.StringToHash("unrestLevel");
        //if(rig) SetAimTarget();
        if(rig) Invoke("SetAimTarget", 0.2f);
    }

    void Update()
    {
        DebugTesting();
        LevelOfUnrest();
        PlayAnimations();
    }

    private void LevelOfUnrest()
    {
        if(currentUnrest < Unrest)
            currentUnrest += Time.deltaTime * unrestCatchup;

        if(currentUnrest > Unrest)
            currentUnrest -= Time.deltaTime * unrestDecrease;

        if(currentUnrest < 0)
            currentUnrest = 0;
        if(currentUnrest > 1)
            currentUnrest = 1;
    }

    private void PlayAnimations(){
        animator.SetFloat(UnrestHash, currentUnrest);
        animator.SetBool("isShouting", shouting);
        animator.SetBool("isTalking", talking);
        animator.SetBool("raiseHand", raiseHand);
    }

    private void DebugTesting(){
        if(!Debug.isDebugBuild) return;

        if(Input.GetKeyDown("0"))
            SetState(States.idle);

        if(Input.GetKeyDown("1"))
            SetState(States.shouting);

        if(Input.GetKeyDown("2"))
            SetState(States.talking);

        if(Input.GetKeyDown("3"))
            SetState(States.raisingHand);
    }

    public void SetState(States _state){
        state = _state;

        idle = (state == States.idle);
        shouting = (state == States.shouting);
        talking = (state == States.talking);
        raiseHand = (state == States.raisingHand);
    }

    private void SetAimTarget(){
        GameObject teacherObject = null;
        
        if(!SimulationController.Instance.riggingByRoot) teacherObject = GameObject.FindObjectOfType<XROrigin>().gameObject;
        else teacherObject = GameObject.FindObjectOfType<XROrigin>().gameObject.transform.parent.gameObject;
        
        if(!teacherObject) return;

        var data = aim.data.sourceObjects;
        data.Clear();
        data.Add(new WeightedTransform(teacherObject.transform, 1));
        aim.data.sourceObjects = data;
        rig.Build();
    }

    public void OnMouseDown()
    {
        SimulationController.Instance.SetActiveStudent(this);
    }
}
