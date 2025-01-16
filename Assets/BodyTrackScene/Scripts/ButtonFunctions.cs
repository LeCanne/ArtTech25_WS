using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    
    public Animator ExpressionAnimator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Happy()
    {
        ExpressionAnimator.Play("A_VFX_jinxHappy");
    }

    public void Angry()
    {
        ExpressionAnimator.Play("A_VFX_jinxAngry");
    }

    public void Sad()
    {
        ExpressionAnimator.Play("A_VFX_jinxSad");
    }

    public void Confused()
    {
        ExpressionAnimator.Play("A_VFX_jinxConfused");
    }



    public void End()
    {
        ExpressionAnimator.SetTrigger("emotionEnd");
    }

 
}
