using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class StreamVideo : MonoBehaviour
{
    public RawImage image;

    private VideoPlayer videoPlayer;

    private VideoSource videoSource;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = "http://stream1.visualon.com:8082/customers/migu/Lee/normal.mp4";

        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0,true);
        videoPlayer.SetTargetAudioSource(0,audioSource);
        
        videoPlayer.Prepare();
        
        WaitForSeconds waitTimes = new WaitForSeconds(1);
        
        while(!videoPlayer.isPrepared)
        {
            Debug.Log("preparing video!");
            yield return waitTimes;
            break;
        }

        Debug.Log("done preparing video");

        image.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
        Debug.Log("playing video");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
