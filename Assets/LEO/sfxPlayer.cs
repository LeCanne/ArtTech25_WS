using UnityEngine;

public class sfxPlayer : MonoBehaviour

{
    public AudioSource punchAS;
    public AudioSource logoAS;

    public void punchAnimEvent()
    {
        punchAS.Play();
    }

    public void logoAnimEvent()
    {
        logoAS.Play();
    }
}
