using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameInvaders
{
    class Bullet : GameObject
    {
        public Boolean isFired = false;
        public float speed = 30f;

        public Bullet() : base("spr_bullet")
        {
        }

        public override void Start()
        {
            isFired = false;
            position.X = -1000;
            velocity.Y = 0;
        }

        public override void Update()
        {
            if (isFired)
            {
                if (position.Y < 0)
                    Start();
            }
            position.Y += velocity.Y;
        }

        public void Fire(Vector2 startPosition)
        {
            if (!isFired)
            {
                isFired = true;
                position.X = startPosition.X;
                position.Y = startPosition.Y;
                velocity.Y = -speed;
            }
        }
        public Boolean overlaps(float x0, float y0, Texture2D texture0, float x1, float y1, Texture2D texture1)
        {
            int w0 = texture0.Width,
              h0 = texture0.Height,
              w1 = texture1.Width,
              h1 = texture1.Height;

            if (x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1)
                return false;
            else
                return true;
        }
    }
}
