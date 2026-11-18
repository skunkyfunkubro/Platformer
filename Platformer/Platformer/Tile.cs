using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Platformer;

public abstract class Tile
{
    public Vector2 pos;
    protected Texture2D tex;
    public Rectangle rec;

   // List<Tile> tileList;

    public Tile(Vector2 pos, Texture2D tex, Rectangle rec)
    {
        this.pos = pos;
        this.tex = tex;
        this.rec = rec;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(tex, pos, Color.White);
    }
}

//lägg en string som säger vilken tile det är t.ex grass för grass tilen