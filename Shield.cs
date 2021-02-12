using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameInvaders
{
    class Shield : GameObject
    {
        public Shield() : base("spr_shield")
        {
        }

        public override void Start()
        {
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(Global.height - 300, Global.height - texture.Height);
        }
    }
}
