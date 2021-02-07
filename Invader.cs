using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MonoGameInvaders
{
    class Invader
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public string betere_ide;

        public Invader()
        {
            texture = Global.content.Load<Texture2D>("spr_red_invader");
            Reset();
        }

        public void Reset()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(0, Global.height - 300);

            velocity.X = 3.0f;
            velocity.Y= 10.0f;
        }

        public void Update()
        {
            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X= -velocity.X;
                position.Y += velocity.Y;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
