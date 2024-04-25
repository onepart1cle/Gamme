using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gamme;

public class Player
{
    public Vector2 Position { get; set; }
    public bool IsJumping { get; set; }
    public bool IsOnGround { get; set; }
    public Texture2D Texture { get; set; }
    float Speed = 10f;

    public Player(Vector2 position)
    {
        Position = position;
        IsJumping = false;
        IsOnGround = false;
    }

    public void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.W))
        {
            Position = new Vector2(Position.X, Position.Y - Speed);
        }

        if (keyboardState.IsKeyDown(Keys.S))
        {
            Position = new Vector2(Position.X, Position.Y + Speed);
        }

        if (keyboardState.IsKeyDown(Keys.A))
        {
            Position = new Vector2(Position.X - Speed, Position.Y);
        }

        if (keyboardState.IsKeyDown(Keys.D))
        {
            Position = new Vector2(Position.X + Speed, Position.Y);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
    }
}