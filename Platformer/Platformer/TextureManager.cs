using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer;

public static class Texturemanager
{
    public static Texture2D spriteSheetPlayerDesappearing;
    public static Texture2D spriteSheetDoubleJump;
    public static Texture2D spriteSheetFalling;
    public static Texture2D spriteSheetPlayerHit;
    public static Texture2D spriteSheetPlayerIdle;
    public static Texture2D spriteSheetJump;
    public static Texture2D spriteSheetRunning;
    public static Texture2D spriteSheetWallJump;
    public static Texture2D spriteSheetTiles;
    public static Texture2D texGrass;
    public static Texture2D texWall;
    public static Texture2D texGround;
    
    
    public static void LoadTextures(ContentManager content)
    {
        spriteSheetPlayerDesappearing = content.Load<Texture2D>("Desappearing (96x96)");
        spriteSheetDoubleJump = content.Load<Texture2D>("Double Jump (32x32)");
        //spriteSheetFalling = content.Load<Texture2D>("Fall 32x32");
        spriteSheetPlayerHit = content.Load<Texture2D>("Hit (32x32)");
        spriteSheetPlayerIdle = content.Load<Texture2D>("Idle (32x32)");
        spriteSheetJump = content.Load<Texture2D>("Jump (32x32)");
        texGrass = content.Load<Texture2D>("grass");
        texWall = content.Load<Texture2D>("wall");
        texGround = content.Load<Texture2D>("ground");
    }
}