using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public SkinnedMeshRenderer SkinnedMeshRenderer;
    public Animator ExpressionAnimator;
    public Animator GlitchAnimator;
    public AudioSource audioSource;
    

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
        SetBlend(100, 0, 0, 0, 0);
        ExpressionAnimator.Play("A_VFX_jinxHappy");
    }

    public void Angry()
    {
        SetBlend(0, 100, 0, 0, 0);
        ExpressionAnimator.Play("A_VFX_jinxAngry");
    }

    public void Sad()
    {
        SetBlend(0, 0, 100, 0, 0);
        ExpressionAnimator.Play("A_VFX_jinxSad");
    }

    public void Confused()
    {
        SetBlend(0, 0, 0, 100, 0);
        ExpressionAnimator.Play("A_VFX_jinxConfused");
    }



    public void End()
    {
        ExpressionAnimator.SetTrigger("emotionEnd");
    }

    public void SetBlend(float happy, float sad, float angry, float confused, float crazy)
    {
        audioSource.Play();
        GlitchAnimator.Play("A_glitch");
        SkinnedMeshRenderer.SetBlendShapeWeight(0, happy);
        SkinnedMeshRenderer.SetBlendShapeWeight(1, sad);
        SkinnedMeshRenderer.SetBlendShapeWeight(2, angry);
        SkinnedMeshRenderer.SetBlendShapeWeight(3, confused);
        SkinnedMeshRenderer.SetBlendShapeWeight(4, crazy);
    }

 
}
