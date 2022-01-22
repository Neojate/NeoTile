using Microsoft.Xna.Framework;

namespace NeoTile.Animations
{
    public class TextAnimation : Animation
    {

        private int index = 0;

        private string finalText = "";

        public TextAnimation(string text, int interval)
        {
            finalText = text;
            this.interval = interval;
        }

        public void Update(GameTime gameTime, ref string text)
        {
            base.Update(gameTime);

            if (time > interval)
            {
                if (index < finalText.Length)
                    text += new string(finalText.ToCharArray(index, 1));
                else
                    hasFinish = true;

                index++;
                time = 0;
            }
        }
    }
}
