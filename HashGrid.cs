using System;
using System.Collections.Generic;
using System.Drawing;
using System.Buffers;


namespace goodies.spatial
{

    public struct Query<T>
    {
        T[] queryData;
    }

    public struct GridQuadrant
    {
        public Rectangle[] cells;

        public GridQuadrant(Rectangle nw, Rectangle ne, Rectangle sw, Rectangle se)
        {
            cells = new Rectangle[4]{
                nw,
                ne,
                sw,
                se
            };
        }

        public void Intersect(Rectangle position)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if(Rectangle.Intersect(cells[i], position).IsEmpty) cells[i] = Rectangle.Empty;
            }
        }
    }

    public struct Grid
    {
        int gridSpacing;


        public Grid(int gridSpacing = 1)
        {
            this.gridSpacing = gridSpacing;
        }

        public GridQuadrant GetQuadrant(Rectangle position, bool intersect = true)
        {
            int halfWidth = position.Width / 2;
            int halfHeight = position.Height / 2;

            GridQuadrant quadrant = new GridQuadrant(
                new Rectangle((position.X - halfWidth) % gridSpacing, (position.Y - halfHeight) % gridSpacing, gridSpacing, gridSpacing),
                new Rectangle((position.X + halfWidth) % gridSpacing, (position.Y - halfHeight) % gridSpacing, gridSpacing, gridSpacing),
                new Rectangle((position.X - halfWidth) % gridSpacing, (position.Y + halfHeight) % gridSpacing, gridSpacing, gridSpacing),
                new Rectangle((position.X + halfWidth) % gridSpacing, (position.Y + halfHeight) % gridSpacing, gridSpacing, gridSpacing)
            );

            if (intersect) quadrant.Intersect(position);

            return quadrant;
        }
    }

    public class HashGrid<E>
    {
        private Dictionary<Rectangle, HashSet<E>> gridContent;
        private Grid grid;


        public HashGrid(int spacing)
        {
            this.grid = new Grid(spacing);
            this.gridContent = new Dictionary<Rectangle, HashSet<E>>();
        }




        public void Insert(Rectangle position, E entityID)
        {
            var gq = grid.GetQuadrant(position);
            
            foreach(var cell in gq.cells){
                if(!cell.IsEmpty) 
            }
        }





        public Query<E> GetWithinDistance()
        {
            return new Query<T>();
        }

    }
}
