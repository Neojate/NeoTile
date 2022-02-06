
using Microsoft.Xna.Framework;
using NeoTile.Animations;
using System.Collections.Generic;

namespace NeoTile.StateMachines
{
    public class StateMachine
    {
        public Dictionary<string, FrameAnimation> States { get; set; } = new Dictionary<string, FrameAnimation>();

        public string State { get; set; }

        public void Update(GameTime gameTime)
        {
            if (States.Count > 0)
                States[State].Update(gameTime);
        }

        public void SetState(string state)
        {
            State = state;
            States[state].WrapVector2.Value.X = 0;
        }
    }
}
