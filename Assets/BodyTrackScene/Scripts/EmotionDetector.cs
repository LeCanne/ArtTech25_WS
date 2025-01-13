using MoodMe;
using Unity.VisualScripting;
using UnityEngine;

public class EmotionDetector : MonoBehaviour
{
    public EmotionsManager EmotionsManager;
    public Animator emotionsAnimator;
    float sad;
    float surprised;
    float neutral;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        neutral = EmotionsManager.Neutral - 0.5f;
        sad = EmotionsManager.Sad;
        surprised = EmotionsManager.Surprised;

        if(surprised > sad && surprised > neutral)
        {
            emotionsAnimator.SetBool("isConfused", true);

        }
        else
        {
            emotionsAnimator.SetBool("isConfused", false);
        }

        if (sad > surprised && sad > neutral)
        {
            emotionsAnimator.SetBool("isSad", true);
        }
        else
        {
            emotionsAnimator.SetBool("isSad", false);
        }

        if (neutral > surprised && neutral > sad)
        {
            emotionsAnimator.SetBool("emotionEnd", true);
        }
        else
        {
            emotionsAnimator.SetBool("emotionEnd", false);
        }


    }
}
