using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Xna.Framework;


namespace Platformer;

public class LevelEditor
{
    Tile[,] grid = new Tile[Game1.windowWidth, Game1.windowHeight];
    Vector2 pos;
    Texture2D tex;
    Rectangle rec;

    public LevelEditor(Vector2 pos, Texture2D tex, Rectangle rec)
    {
        this.pos = pos;
        this.tex = tex;
        this.rec = rec;
    }

    public void ChooseTile() //lägg case switch för att kolla vilken tile jag väljer med ha en bool is placing tile
    {
        //rec och pos = mus positionen 
    }

    public void PlaceTile() // om placing är sann sätt funktion för att placera tilen i rätt index
    {
        
    }

    public void SaveFile(List<Tile> tileList) //måste placera in alla tiles i arrayen i json skappa en ny objekt i json som key. save i en edited level json fil
    {
      JArray tileArray = new JArray();
      JObject findObject = new JObject();

      for(int i = 0; i < tileList.Count; i++)
        {
            JObject obj //lägg in if sats där de kollar index och om index = med någonting lägg 
        }

        //lägg till arraysen i findobject

        //file.writealltext()
        //skappa arrayer som t.ex grassarray som man fyller jobjects i
    }

    public JObject CreateObject(Rectangle rec) // här lägger jag in tilesen
    {
       positionX = (int)pos.X;
       positionY = (int)pos.Y;
       Height = 16;
       Width = 16;
    }

    public void RemoveTile()
    {
        
    }
}
  
  
  
  
