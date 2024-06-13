using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Interfaces
{
    public interface IHoneycombControl: IColored, IText
    {

        public int Bottom { get; }
        public IntPtr Handle { get; }
        
        public int Height { get; set; }
        public int Left { get; set; }
        public Point Location { get; set; }
        public Padding Margin { get; set; }
        public int Right { get; }
        public Size Size { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }

        
    }
}
