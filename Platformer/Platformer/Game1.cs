using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace Platformer;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private KeyboardState previousKeyboardState;

    public static int windowWidth = 40;
    public static int windowHeight = 30;
    public static int tileSize = 16;

    LevelEditor levelEditor;

    private static readonly string Levels = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    "Level1",
    "Level2",
    "EditedLevel"
    );

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferHeight = tileSize * windowHeight;
        _graphics.PreferredBackBufferWidth = tileSize * windowWidth;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texturemanager.LoadTextures(Content);

        levelEditor = new LevelEditor(Vector2.Zero, Texturemanager.texGrass, new Rectangle(0, 0, Game1.tileSize, Game1.tileSize));
        
        if (File.Exists("EditedLevel.json"))
        {
            levelEditor.LoadFile("EditedLevel.json");
        }

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // levelEditor.PlaceTile(Mouse.GetState(), Keyboard.GetState());

        KeyboardState keyboard = Keyboard.GetState();

        levelEditor.PlaceTile(Mouse.GetState(), keyboard);

        bool controlDown = keyboard.IsKeyDown(Keys.LeftControl) || keyboard.IsKeyDown(Keys.RightControl);

        if (controlDown && keyboard.IsKeyDown(Keys.S) && !previousKeyboardState.IsKeyDown(Keys.S))
        {
            levelEditor.SaveFile("EditedLevel.json");
        }

        if (controlDown && keyboard.IsKeyDown(Keys.O) && !previousKeyboardState.IsKeyDown(Keys.O))
        {
            if (File.Exists("EditedLevel"))
            {
              levelEditor.LoadFile("EditedLevel.json");  
            } 
        }

        previousKeyboardState = keyboard;

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
         _spriteBatch.Begin();

        // TODO: Add your drawing code here
        levelEditor.Draw(_spriteBatch);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
