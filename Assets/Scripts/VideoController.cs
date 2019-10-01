using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class VideoController : MonoBehaviour
{
    public MediaPlayerCtrl easyMovieTexture;

    private void Awake()
    {
        easyMovieTexture.m_strFileName = "";
        easyMovieTexture.OnReady += PlayVideo;
    }

    public void OnClick()
    {
        PickVideo();
    }

    /// <summary>
    /// Select video from native gallery
    /// </summary>
    /// <param name="path">video path</param>
    void PickVideo()
    {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
        {
            if (path != null)
            {
                // Load picked video
                LoadVideo("file://" + path);
            }
        },"Select Video");
    }
    /// <summary>
    /// Load video
    /// </summary>
    /// <param name="path">video path</param>
    void LoadVideo(string path)
    {
        easyMovieTexture.Load(path);
    }

    /// <summary>
    /// Play video
    /// </summary>
    void PlayVideo()
    {
        Debug.Log("Current State : " + easyMovieTexture.GetCurrentState());
        easyMovieTexture.Play();
    }
}
