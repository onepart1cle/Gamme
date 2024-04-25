using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Gamme;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Player player;
    private List<Platform> platforms;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        //GraphicsDeviceManager.PreferredBackBufferWidth = 800;
        //GraphicsDeviceManager.PreferredBackBufferHeight = 600;
    }

    protected override void Initialize()
    {
        // Создание анимированного спрайта для игрока
        //playerSprite = new AnimatedSprite(playerTexture);
        //playerInput = new PlayerInput();
        //Components.Add(playerInput);
        // Создание карты плиток
        //tileMap = new TileMap(Content.Load<Texture2D>("tiles"), 16, 16);
        //Components.Add(tileMap);
        // Создание коллайдера для игрока
        //Collider playerCollider = new Collider(playerSprite.Bounds);
        //Components.Add(playerCollider);
        player = new Player(new Vector2(100, 100));
        platforms = new List<Platform>
        {
            new Platform(new System.Numerics.Vector2(0, 400)),
            new Platform(new System.Numerics.Vector2(200, 300)),
            new Platform(new System.Numerics.Vector2(100, 100)),
        };

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        var playerTexture = Content.Load<Texture2D>("player");
        var platformTexture = Content.Load<Texture2D>("platform");

        player.Texture = playerTexture;
        foreach (var platform in platforms)
        {
            platform.Texture = platformTexture;
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        player.Update(gameTime);
        base.Initialize();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        player.Draw(spriteBatch);
        foreach (var platform in platforms)
        {
            platform.Draw(spriteBatch);
        }

        spriteBatch.End();
        base.Draw(gameTime);
    }
}