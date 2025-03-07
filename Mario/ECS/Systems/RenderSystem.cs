using Mario.ECS.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Mario.ECS.Systems
{
    public class RenderSystem
    {
        private readonly SpriteBatch spriteBatch;
        private readonly float windowScale;

        public RenderSystem(SpriteBatch spriteBatch, float windowScale)
        {
            this.spriteBatch = spriteBatch;
            this.windowScale = windowScale;
        }

        public void Draw(List<Entity> entities)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (var entity in entities)
            {
                if (entity.HasComponent<Sprite>() && entity.HasComponent<Position>())
                {
                    var sprite = entity.GetComponent<Sprite>();
                    var position = entity.GetComponent<Position>();

                    var scaledPosition = new Vector2(position.X * windowScale, position.Y * windowScale);

                    spriteBatch.Draw(sprite.Texture, scaledPosition, sprite.SourceRectangle, Color.White, 0f, Vector2.Zero, windowScale, SpriteEffects.None, 0f);
                }
            }

            spriteBatch.End();
        }
    }
}