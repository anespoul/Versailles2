using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip door;
    public AudioClip alert;
    public GameObject validationPanel;

    private IEnumerator m_currentCoroutine;
    private bool cr_running;
    private AudioClip m_currentAudioClip;

    void Start() 
    {
        cr_running = false;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        Stop();
        audioSource.PlayOneShot(clip);
    }


    public void NeedValidation(AudioClip clip)
    {
        validationPanel.SetActive(!validationPanel.activeSelf);
        m_currentAudioClip = clip;
    }

    public void playCurrentClip()
    {
        Stop();
        audioSource.PlayOneShot(m_currentAudioClip);
        validationPanel.SetActive(!validationPanel.activeSelf);
    }

    public void PlayXTimes()
    {
        Stop();
        m_currentCoroutine = PlayAudio(15, alert);
        StartCoroutine(m_currentCoroutine);
    }

    public void Play3Times()
    {
        Stop();
        m_currentCoroutine = PlayAudio(3, door);
        StartCoroutine(m_currentCoroutine);
    }
    
    IEnumerator PlayAudio(int times, AudioClip clip)
    {
        cr_running = true;
        for(int i=0; i<times; i++)
        {
            audioSource.PlayOneShot(clip, 1);
            yield return new WaitForSeconds(clip.length);
        }
    }

    public void Stop() {
        if (cr_running)
        {
            StopCoroutine(m_currentCoroutine);
            cr_running = false;
        }
        audioSource.Stop();
    }
}
