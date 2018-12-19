using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum PowerUp
{
    DoubleBarrier,
    ImmuneBarrier
}

public class SaveData {

    #region Defaults
    public const string DEFAULT_LVL = "lvl1";
    private const int DEFAULT_LIVES = 3;
    private const int DEFAULT_COINS = 100;
    private const int DEFAULT_HEALTH = 100;
    private const int DEFAULT_POINTS = 0;
    private const List<int[]> DEFAULT_SCORES = null;
    #endregion

    public int coins = DEFAULT_COINS;
    public int health = DEFAULT_LIVES;
    public int lives = DEFAULT_LIVES;
    public List<PowerUp> powerUps = new List<PowerUp>();
    public List<string[]> highScores = new List<string[]>();
    public string lastlevel = DEFAULT_LVL;
    public int points = 0;
    const bool DEBUG_ON = true;


    private static string filepath = "Assets/saved";


    public void WriteToFile()
    {
        Debug.Log("wrote to file");
        highScores.Add(new string[2]{ "player 1", points.ToString() });
        string json = JsonUtility.ToJson(this);

        File.WriteAllText(filepath, json);
        if(DEBUG_ON)
        {
            Debug.LogFormat("WriteToFile({0} -- data:\n{1}", filepath, json);
        }
    }

    public SaveData ReadFromFile()
    {
        Debug.Log("read from file");
        if(!File.Exists(filepath))
        {
            Debug.LogErrorFormat("ReadFromFile({0}) -- file not found, returning new object", filepath);
            return new SaveData();
        } else
        {
            string contents = File.ReadAllText(filepath); 
            if(DEBUG_ON)
            {
                Debug.LogFormat("ReadFromFile({0})\ncontents:\n{1}", filepath, contents);
            }
            if(string.IsNullOrEmpty(contents))
            {
                Debug.LogErrorFormat("File: '{0}' is empty. Returning default SaveData");
                return new SaveData();
            }

            return JsonUtility.FromJson<SaveData>(contents);
        }
    }

    public bool IsDefault()
    {
        return (
            coins == DEFAULT_COINS &&
            health == DEFAULT_HEALTH &&
            lives == DEFAULT_LIVES &&
            lastlevel == DEFAULT_LVL &&
            points == DEFAULT_POINTS &&
            highScores.Count == 0 &&
            powerUps.Count == 0);
    }

    public override string ToString()
    {
        string[] powerUpsStrings = new string[powerUps.Count];
        for(int i = 0; i < powerUps.Count; i++)
        {
            powerUpsStrings[i] = powerUps[i].ToString();
        }
        string[] highScoreStrings = new string[highScores.Count];
        for(int i = 0; i < highScores.Count; i++)
        {

            highScoreStrings[i] = highScores[i][0]+ " " + highScores[i][1];
        }
        return string.Format(
            "coins: {0}\nhealth: {1}nlives: {2}\npowerUps: {3}highScores: {4}\nlastLevel: {5}",
            coins,
            health,
            lives,
            "[" + string.Join(",", powerUpsStrings) + "]",
            "[" + string.Join(",", highScoreStrings) + "]",
            lastlevel);
    }
}
