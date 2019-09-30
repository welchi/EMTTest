using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class LoadVideo : MonoBehaviour
{
    public MediaPlayerCtrl easyMovieTexture;

    private void Awake()
    {
        easyMovieTexture.m_strFileName = "";
    }

    public void OnClick()
    {
        PickVideo();
    }

    void PickVideo()
    {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
        {
            if (path != null)
            {
                // Play picked video
                PlayVideo("file://" + path);
            }
        },"Select Video");
    }
    /// <summary>
    /// Play video
    /// </summary>
    /// <param name="path">video path</param>
    void PlayVideo(string path)
    {
        easyMovieTexture.Load(path);
        easyMovieTexture.Play();
    }
}
