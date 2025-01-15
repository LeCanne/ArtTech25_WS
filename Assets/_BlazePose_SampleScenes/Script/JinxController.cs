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
    public bool startTimer;
   public GameObject newModel;
    public GameObject textOnBoarding;
    public Animator animatorTitleCard;
    public Animator punchScreen;
    public Animator JinxControllerAnim;

    protected override void Init()
    {
       base.Init();
        userTimer = new Timer("TimerGame", timeout);
    }
    protected override void Update()
    {
        base.Update();

        if(startTimer == true)
        {
            userTimer.StartTimer();
            startTimer = false;
        }
        if (HasUser() && feed == false)
        {
            
            userTimer.StartTimer();
            feed = true;
        }

    }

    protected override void OnUserTimerStart(TimerData timer)
    {
        textOnBoarding.SetActive(false);
        Debug.Log("STARTTIMER");
         newModel.SetActive(true);
    }

    protected override void OnUserTimerEnd(TimerData timerdata)
    {
        
        Debug.Log("ENDTIMER");
    
        StartCoroutine(DoEndSequence());
       
    }

    public IEnumerator DoEndSequence()
    {
        punchScreen.gameObject.SetActive(true);
        JinxControllerAnim.Play("Armature|Punch");
        punchScreen.Play("A_punch");
        yield return new WaitForSeconds(2);
        animatorTitleCard.Play("A_logoStart");
        yield return new WaitForSeconds(1);
        JinxControllerAnim.SetTrigger("PunchTrigger");
        punchScreen.gameObject.SetActive(false);
        
        textOnBoarding.SetActive(true);
        newModel.SetActive(false);
        yield return new WaitForSeconds(3f);
        feed = false;
        yield return null;
    }


}
