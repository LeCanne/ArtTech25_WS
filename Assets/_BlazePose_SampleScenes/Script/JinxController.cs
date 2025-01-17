using Bonjour.Time;
using Mediapipe.BlazePose;
using System.Collections;
using Unity;
using UnityEngine;
using System;
using NUnit.Framework;
using UnityEngine.UI;



public  class JinxController : Bonjour.UserController
{
   [Header("JinxSpecs")]
   public bool feed;
    public bool startTimer;
   public GameObject newModel;
    //public GameObject textOnBoarding;
    public Animator animatorTitleCard;
    public Animator punchScreen;
    public GameObject noPunchScreen;
    public Animator JinxControllerAnim;
    public ButtonFunctions bT;
    
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
        
        //textOnBoarding.SetActive(false);
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
        foreach(Button gameObj in bT.buttons)
        {
            
            gameObj.interactable = false;
        }
        punchScreen.gameObject.SetActive(true);
        noPunchScreen.gameObject.SetActive(false);
        
        bT.SetBlend(0, 0, 0, 0, 100);
        JinxControllerAnim.Play("Armature|Punch");
        yield return new WaitForSeconds(5);
      
        animatorTitleCard.Play("A_logoStart");
        yield return new WaitForSeconds(1);
        JinxControllerAnim.SetTrigger("PunchTrigger");
        punchScreen.gameObject.SetActive(false);
        noPunchScreen.gameObject.SetActive(true);
        
        bT.SetBlend(0, 0, 0, 0, 0);
        yield return new WaitForSeconds(2);
        foreach (Button gameObj in bT.buttons)
        {
           
            gameObj.interactable = true;
        }

        //textOnBoarding.SetActive(true);
        newModel.SetActive(false);
        yield return new WaitForSeconds(3f);
        feed = false;
        yield return null;
    }


}
