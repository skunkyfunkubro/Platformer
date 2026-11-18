using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public static int windowWidth = 40;
    public static int windowHeight = 30;
    public static int tileSize = 16;

    LevelEditor levelEditor;

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

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        levelEditor.PlaceTile(Mouse.GetState(), Keyboard.GetState());

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
