using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.ECS.Components
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }

        public Sprite(Texture2D texture, Rectangle sourceRectangle)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
        }
    }
}