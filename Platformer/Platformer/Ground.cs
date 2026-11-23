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

public class Ground : Tile
{
    public Ground(Vector2 pos, Texture2D tex, Rectangle rec) : base(pos, tex, rec)
    {

    }
}