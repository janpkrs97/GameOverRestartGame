using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;

// Should mostly be used in scenarios
public class Delay_Action : Action
{
    public float waitTime;

    public override void PerformAction(){
        Wait();
    }

    private async void Wait(){
        if(waitTime <= 0) return;
        await WaitForTime();
        if(Application.isPlaying) ActionFinished.Invoke();
    }

    private async Task WaitForTime(){
        await Task.Delay(System.TimeSpan.FromSeconds(waitTime));
    }
}