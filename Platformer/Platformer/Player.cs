using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer;

public class Player : GameObjects
{
    private bool isMoving;
    private bool attacking;
    private float speed;

    Animation idleAnimation;
    Animation walkingRight;
    Animation walkingLeft;
    Animation swingingRight;
    Animation swingingLeft;

    enum animationState
    {
        idle,
        walkingRight,
        walkingLeft,
        swingingRight,
        swingingLeft
    }

    public Player(Vector2 pos, Texture2D tex, Rectangle rec) : base(pos, tex, rec)
    {
        
    }



}