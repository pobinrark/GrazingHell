﻿using UnityEngine;
using System.Collections;
using System.IO;

public class MetricManagerScript : MonoBehaviour
{

    string createText = "";

    public static float sampleMetric1, sampleMetric2, boss2Life;
    public static int numberOfSwingsBoss1, numberOfHits, numberOfSwingsBoss2;
    void Start() { }
    void Update() { }

    //When the game quits we'll actually write the file.
    void OnApplicationQuit()
    {
        GenerateMetricsString();
        string time = System.DateTime.UtcNow.ToString(); string dateTime = System.DateTime.Now.ToString(); //Get the time to tack on to the file name
        print("before: " + time);
        time = time.Replace("/", "-"); // Replace slashes with dashes, because Unity thinks they are directories..
        time = time.Replace(":", "-"); // Replace colons with dashes
        time = time.Replace(" ", "__"); // Replace white space with two underscores
        string reportFile = "GameName_Metrics_" + time + ".txt";
        createText = createText.Replace("\n", System.Environment.NewLine); // Replace newline characters with the system's newline representation.
        File.WriteAllText(reportFile, createText);
        //In Editor, this will show up in the project folder root (with Library, Assets, etc.)
        //In Standalone, this will show up in the same directory as your executable
    }

    void GenerateMetricsString()
    {
        createText =
            "Bean alive for: " + sampleMetric1 + "seconds\n" +
            "Boss1 alive for: " + sampleMetric2 + "seconds\n" +
            "Boss2 alive for: " + boss2Life + "seconds\n" +
            "Number of Swings Boss1: " + numberOfSwingsBoss1 + "\n" +
            "Number of Swings Boss2: " + numberOfSwingsBoss2 + "\n";

    }

    //Add to your set metrics from other classes whenever you want
    public void AddToSample1(float amtToAdd)
    {
        sampleMetric1 += amtToAdd;
    }
    public void Boss1Life(float amtToAdd)
    {
        sampleMetric2 += amtToAdd;
    }
    public void Boss2Life(float amtToAdd)
    {
        boss2Life += amtToAdd;
    }
    public void NumberOfSwingsBoss1(int add)
    {
        numberOfSwingsBoss1 += add;
    }
    public void NumberOfSwingsBoss2()
    {
        numberOfSwingsBoss2 += 1;
    }
}