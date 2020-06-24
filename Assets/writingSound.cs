using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class writingSound : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] clips ;
    private AudioSource audioSource = null;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {

            }
            else
            {
                AudioClip clip = GetRandomClip();
                audioSource.pitch = (Random.Range(0.8f, 1.2f));
                audioSource.PlayOneShot(clip);
            }


        }

    }
    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
