using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeoTile.Components
{
    public struct Style
    {
        //Textura del fondo
        public Texture2D Texture { get; set; }

        //Color del fondo
        public Color BgColor { get; set; }

        //Color del fondo en :hover
        public Color HoverBgColor { get; set; }

        //Color del fondo en :disabled
        public Color DisabledBgColor { get; set; } 

        //Fuente del texto
        public SpriteFont Font { get; set; }

        //Color del texto
        public Color FontColor { get; set; }

        //Color del texto en :hover
        public Color HoverFontColor { get; set; }

        //Color del texto en :disabled
        public Color DisabledFontColor { get; set; }

        //Padding
        public Vector2 Padding { get; set; }
    }
}
