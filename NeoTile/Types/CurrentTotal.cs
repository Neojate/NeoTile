
namespace NeoTile.Types
{
    public class CurrentTotal
    {
        public int Current { get; set; }

        public int Total { get; set; }

        public CurrentTotal()
        {

        }

        public CurrentTotal(int current, int total)
        {
            Current = current;
            Total = total;
        }

        public CurrentTotal(int max)
        {
            Current = max;
            Total = max;
        }

        public override string ToString()
        {
            return $"{Current} / {Total}";
        }
    }
}
