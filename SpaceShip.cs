using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    class SpaceShip : GameObject
    {
        public int hits;

        public SpaceShip() : base("spr_enemy_ship")
        {
        }

        public override void Start()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = texture.Height;

            velocity.X = 3.0f;
            velocity.Y = 10.0f;
        }

        public override void Update()
        {
            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
            }
        }
    }
}
