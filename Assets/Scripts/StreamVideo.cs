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
    
    public Text text_PlayOrPause;
    public Button button_PlayOrPause;
    public Button button_stop;
    public Button button_Next;
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
        
        button_PlayOrPause.onClick.AddListener(OnPlayOrPauseVideo);
        button_stop.onClick.AddListener(OnStopvideo);
        button_Next.onClick.AddListener(OnNextVideo);
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
            Debug.Log("preparing video");
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
    
    /// <summary>
    /// 播放和暂停当前视频
    /// </summary>
    private void OnPlayOrPauseVideo()
    {
        //判断视频播放情况，播放则暂停，暂停就播放，并更新相关文本
        if (videoPlayer.isPlaying == true)
        {
            videoPlayer.Pause();
            audioSource.Pause();
            text_PlayOrPause.text = "播放";
        }
        else
        {
            videoPlayer.Play();
            audioSource.Play();
            text_PlayOrPause.text = "暂停";
        }
    }
    
    /// <summary>
    /// 切换下一个视频
    /// </summary>
    private void OnNextVideo()
    {
        videoPlayer.url = "http://stream1.visualon.com:8082/customers/migu/Lee/VRCardboard.mp4";
        videoPlayer.Prepare();
        WaitForSeconds waitTimes = new WaitForSeconds(1);
        
        while(!videoPlayer.isPrepared)
        {
            Debug.Log("preparing video");
            // yield return;
            break;
        }

        image.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
        Debug.Log("playing video!");
    }
    
    private void OnStopvideo()
    {
        videoPlayer.Stop();
        audioSource.Stop();
        text_PlayOrPause.text = "stop";
    }
}
