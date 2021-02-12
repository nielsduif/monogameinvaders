using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class YellowInvader : Invader
    {
        int frameCounter;
        public YellowInvader() : base("spr_yellow_invader")
        {
        }

        public override void Update()
        {
            base.Update();
            position.Y += velocity.Y;
            frameCounter++;
            if (frameCounter >= 10) {
                frameCounter = 0;
                velocity.Y = -velocity.Y;
            }
        }
    }
}
