using UnityEngine;

public class PunchSFX : MonoBehaviour

{
    public AudioSource audioSource;

    public void eventAnim()
    {
        audioSource.Play();
    }


}
