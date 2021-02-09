using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    class SpaceShip
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public int hits;

        public SpaceShip()
        {
            texture = Global.content.Load<Texture2D>("spr_enemy_ship");
            Start();
        }

        public void Start()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = texture.Height;

            velocity.X = 3.0f;
            velocity.Y = 10.0f;
        }

        public void Update()
        {

            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
            }
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
