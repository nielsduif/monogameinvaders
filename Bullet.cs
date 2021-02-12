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
                this.position.X = startPosition.X;
                this.position.Y = startPosition.Y;
                velocity.Y = -speed;
            }
        }
    }
}
