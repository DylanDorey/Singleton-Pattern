using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/01/2024]
 * [GameManager for Singleton Example]
 */

/// <summary>
/// Game Manager that is a Singletone class
/// </summary>
public class GameManager : Singleton<GameManager>
{
    //start and end time of the program at runtime
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    void Start()
    {
        //set the start time and output it in the console
        _sessionStartTime = DateTime.Now;
        Debug.Log("Game session start @ " + DateTime.Now);
    }

    private void OnApplicationQuit()
    {
        //set the end time of the program
        _sessionEndTime = DateTime.Now;

        //subtract the start time from the end time and store it in a timeDifference
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

        //output the end time of the program and how long it was running
        Debug.Log("Game session ended @ " + DateTime.Now);
        Debug.Log("Game session lasted: " + timeDifference);
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    //private void OnGUI()
    //{
    //    if (GUILayout.Button("Next Scene"))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //}
}
