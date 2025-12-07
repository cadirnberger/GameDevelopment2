using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioClip soundClip;
    
    public void PlaySound(AudioClip clip)
    {
        soundClip = clip;
        AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position);
    }

}
