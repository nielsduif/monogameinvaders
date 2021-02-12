using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class GreenInvader : Invader
    {
        public GreenInvader() : base("spr_green_invader")
        {
        }

        public override void Init()
        {
            base.Init();
            velocity.Y = 1;
        }

        public override void Update()
        {
            base.Update();
            position.Y += velocity.Y;
        }
    }
}
