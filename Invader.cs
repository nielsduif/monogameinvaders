using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MonoGameInvaders
{
    class Invader : GameObject
    {
        public Invader(string assetName) : base(assetName)
        {

        }

        public override void Start()
        {
            base.Start();
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(0, Global.height - 300);
        }

        public override void Update()
        {
            base.Update();
            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }
        }
    }
}
