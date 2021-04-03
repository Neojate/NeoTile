
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NeoTile.Assets;
using NeoTile.Input;
using NeoTile.Worlds;
using System;

namespace NeoTile.Objects
{
    public class PlayerObject : GameObject
    {
        public Keys KeyMoveUp { get; set; } = Keys.W;
        public Keys KeyMoveDown { get; set; } = Keys.S;
        public Keys KeyMoveLeft { get; set; } = Keys.A;
        public Keys KeyMoveRight { get; set; } = Keys.D;

        protected Textures textures = Textures.Instance;

        private InputKeyboard keyboard = InputKeyboard.Instance;

        public void Move(Tile[,] map)
        {
            if (keyboard.KeyPressed(KeyMoveUp))
                CheckMove(map, new Vector2(0, -1));
            else if (keyboard.KeyPressed(KeyMoveDown))
                CheckMove(map, new Vector2(0, 1));
            else if (keyboard.KeyPressed(KeyMoveLeft))
                CheckMove(map, new Vector2(-1, 0));
            else if (keyboard.KeyPressed(KeyMoveRight))
                CheckMove(map, new Vector2(1, 0));
        }

        private void CheckMove(Tile[,] map, Vector2 direction)
        {
            Vector2 tempPos = Vector2.Add(Position, direction);

            if (map[(int)tempPos.X, (int)tempPos.Y].IsBlock)
                return;

            Position = tempPos;
        } 

    }
}
