using FlappyBirdClone.States;
using FlappyBirdClone.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlappyBirdClone.Globals;

namespace FlappyBirdClone.Managers
{
    // why not just make this static too? 

    // NOTE:
    // This StateManager uses previousState to support pause/resume.
    // This is fine for Flappy Bird where only PauseState is needed.
    //
    // In larger games with deeper menu systems (settings, confirmation dialogs,
    // nested menus, etc.), a Stack<IGameState> is what im thinking we use so states
    // can be pushed and popped in layers.
    public class StateManager
    {
        public IGameState currState { get; private set; }
        private IGameState previousState;
        public void ChangeState(IGameState newState)
        {
            previousState = null;
            currState = newState;
        }

        public void PushState(IGameState newState)
        {
            previousState = currState;
            currState = newState;
        }

        public void PopState()
        {
            currState = previousState;
            previousState = null;
        }

        public void Update(GameTime gameTime)
        {
            currState?.Update(gameTime); // TODO: do we need the '?'
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            previousState?.Draw(spriteBatch);
            currState?.Draw(spriteBatch);
        }
    }
}


