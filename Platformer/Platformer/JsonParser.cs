using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using SharpDX.MediaFoundation;

namespace Platformer;

public class JsonParser
{
    private static JObject wholeObject;
    private static string currentFileName;
    
    
    private static void GetObjectFromFile(string fileName)
    {
        if(wholeObject == null || currentFileName == null || currentFileName != fileName)
        {
            currentFileName = fileName;
            StreamReader file = File.OpenText(fileName);
            JsonTextReader reader = new JsonTextReader(file);
            wholeObject = JObject.Load(reader);
            file.Close();
        }
    }

    public static List<Rectangle> GetRectangleList(string fileName, string propertyName)
    {
        if(wholeObject == null || currentFileName == null || currentFileName != fileName)
        {
            GetObjectFromFile(fileName);
        }

        List<Rectangle> recList = new List<Rectangle>();
        JArray arrayObject = (JArray)wholeObject.GetValue(propertyName);

        for(int i = 0; i < arrayObject.Count; i++)
        {
            JObject obj = (JObject)arrayObject[i];
            recList.Add(GiveValue(obj));
        }

        return recList;
    }

    

    public static Rectangle GetRectangle(string fileName, string propertyName)
    {
        if(wholeObject == null || currentFileName == null || currentFileName != fileName)
        {
            GetObjectFromFile(fileName);
        }

        JObject obj = (JObject)wholeObject.GetValue(propertyName);
        return GiveValue(obj);
    }


    private static Rectangle GiveValue(JObject obj)
    {
        int x = Convert.ToInt32(obj.GetValue("positionX"));
        int y = Convert.ToInt32(obj.GetValue("positionY"));
        int height = Convert.ToInt32(obj.GetValue("height"));
        int width = Convert.ToInt32(obj.GetValue("width"));
        return new Rectangle(x, y, width, height);
    }
}