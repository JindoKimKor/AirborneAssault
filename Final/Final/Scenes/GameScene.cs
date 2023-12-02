﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Scenes
{
    public abstract class GameScene : DrawableGameComponent
    {
        public List<GameComponent> ComponentList { get; set; }

        public virtual void Hide()
        {
            Enabled = false;
            Visible = false;
        }
        public virtual void Show()
        {
            Enabled = true;
            Visible = true;
        }
        protected GameScene(Game game) : base(game)
        {
            ComponentList = new List<GameComponent>();
            Hide();
        }
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent gameComponent in ComponentList)
            {
                if (gameComponent.Enabled)
                {
                    gameComponent.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent gameComponent in ComponentList)
            {
                if (gameComponent is DrawableGameComponent)
                {
                    DrawableGameComponent drawableGameComponent = (DrawableGameComponent)gameComponent;
                    if (drawableGameComponent.Visible)
                    {
                        drawableGameComponent.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }
    }
}