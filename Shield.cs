using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    class Shield
    {
        public Vector2 position;
        public Texture2D texture;

        public Shield()
        {
            texture = Global.content.Load<Texture2D>("spr_shield");
            Start();
        }

        public void Start()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(Global.height - 300, Global.height - texture.Height);
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
