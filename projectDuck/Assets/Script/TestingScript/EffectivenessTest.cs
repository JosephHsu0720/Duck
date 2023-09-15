using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class EffectivenessTest : MonoBehaviour
{
    public class KeyWord
    {
        public static string EVENT_TYPE_NORMAL = "[normal]";
        public static string LANGUAGE = "[lang]";
    }

    enum EVENT_TYPE
    {
        NORMAL,
        ADULT
    }

    // StopWatch
    public Stopwatch stopWatch;

    // Test Data
    public ulong testInt;
    public Rigidbody targetRigibody;

    // Long Press Button
    public Text longPressText;
    int s = 0;

    // Start is called before the first frame update
    void Start()
    {
        stopWatch = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            stopWatch.Start();
            TestFunction();
        }
    }

    void TestFunction()
    {
        //Rigidbody rigidbody1 = GameObject.Find("Target").GetComponent<Rigidbody>();
        //Rigidbody rigidbody2 = FindObjectOfType<Rigidbody>().GetComponent<Rigidbody>();
        Rigidbody rigidbody3 = targetRigibody;

        EndTesting(rigidbody3);
    }

    void EndTesting(Rigidbody rigidbody)
    {
        TimeSpan elapsedTime = stopWatch.Elapsed;
        stopWatch.Stop();
        UnityEngine.Debug.Log($"{rigidbody.name} -> {elapsedTime.TotalSeconds}s.");
        stopWatch.Reset();
    }

    public void Plus()
    {
        s += 1;
        SetText(s);
    }

    public void Minus()
    {
        s -= 1;
        SetText(s);
    }

    void SetText(int s)
    {
        longPressText.text = s.ToString();
    }

    public void SetOutput(string testInput)
    {
        if (string.IsNullOrEmpty(testInput)) UnityEngine.Debug.LogWarning("Empty Input");

        if (testInput.Contains(KeyWord.LANGUAGE))
        {
            testInput = testInput.Replace(KeyWord.LANGUAGE, "ja");
        }
        if (testInput.Contains(KeyWord.EVENT_TYPE_NORMAL))
        {
            testInput = testInput.Replace(KeyWord.EVENT_TYPE_NORMAL, $"_{EVENT_TYPE.NORMAL.ToString().ToLower()}");
        }
        UnityEngine.Debug.Log(testInput);
    }
}
