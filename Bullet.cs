using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders
{
    class Bullet
    {
        public Boolean isFired = false;
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public float speed = 3f;

        public Bullet()
        {
            texture = Global.content.Load<Texture2D>("spr_bullet");
            Reset();
        }

        public void Reset()
        {
            isFired = false;
            position.X = -1000;
            velocity.Y = 0;
        }

        public void Update()
        {
            if (isFired)
            {

                if (position.Y < 0)
                    Reset();
            }
            position.Y += velocity.Y;
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }

        public void Fire(Vector2 startPosition)
        {
            if (!isFired)
            {
                isFired = true;
                this.position.X = startPosition.X;
                this.position.Y = startPosition.Y;
                velocity.Y = -speed;
            }
        }
    }
}
