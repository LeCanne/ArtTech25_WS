using Bonjour.Time;
using Mediapipe.BlazePose;
using System.Collections;
using Unity;
using UnityEngine;
using System;



public  class JinxController : Bonjour.UserController
{
   [Header("JinxSpecs")]
   public bool feed;
   public GameObject newModel;

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
         newModel.SetActive(true);
    }

    protected override void OnUserTimerEnd(TimerData timerdata)
    {

        Debug.Log("ENDTIMER");
        StartCoroutine(DoEndSequence());
        newModel.SetActive(false);
    }

    public IEnumerator DoEndSequence()
    {
        yield return new WaitForSeconds(5);
        feed = false;
        
        yield return null;
    }


}
