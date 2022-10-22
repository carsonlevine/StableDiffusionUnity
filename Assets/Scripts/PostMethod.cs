using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Http;
using System;
using System.Drawing;
using System.IO;

public class PostMethod : MonoBehaviour
{
    TMP_InputField outputArea;
    GameObject imageOutput;
    
    void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<TMP_InputField>();
        imageOutput = GameObject.Find("ImageOutput");
        GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData);
    }

    async void PostData()
    {
        outputArea.text = "Loading...";

        string url = "https://dezgo.p.rapidapi.com/text2image";
        
        var postData = new Dictionary<string, string>()
        {
            { "prompt", "an astronaut riding a horse, digital art, highly-detailed masterpiece trending HQ" },
            { "guidance", "7.5" },
            { "width", "512" },
            { "sampler", "k_lms" },
            { "height", "512" },
            { "steps", "50" },
	    };

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "94a3b40b48msh62e69810127b2c1p1dde8bjsn1f9d686befeb");
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "dezgo.p.rapidapi.com");
            var response = await httpClient.PostAsync(url, new FormUrlEncodedContent(postData));
        
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                Debug.Log(content);
                Texture2D tex = new Texture2D(512, 512);
                tex.LoadImage(content);
                imageOutput.GetComponent<RawImage>().texture = tex;
            }
            else
            {
                outputArea.text = "Error: " + response.StatusCode;
            }
        }
    }
}
