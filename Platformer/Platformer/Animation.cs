using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer;

public class Animation
{
    public Texture2D _texture;
    Rectangle[] _sourceRectangles;
    float _animationTime = 1.0f;
    bool _isPlaying = true;
    float rotation;

    public Animation(Texture2D texture, Rectangle[] sourceRectangles)
    {
        _texture = texture;
        _sourceRectangles = sourceRectangles;
    }

    public void Update(GameTime gameTime)
    {
        if (_isPlaying)
        {
            _animationTime += (float)gameTime.ElapsedGameTime.TotalSeconds *10f;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, Vector2 origin, SpriteEffects spriteEffects)
    {
        int rectangleIndex =
            (int)_animationTime % _sourceRectangles.Length;

        spriteBatch.Draw(
            _texture,
            position,
            _sourceRectangles[rectangleIndex],
            Color.White,
            rotation,
            origin,
            Vector2.One,
            spriteEffects,
            0.0f
        );
    }

    public void Play()
    {
        _isPlaying = true;
    }

    public void Reset()
    {
       _animationTime = 0;
       _isPlaying = false;
    }
}
