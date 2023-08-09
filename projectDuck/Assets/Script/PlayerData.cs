using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    static public void SaveData(string type, string name, object obj)
    {
        switch (type)
        {
            case "int":
                PlayerPrefs.SetInt(name, int.Parse(obj.ToString()));
                break;
            case "float":
                PlayerPrefs.SetFloat(name, float.Parse(obj.ToString()));
                break;
            case "string":
                PlayerPrefs.SetString(name, obj.ToString());
                break;
            case "bool":
                PlayerPrefs.SetString(name, obj.ToString());
                break;
        }
        PlayerPrefs.Save();
    }

    static public T GetData<T>(string type, string name)
    {
        object output = default(T);

        switch (type)
        {
            case "int":
                output = PlayerPrefs.GetInt(name, 0);
                break;
            case "float":
                output = PlayerPrefs.GetFloat(name, 0.00f);
                break;
            case "string":
                output = PlayerPrefs.GetString(name, "default");
                break;
            case "bool":
                string boolString = PlayerPrefs.GetString(name, "False");
                output = boolString == "True" ? true : false;
                break;
        }

        return (T)output;
    }
}
