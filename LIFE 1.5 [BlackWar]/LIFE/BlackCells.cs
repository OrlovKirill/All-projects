using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFE
    {
    class BlackCells
        {

        struct BCells
            {
            public int x;
            public int y;
            }

        BCells[] colony;
        public byte direction;
        bool isCollision;

        List<byte> letsWithBorder;
        List<int[]> letsWithWhite;
        List<int[]> neighbourOfWhite;
        List<BlackCells> letsWithColony;

        public BlackCells ()
            {
            colony = new BCells[4];
            SetDirection();
            letsWithBorder = new List<byte>();
            letsWithWhite = new List<int[]>();
            neighbourOfWhite = new List<int[]>();
            letsWithColony = new List<BlackCells>();
            }

        public void Add(int x, int y)
            {
            int i = 0;

            while (i<colony.Length && !Equals(null , colony[i]))
                i++;

            if (i < colony.Length)
                {
                colony[i].x = x;
                colony[i].y = y;
                }
            else
                {
                Array.Resize(ref colony , i+1);
                colony[i].x = x;
                colony[i].y = y;
                }
            }

        public void Delete(int x, int y)
            {
            foreach (BCells cell in colony)
                if (cell.x==x && cell.y==y)
                    {
                    for (int i = Array.IndexOf(colony , cell) ; i < colony.Length - 1 ; i++)
                        colony[i] = colony[i + 1];
                    Array.Resize(ref colony , colony.Length-1);
                    }
            }

        public void SetDirection ()
            {
            Random rand = new Random();
            direction = Convert.ToByte(rand.Next(4));
            if (letsWithBorder!=null && letsWithBorder.Count > 0)
                foreach (byte let in letsWithBorder)
                    if (direction == let)
                        SetDirection();
            }   // 0-вправо 1-вверх 2-влево 3-вниз

        public void MakeTurn ()
            {
            isCollision = false;

            if (CollisionWithWall())
                {
                isCollision = true;
                SetDirection();
                }

            if (CollisionWithWhiteCell())
                {
                isCollision = true;

                for (int i=0 ;i<letsWithWhite.Count ;i++)
                    if (NumWhiteNeighbors(letsWithWhite[i][0] , letsWithWhite[i][1]) + 1 <= NumBlackNeighbors(letsWithWhite[i][0] , letsWithWhite[i][1]))
                        {
                        Add(letsWithWhite[i][0] , letsWithWhite[i][1]);
                        Terrain.cells[letsWithWhite[i][0] , letsWithWhite[i][1]].stateAfter = false;
                        }
                    else
                        {
                        Delete(neighbourOfWhite[i][0] , neighbourOfWhite[i][1]);
                        Terrain.cells[neighbourOfWhite[i][0] , neighbourOfWhite[i][1]].stateAfter = true;
                        }
                }

            if (CollisionWithColony())
                {
                isCollision = true;

                foreach (BlackCells blackcells in letsWithColony)
                    {
                    foreach (BCells bcell in blackcells.colony)
                        Add(bcell.x , bcell.y);
                    Terrain.listBCells.Remove(blackcells);
                    }
                }

            if (!isCollision)
                {
                Move();
                CheckDeath();
                }

            }


        public bool CollisionWithWall ()
            {
            letsWithBorder.Clear();
            foreach (BCells cell in colony)
                {
                if (cell.x == 0)
                    letsWithBorder.Add(2);
                if (cell.x == Form1.size-1)
                    letsWithBorder.Add(0);
                if (cell.y == 0)
                    letsWithBorder.Add(1);
                if (cell.y == Form1.size - 1)
                    letsWithBorder.Add(3);
                }
            if (letsWithBorder.Count == 0)
                return false;
            else
                return true;
            }

        public bool CollisionWithWhiteCell ()
            {
            letsWithWhite.Clear();
            neighbourOfWhite.Clear();
            foreach (BCells cell in colony)
                {
                if (cell.x + 1 < Form1.size && Terrain.cells[cell.x + 1 , cell.y].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x + 1 , cell.y }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x + 1 , cell.y });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                if (cell.x - 1 >= 0 && Terrain.cells[cell.x - 1 , cell.y].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x - 1 , cell.y }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x - 1 , cell.y });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                if (cell.y - 1 >= 0 && Terrain.cells[cell.x , cell.y - 1].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x , cell.y - 1 }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x , cell.y - 1 });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                if (cell.y + 1 < Form1.size && Terrain.cells[cell.x , cell.y + 1].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x , cell.y + 1 }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x , cell.y + 1 });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                if (cell.y + 1 < Form1.size && cell.x + 1 < Form1.size && Terrain.cells[cell.x + 1 , cell.y + 1].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x + 1 , cell.y + 1 }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x + 1 , cell.y + 1 });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                if (cell.x - 1 >= 0 && cell.y - 1 >= 0 && Terrain.cells[cell.x - 1 , cell.y - 1].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x - 1 , cell.y - 1 }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x - 1 , cell.y - 1 });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                if (cell.y + 1 < Form1.size && cell.x - 1 >= 0 && Terrain.cells[cell.x - 1 , cell.y + 1].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x - 1 , cell.y + 1 }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x - 1 , cell.y + 1 });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                if (cell.x + 1 < Form1.size && cell.y - 1 >= 0 && Terrain.cells[cell.x + 1 , cell.y - 1].stateAfter && letsWithWhite.IndexOf(new int[] { cell.x + 1 , cell.y - 1 }) < 0)
                    {
                    letsWithWhite.Add(new int[] { cell.x + 1 , cell.y - 1 });
                    neighbourOfWhite.Add(new int[] { cell.x , cell.y });
                    }
                }
            if (letsWithWhite.Count == 0)
                return false;
            else
                return true;

            }

        public bool CollisionWithColony ()
            {
            letsWithColony.Clear();
            foreach (BCells cell in colony)
                {
                if (Terrain.arrayBCells[cell.x + 1 , cell.y])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x + 1 && curCell.y == cell.y && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                if (Terrain.arrayBCells[cell.x , cell.y + 1])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x && curCell.y == cell.y + 1 && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                if (Terrain.arrayBCells[cell.x - 1 , cell.y])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x - 1 && curCell.y == cell.y && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                if (Terrain.arrayBCells[cell.x , cell.y - 1])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x && curCell.y == cell.y - 1 && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                if (Terrain.arrayBCells[cell.x + 1 , cell.y + 1])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x + 1 && curCell.y == cell.y + 1 && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                if (Terrain.arrayBCells[cell.x - 1 , cell.y - 1])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x - 1 && curCell.y == cell.y - 1 && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                if (Terrain.arrayBCells[cell.x + 1 , cell.y - 1])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x + 1 && curCell.y == cell.y - 1 && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                if (Terrain.arrayBCells[cell.x - 1 , cell.y + 1])
                    foreach (BlackCells col in Terrain.listBCells)
                        foreach (BCells curCell in col.colony)
                            if (curCell.x == cell.x - 1 && curCell.y == cell.y + 1 && letsWithColony.IndexOf(col) < 0)
                                letsWithColony.Add(col);
                }
            if (letsWithColony.Count > 0)
                return true;
            else
                return false;
            }

        public void Move ()
            {
            switch (direction)
                {
                case 0:
                    for (int i = 0 ; i < colony.Length ; i++)
                        {
                        Terrain.arrayBCells[colony[i].x , colony[i].y] = false;
                        colony[i].x++;
                        }
                    foreach (BCells cell in colony)
                        Terrain.arrayBCells[cell.x , cell.y] = true;
                    break;
                case 1:
                    for (int i = 0 ; i < colony.Length ; i++)
                        {
                        Terrain.arrayBCells[colony[i].x , colony[i].y] = false;
                        colony[i].y--;
                        }
                    foreach (BCells cell in colony)
                        Terrain.arrayBCells[cell.x , cell.y] = true;
                    break;
                case 2:
                    for (int i = 0 ; i < colony.Length ; i++)
                        {
                        Terrain.arrayBCells[colony[i].x , colony[i].y] = false;
                        colony[i].x--;
                        }
                    foreach (BCells cell in colony)
                        Terrain.arrayBCells[cell.x , cell.y] = true;
                    break;
                case 3:
                    for (int i = 0 ; i < colony.Length ; i++)
                        {
                        Terrain.arrayBCells[colony[i].x , colony[i].y] = false;
                        colony[i].y++;
                        }
                    foreach (BCells cell in colony)
                        Terrain.arrayBCells[cell.x , cell.y] = true;
                    break;
                }
            }

        public void CheckDeath ()
            {
            foreach (BCells cell in colony)
                {
                byte n = NumBlackNeighbors(cell.x , cell.y);
                if (n < 2 || n > 3)
                    {
                    Terrain.arrayBCells[cell.x , cell.y] = false;
                    Delete(cell.x , cell.y);
                    }
                }
            }

        public byte NumWhiteNeighbors (int x, int y)
            {
            byte n = 0;
            if (x + 1 < Form1.size && y + 1 < Form1.size)
                if (Terrain.cells[x + 1 , y + 1].stateAfter)
                    n++;
            if (x - 1 >= 0 && y - 1 >= 0)
                if (Terrain.cells[x - 1 , y - 1].stateAfter)
                    n++;
            if (x + 1 < Form1.size && y - 1 >= 0)
                if (Terrain.cells[x + 1 , y - 1].stateAfter)
                    n++;
            if (x - 1 >= 0 && y + 1 < Form1.size)
                if (Terrain.cells[x - 1 , y + 1].stateAfter)
                    n++;
            if (x + 1 < Form1.size)
                if (Terrain.cells[x + 1 , y].stateAfter)
                    n++;
            if (y + 1 < Form1.size)
                if (Terrain.cells[x , y + 1].stateAfter)
                    n++;
            if (x - 1 >= 0)
                if (Terrain.cells[x - 1 , y].stateAfter)
                    n++;
            if (y - 1 >= 0)
                if (Terrain.cells[x , y - 1].stateAfter)
                    n++;
            return n;
            }
        public byte NumBlackNeighbors (int x , int y)
            {
            byte n = 0;
            if (x + 1 < Form1.size && y + 1 < Form1.size)
                if (Terrain.arrayBCells[x + 1 , y + 1])
                    n++;
            if (x - 1 >= 0 && y - 1 >= 0)
                if (Terrain.arrayBCells[x - 1 , y - 1])
                    n++;
            if (x + 1 < Form1.size && y - 1 >= 0)
                if (Terrain.arrayBCells[x + 1 , y - 1])
                    n++;
            if (x - 1 >= 0 && y + 1 < Form1.size)
                if (Terrain.arrayBCells[x - 1 , y + 1])
                    n++;
            if (x + 1 < Form1.size)
                if (Terrain.arrayBCells[x + 1 , y])
                    n++;
            if (y + 1 < Form1.size)
                if (Terrain.arrayBCells[x , y + 1])
                    n++;
            if (x - 1 >= 0)
                if (Terrain.arrayBCells[x - 1 , y])
                    n++;
            if (y - 1 >= 0)
                if (Terrain.arrayBCells[x , y - 1])
                    n++;
            return n;
            }

        }
    }