// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using UnityEngine.Networking;
// using System;
// using System.IO;
// using System.Web;
// using System.Net.Http;
// using System.Net;
// using System.Text;

// public class StableUI : EditorWindow
// {
//     static string url = "http://127.0.0.1:9090";
//     static string sdRootFolder = "";

//     static UnityWebRequest www;

//     [MenuItem("Tools/StableUI")]
//     public static void ShowWindow()
//     {
//         var window = GetWindow(typeof(StableUI));
//         window.titleContent = new GUIContent("StableUI");
//     }

//     static string prompt = "empty";
//     static string guidance = "7.5";
//     static int steps = 20;
//     static string sampler = "k_lms";
//     static int width = 512;
//     static int height = 512;


   

//     void OnGUI()
//     {
//        // text area
//        prompt = EditorGUILayout.TextArea(prompt,GUILayout.Height(64));

//        // button
//        if (GUILayout.Button("Generate",GUILayout.Height(44)))
//        {
//             Generate();
//        }
//        // int field
//     //    iterations = EditorGUILayout.IntField("Iterations", iterations);

//        //steps

//     }

//     void Generate()
//     {
        
        
              
//     }

    
// }
