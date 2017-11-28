using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;
    public AudioClip openAudio;
    public AudioClip closeAudio;
    AudioSource audioSource;
    private object yield;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void ChangeDoorState()
    {
        open = !open;

    }

    void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }

    void onOpen()
    {
        if (open)
        {
            audioSource.PlayOneShot(openAudio);
        }
    }
    void onClose()
    {
        if (!open)
        {
            audioSource.PlayOneShot(closeAudio);
        }
    }

}
