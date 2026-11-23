using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer;

public class GameObjects
{
    public Vector2 pos;
    protected Texture2D tex;
    protected Rectangle rec;

    public GameObjects(Vector2 pos, Texture2D tex, Rectangle rec)
    {
        this.pos = pos;
        this.tex = tex;
        this.rec = rec;
    }  

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(tex, pos, Color.White);
    }

}

   