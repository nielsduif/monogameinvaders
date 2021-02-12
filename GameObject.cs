using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoGameInvaders
{
    class GameObject
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;

        public GameObject(string assetName)
        {
            texture = Global.content.Load<Texture2D>(assetName);
            Start();
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
