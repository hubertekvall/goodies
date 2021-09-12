using System;
using System.Collections.Generic;
using System.Drawing;

namespace goodies
{
    public class HashGrid<T>
    {
        private Dictionary<Rectangle, HashSet<T>> gridCells;


        public HashGrid()
        {
            gridCells = new Dictionary<Rectangle, HashSet<T>>();
        }


        public void Insert(Rectangle rect, T value){
            
        }



    }
}
