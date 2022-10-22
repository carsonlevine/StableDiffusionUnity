using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Http;

public class GetMethod : MonoBehaviour
{
    TMP_InputField outputArea;
    
    void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<TMP_InputField>();
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }

    async void GetData()
    {
        outputArea.text = "Loading...";
        string url = "https://my-json-server.typicode.com/typicode/demo/posts";
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                outputArea.text = content;
            }
            else
            {
                outputArea.text = "Error: " + response.StatusCode;
            }
        }
    }
}
