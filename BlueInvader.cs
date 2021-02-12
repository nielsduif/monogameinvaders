using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class BlueInvader : Invader
    {
        public BlueInvader() : base("spr_blue_invader")
        {
        }

        public override void Start()
        {
            base.Start();
            velocity.Y = 0;
        }
    }
}
