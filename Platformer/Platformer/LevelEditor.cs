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
    //Tile[,] grid = new Tile[Game1.windowWidth, Game1.windowHeight];
    Vector2 pos;
    Texture2D tex;
    Rectangle rec;
    List<Tile> tileList = new();

    private string tileType;
    private MouseState previousMouseState;
    private MouseState currentMouseState;
    private KeyboardState previousKeyboardState;

    public LevelEditor(Vector2 pos, Texture2D tex, Rectangle rec)
    {
        this.pos = pos;
        this.tex = tex;
        this.rec = rec;
    }

    public Vector2 MousePosition(MouseState mouse)
    {
        int x = mouse.X / Game1.tileSize * Game1.tileSize;
        int y = mouse.Y / Game1.tileSize * Game1.tileSize;

        return new Vector2(x, y);
    }
    
    public void SelectTile(KeyboardState keyboard)
    {
        if (keyboard.IsKeyDown(Keys.D1) && !previousKeyboardState.IsKeyDown(Keys.D1))
        {
            tileType = "Grass";
        }

        if (keyboard.IsKeyDown(Keys.D2) && !previousKeyboardState.IsKeyDown(Keys.D2))
        {
            tileType = "Wall";
        }

        if (keyboard.IsKeyDown(Keys.D3) && !previousKeyboardState.IsKeyDown(Keys.D3))
        {
            tileType = "Ground";
        }
    }
    
    public Tile ChooseTilePos(Vector2 position) 
    {
        foreach (Tile tile in tileList)
        {
            if(tile.pos == position)
            {
                return tile;
            }
        }

        return null;
    }

    public void PlaceTile(MouseState mouse, KeyboardState keyboard) 
    {
        //gör case switch sen
        SelectTile(keyboard);
        
        if(mouse.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
        {
            Vector2 position = MousePosition(mouse);

            if(tileType == "Grass")
            {
                tileList.Add(new Grass(
                    position,
                    Texturemanager.texGrass,
                    new Rectangle(0, 0, Game1.tileSize, Game1.tileSize)
                ));
            }

            if(tileType == "Wall")
            {
                tileList.Add(new Wall(
                    position,
                    Texturemanager.texWall,
                    new Rectangle(0, 0, Game1.tileSize, Game1.tileSize)
                ));
            }

            if(tileType == "Ground")
            {
                tileList.Add(new Ground(
                    position,
                    Texturemanager.texGround,
                    new Rectangle(0, 0, Game1.tileSize, Game1.tileSize)
                ));
            }
        }

        if (mouse.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
        {
            RemoveTile(MousePosition(mouse));
        }

        previousKeyboardState = keyboard;
        previousMouseState = mouse;
    }

    // public void SaveFile(List<Tile> tileList) //måste placera in alla tiles i arrayen i json skappa en ny objekt i json som key. save i en edited level json fil
    // {
    //   JArray tileArray = new JArray();
    //   JObject findObject = new JObject();
    //   JArray grassArray = new JArray();

    //   for(int i = 0; i < tileList.Count; i++)
    //     {
    //         JObject obj; //lägg in if sats där de kollar index och om index = med någonting lägg. lägg in case switch som kollar vilken typ de är sen sett in i array
    //         switch tile

    //             case(tileList[i] is grasstile):
    //             grassArray.Add({"positionX": tileList[i].pos.X, "positionY": tileList[i].pos.Y, "height": Game1.tileSize, "width": Game1.tileSize})
                
    //             //case()


            
    //     }
    //     findObject.Add("grassTile", grassArray) // gör såhär för alla tiles


    //     //lägg till arraysen i findobject
    //     //när jag läggger in behöver jag pos som kommer ifrån mus funktionen

    //     //file.writealltext()
    //     //skappa arrayer som t.ex grassarray som man fyller jobjects i

    //     findObject.Add("GrassTiles", grassArray);
    
    //}

    public void SaveFile(string fileName)
    {
        JArray grassArray = new JArray();
        JArray wallArray = new JArray();
        JArray groundArray = new JArray();

        foreach (Tile tile in tileList)
        {
            if(tile is Grass)
            {
                JObject grassObject = new JObject
                {
                    ["positionX"] = (int)tile.pos.X,
                    ["positionY"] = (int)tile.pos.Y,
                    ["height"] = Game1.tileSize,
                    ["width"] = Game1.tileSize
                };

                grassArray.Add(grassObject);
            }

            if(tile is Wall)
            {
                JObject wallObject = new JObject
                {
                    ["positionX"] = (int)tile.pos.X,
                    ["positionY"] = (int)tile.pos.Y,
                    ["height"] = Game1.tileSize,
                    ["width"] = Game1.tileSize
                };

                wallArray.Add(wallObject);
            }

            if(tile is Ground)
            {
                JObject groundObject = new JObject
                {
                    ["positionX"] = (int)tile.pos.X,
                    ["positionY"] = (int)tile.pos.Y,
                    ["height"] = Game1.tileSize,
                    ["width"] = Game1.tileSize
                };

                groundArray.Add(groundObject);
            }

        }

        JObject levelObject = new JObject
        {
            ["GrassTiles"] = grassArray
            ["WallTiles"] = wallArray
            ["GroundTiles"] = groundArray
        };

        

        File.WriteAllText(fileName, levelObject.ToString());
    }

    public void RemoveTile(Vector2 position)
    {
        //remove den index ifrån arrayen
        for(int i = tileList.Count - 1; i >= 0; i--)
        {
            if(tileList[i].pos == position)
            {
                tileList.RemoveAt(i);
                return;
            }
        }
    }

    public void LoadFile(string fileName)
    {
        tileList.Clear();

        List<Rectangle> rectangles = JsonParser.GetRectangleList(fileName, "GrassTiles"); //lägg in de andra tilesen

        foreach (Rectangle rectangle in rectangles)
        {
            tileList.Add(new Grass(
            new Vector2(rectangle.X, rectangle.Y), Texturemanager.texGrass, rectangle));

            tileList.Add(new Wall(
            new Vector2(rectangle.X, rectangle.Y), Texturemanager.texWall, rectangle));

            tileList.Add(new Ground(
            new Vector2(rectangle.X, rectangle.Y), Texturemanager.texGround, rectangle));
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach(Tile tile in tileList)
        {
            tile.Draw(spriteBatch);
        }
    }
}
  
  
  
  
