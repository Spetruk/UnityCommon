using UnityEngine;
using System;
using UnityEngine.Assertions;

namespace DefaultNamespace
{ 
    

[System.Serializable]
public static class Storage
{

    /*
    Example
    public static void SaveSomething(bool something) { Save<bool>(something, "key"); }
    public static bool LoadSomething() { return Load<bool>(false, "key"); }
    */
    
    ///private
    private static string Location(){ return Application.persistentDataPath + "/Saves";}

    private static void Save<T>(T obj, string fileName)
    {
        Type varType = obj.GetType();

        if (varType == typeof(uint))
        {
            PlayerPrefs.SetString(fileName, obj.ToString());
        }
        else if (varType == typeof(int))
        {
            PlayerPrefs.SetString(fileName, obj.ToString());
        }
        else if (varType == typeof(long))
        {
			PlayerPrefs.SetString(fileName, obj.ToString());
        }
        else if (varType == typeof(ulong))
        {
            PlayerPrefs.SetString(fileName, obj.ToString());
        }
        else if (varType == typeof(bool))
        {
            PlayerPrefs.SetInt(fileName, Convert.ToInt32(obj));
        }
        else if (varType == typeof(float))
        {
            PlayerPrefs.SetFloat(fileName, (float)Convert.ToDouble(obj));
        }
		else if (varType == typeof(double))
        {
			PlayerPrefs.SetString(fileName, obj.ToString());
        }
        else if (varType == typeof(string))
        {
            PlayerPrefs.SetString(fileName, Convert.ToString(obj));
        }
        else {
            Assert.IsTrue(false,"передал плохой тип: " + obj.ToString());
        }
        PlayerPrefs.Save();
    }

    private static T Load<T>(T empty, string fileName)
    {
        if (!PlayerPrefs.HasKey(fileName)) {
            Save(empty,fileName);
        };

        Type varType = empty.GetType();
        T result;
        if (varType == typeof(uint))
        {
            var s = PlayerPrefs.GetString(fileName);
            result = (T)Convert.ChangeType(s, varType);
        }
        else if(varType == typeof(int))
        {
            var s = PlayerPrefs.GetString(fileName);
            result = (T)Convert.ChangeType(s, varType);
        }
        else if (varType == typeof(bool))
        {
            result = (T)Convert.ChangeType(PlayerPrefs.GetInt(fileName), varType);
        }
        else if (varType == typeof(float))
        {
            result = (T)Convert.ChangeType(PlayerPrefs.GetFloat(fileName), varType);
        }
		else if (varType == typeof(long))
        {
			var s = PlayerPrefs.GetString(fileName);
			result = (T)Convert.ChangeType(s, varType);
        }
        else if (varType == typeof(ulong))
        {
            var s = PlayerPrefs.GetString(fileName);
            result = (T)Convert.ChangeType(s, varType);
        }
        else if (varType == typeof(string))
        {
            result = (T)Convert.ChangeType(PlayerPrefs.GetString(fileName), varType);
        }
        else
        {
            Assert.IsTrue(false, "передал плохой тип: " + empty.ToString());
            return (T)Convert.ChangeType(null, varType);
        }

        if (result==null) {
            return empty;
        }

        return result;
    }
}


}