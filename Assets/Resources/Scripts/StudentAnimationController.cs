using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAnimationController : MonoBehaviour
{
    public int studentID;

    [Header("Unrest Handling")] // should contain some noise/randomness so not all students are changing unrest at the same pace
    [SerializeField] private float unrestCatchup;
    [SerializeField] private float unrestDecrease;
    
    private float currentUnrest;
    public float Unrest {get;set;} // max unrest

    int UnrestHash; // faster than string comparison

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

        if(Input.GetKeyDown("i"))
            SetState(States.idle);

        if(Input.GetKeyDown("s"))
            SetState(States.shouting);

        if(Input.GetKeyDown("t"))
            SetState(States.talking);

        if(Input.GetKeyDown("h"))
            SetState(States.raisingHand);
    }

    public void SetState(States _state){
        state = _state;

        idle = (state == States.idle);
        shouting = (state == States.shouting);
        talking = (state == States.talking);
        raiseHand = (state == States.raisingHand);
    }

    public void OnMouseDown()
    {
        SimulationController.Instance.SetActiveStudent(this);
    }
}
