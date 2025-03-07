using System.Collections.Generic;
using Mario.ECS;
using Mario.ECS.Components;
using Mario.ECS.Systems;
using Mario.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario;

public class Mario : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private float windowScale;
    private int windowWidth;
    private int windowHeight;

    private List<Entity> entities;
    private RenderSystem renderSystem;

    public Mario()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        windowScale = 4f;
        windowWidth = 256;
        windowHeight = 240;

        graphics.PreferredBackBufferWidth = (int)(windowWidth * windowScale);
        graphics.PreferredBackBufferHeight = (int)(windowHeight * windowScale);
        graphics.ApplyChanges();

        entities = new List<Entity>();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        renderSystem = new RenderSystem(spriteBatch, windowScale);

        var marioTexture = Content.Load<Texture2D>("Mario");
        var marioFactory = new MarioFactory(marioTexture);
        var player = marioFactory.CreateMario();
        entities.Add(player);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        renderSystem.Draw(entities);

        base.Draw(gameTime);
    }
}
