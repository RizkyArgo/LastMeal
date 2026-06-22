using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Musik;
    public AudioSource SFX;
    public AudioClip backsound;
    public AudioClip sampah;
    public AudioClip ngetik;
    public AudioClip laper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
        SFX.loop = true;
    }

    public void PlayBGM(AudioClip music)
    {
        Musik.clip = music;
        Musik.loop = true;
        Musik.volume = 0.3f;
        Musik.Play();
    }

    public void StopBGM()
    {
        Musik.Stop();
    }
}
