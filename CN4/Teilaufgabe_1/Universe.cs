using System;


namespace Teilaufgabe_1
{
    public class Universe
    {
 
        public int Rows { get; }

        public int Cols { get; }

        public Cell[,] Map { get; }

        public int Generation { get; private set; }

        public Universe(int row, int col)
        {
            this.Rows = row;
            this.Cols = col;
            this.Map = new Cell[this.Cols,this.Rows];
            this.Generation = 0;
             cellHandler((col,row) => {
                 Cell cell = new Cell
                 {
                    IsAlive = new Random().Next(10) == 0
                 };
                 Map[col, row] = cell;
             });
        }

        public void cellHandler(Action<int,int> cellMehtod)
        {
            for(int cols = 0; cols <  this.Cols; cols++) {

                for (int rows = 0; rows < this.Rows; rows++)
                {

                    if(cellMehtod != null)
                    {
                        cellMehtod(cols,rows);
                    }
                    
                }
            }
        }

        public Cell checkCell(int colPos, int rowPos) {
            Cell cell = Map[colPos, rowPos];
            if (cell == null)
            {
                cell = new Cell();
            };
            return cell;
        }

        public void Clear() {
            cellHandler((colPos,rowPos) => {
                Cell cell = Map[colPos, rowPos];
                cell.WillBeAlive = false;
                cell.IsAlive    = false;
            });
            this.Generation = 0;
        }


        private int checkNeighbours(int colPos,int rowPos)
        {
            int aliveNeighbour = 0;
            /*Nachbarzellen von Links nach Rechts*/
            for (int xPos = -1; xPos <= 1; xPos++)
            {

                /*Nachbarzellen von Unten nach Oben*/
                for (int yPos = -1; yPos <= 1; yPos++)
                {
                    /*Nachbarzellen links oder rechts außerhalb des Spielfeldes*/
                    if (colPos + xPos < 0 || colPos + xPos >= Cols) continue;

                    /*Nachbarzellen unten oder oben außerhalb des Spielfeldes*/
                    if (rowPos + yPos < 0 || rowPos + yPos >= Rows) continue;

                    /*Nachbarzelle ist Zelle*/
                    if (xPos == 0 && yPos == 0) continue;

                    Cell neighCell = Map[colPos + xPos, rowPos + yPos];

                    if (neighCell.IsAlive)
                    {
                        aliveNeighbour++;
                    }

                }
            }

            return aliveNeighbour;
        }

        public void ComputeTransition() {

            cellHandler((colPos, rowPos) => {


                int aliveNeighbour = 0;

                aliveNeighbour = checkNeighbours(colPos, rowPos);

                Cell cell = Map[colPos, rowPos];

               /* Debug.WriteLine("Cell: x=" + colPos + ", y=" + rowPos + " is Alive = " + cell.IsAlive + " and will be " + cell.WillBeAlive + " and has " + aliveNeighbour);*/


                /*1. Eine tote Zelle mit genau drei lebenden Nachbarn wird in der Folgegeneration neu geboren.*/
                if (!cell.IsAlive && aliveNeighbour == 3)
                {
                    cell.WillBeAlive = true;
                    return;
                } 

                /*2. Lebende Zellen mit weniger als zwei lebenden Nachbarn sterben in der Folgegeneration an Einsamkeit.*/
                if (cell.IsAlive && aliveNeighbour < 2)
                {
                    cell.WillBeAlive = false;
                    return;
                }  

                /*3. Eine lebende Zelle mit zwei oder drei lebenden Nachbarn bleibt in der Folgegeneration am Leben.*/
                if (cell.IsAlive && (aliveNeighbour == 2| aliveNeighbour == 4))
                {
                    cell.WillBeAlive = true;
                    return;
                } 
                /*4. Lebende Zellen mit mehr als drei lebenden Nachbarn sterben in der Folgegeneration an Überbevölkerung.*/
                if (cell.IsAlive && aliveNeighbour > 3)
                {
                    cell.WillBeAlive = false;
                    return;
                } 
    
                          

            });

        }

        public void MakeTransition() {
            cellHandler((colPos, rowPos) => { 

                Cell cell = Map[colPos, rowPos];

               /* Debug.WriteLine("Make Transition - > Cell: x=" + colPos + ", y=" + rowPos + " is Alive = " + cell.IsAlive + " and will be " + cell.WillBeAlive);*/
                
                cell.IsAlive = cell.WillBeAlive;
            
            });
            this.Generation++;
        }
    }
}
