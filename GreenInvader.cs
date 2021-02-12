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

        public override void Start()
        {
            base.Start();
            velocity.Y = .5f;
        }

        public override void Update()
        {
            base.Update();
            position.Y += velocity.Y;
        }
    }
}
