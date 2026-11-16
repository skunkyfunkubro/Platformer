using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer;

public class GameObjects
{
    protected Vector2 pos;
    protected Texture2D tex;
    protected Rectangle rec;

    public GameObjects(Vector2 pos, Texture2D tex, Rectangle rec)
    {
        this.pos = pos;
        this.tex = tex;
    }  

}

   