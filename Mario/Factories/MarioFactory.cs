using Mario.ECS;
using Mario.ECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Factories
{
    public class MarioFactory
    {
        private readonly Texture2D marioTexture;

        public MarioFactory(Texture2D marioTexture)
        {
            this.marioTexture = marioTexture;
        }

        public Entity CreateMario()
        {
            Entity mario = new Entity();
            mario.AddComponent(new Sprite(marioTexture, new Rectangle(181, 0, 13, 16)));
            mario.AddComponent(new Position { X = 100, Y = 100 });

            return mario;
        }
    }
}