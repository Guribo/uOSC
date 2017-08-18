﻿using UnityEngine;

namespace uOSC
{

[RequireComponent(typeof(uOscServer)),
 RequireComponent(typeof(Renderer))]
public class OscServerBlobTest : MonoBehaviour
{
    Texture2D texture_;

    void Start()
    {
        var server = GetComponent<uOscServer>();
        server.onDataReceived.AddListener(OnDataReceived);

        texture_ = new Texture2D(256, 256, TextureFormat.ARGB32, true);

        var renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = texture_;
    }

    void OnDataReceived(Message message)
    {
        if (message.address == "/uOSC/blob")
        {
            var byteTexture = message.values[0].AsBlob();
            ImageConversion.LoadImage(texture_, byteTexture, true);
        }
    }
}

}