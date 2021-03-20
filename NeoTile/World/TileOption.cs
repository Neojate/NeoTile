
namespace NeoTile.World
{
    //Esta clase está pensada para poder tocar las opciones de los tiles en el constructor de la clase Tile.
    public class TileOption
    {
        //Determina el tamaño de los tiles. Por defecto los tiles son de 32x32.
        public static Size Size { get; set; } = new Size(32, 32);

        //Determina el coeficiente de rozamiento (dificultad del tile). Por defecto es 0 y es un valor que va del 0 al 1.
        public static float Friction { get; set; } = 0f;
    }
}
