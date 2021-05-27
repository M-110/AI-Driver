using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Vehicle.Stats;

public class StatsManager : MonoBehaviour
{
    public int carCount = 0;

    static StatsManager _instance;
    public static StatsManager Instance
    {
        get
        {
            if(_instance==null) Debug.Log("StatsManager missing");

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        


    }

    void Export()
    {
        string stringpath = "Assets/Resources/test.txt";
        StreamWriter writer = new StreamWriter(stringpath, true);
        writer.WriteLine("Name" + "," + 
                        "Checkpoints" + "," + 
                        "Sector1" + "," + 
                        "Sector2" + ","  + 
                        "Sector3" + "," + 
                        "Sector4");
        writer.WriteLine("'Player'" + "," + 
                        "75" + "," + 
                        "15" + "," + 
                        "12" + ","  + 
                        "15" + "," + 
                        "21");
        writer.Close();

    }

    public void AddStats(Stats stats)
    {
        string stringpath = "Assets/Resources/stats.csv";
        StreamWriter writer = new StreamWriter(stringpath, true);
        writer.WriteLine(stats.name + "," + 
                        stats.cp + "," +  
                        stats.d + "," +  
                        stats.t + "," + 
                        stats.s1 + "," + 
                        stats.s2 + ","  + 
                        stats.s3 + "," +  
                        stats.s4 + "," + 
                        stats.lap);
        writer.Close();
    }
}
