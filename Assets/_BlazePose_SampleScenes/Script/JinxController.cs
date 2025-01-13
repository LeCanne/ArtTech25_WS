using Bonjour.Time;
using Mediapipe.BlazePose;
using System.Collections;
using Unity;
using UnityEngine;

public class JinxController : Bonjour.UserController
{
    bool feed;

    protected override void Init()
    {
       base.Init();
        userTimer = new Timer("TimerGame", timeout);
    }
    protected override void Update()
    {
        base.Update();
        if (HasUser() && feed == false)
        {
            
            userTimer.StartTimer();
            feed = true;
        }

    }

    protected override void OnUserTimerStart(TimerData timer)
    {
        Debug.Log("STARTTIMER");
    }

    protected override void OnUserTimerEnd(TimerData timerdata)
    {

        Debug.Log("ENDTIMER");
        StartCoroutine(DoEndSequence());
    }

    public IEnumerator DoEndSequence()
    {
        yield return new WaitForSeconds(5);
        feed = false;
        
        yield return null;
    }


}
