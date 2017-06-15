using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{



    public AudioSource musicSource;
    public static MusicControl instanceSM = null;


    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!(GetComponent<AudioSource>().isPlaying))
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            //Debug.log("Something is wrong with Music.");
        }
    }


}