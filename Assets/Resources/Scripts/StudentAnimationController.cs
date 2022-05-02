using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentAnimationController : MonoBehaviour
{
    public int studentID;

    [Header("Unrest Handling")] // should contain some noise/randomness so not all students are changing unrest at the same pace
    [SerializeField] private float unrestCatchup;
    [SerializeField] private float unrestDecrease;
    
    int UnrestHash; // faster than string comparison

    private float unrest; // current unrest
    public float Unrest {get;set;} // max unrest - for now

    // states
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
        if(unrest < Unrest)
            unrest += Time.deltaTime * unrestCatchup;

        if(unrest > Unrest)
            unrest -= Time.deltaTime * unrestDecrease;

        if(unrest < 0)
            unrest = 0;
        if(unrest > 1)
            unrest = 1;
    }

    private void PlayAnimations(){
        animator.SetFloat(UnrestHash, unrest);
        animator.SetBool("isShouting", shouting);
        animator.SetBool("isTalking", talking);
        animator.SetBool("raiseHand", raiseHand);
    }

    private void DebugTesting(){
        if(!Debug.isDebugBuild) return;

        if(Input.GetKeyDown("s")){
            shouting = !shouting;
            talking = false;
            raiseHand = false;
        }

        if(Input.GetKeyDown("t")){
            shouting = false;
            talking = !talking;
            raiseHand = false;
        }

        if(Input.GetKeyDown("h")){
            shouting = false;
            talking = false;
            raiseHand = !raiseHand;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("student selected: " + studentID);
        SimulationController.Instance.currSelectedStudentID = studentID;
    }
}
