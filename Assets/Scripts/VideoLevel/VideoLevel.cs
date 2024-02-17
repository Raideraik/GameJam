using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLevel : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip _begining;
    [SerializeField] private VideoClip _goodEnding;
    [SerializeField] private VideoClip _badEnding;

    private int _choosedVideo;
    private void Start()
    {
        _choosedVideo = PlayerPrefs.GetInt("Video", 0);
        VideoSelect();
        _videoPlayer.loopPointReached += loopPointReached;
    }

    private void loopPointReached(VideoPlayer source)
    {
        if (_choosedVideo == 0)
        {
            SceneFader.Instance.FadeIn("GameScene");
        }
        else if (_choosedVideo > 0)
        {
            SceneFader.Instance.FadeIn("MainMenu");
        }
    }

    private void VideoSelect()
    {
        switch (_choosedVideo)
        {
            case 0:
                VideoPlay(_begining);
                break;
            case 1:
                VideoPlay(_goodEnding);
                break;
            case 2:
                VideoPlay(_badEnding);
                break;
        }
    }

    private void VideoPlay(VideoClip videoClip)
    {
        _videoPlayer.clip = videoClip;
        _videoPlayer.Play();
    }
}
