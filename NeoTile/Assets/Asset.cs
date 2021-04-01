
using Microsoft.Xna.Framework.Content;

namespace NeoTile.Assets
{
    public class Asset
    {
        protected ContentManager content;

        public void LinkContent(ContentManager content)
        {
            this.content = content;
        }

    }
}
