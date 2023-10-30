using System;
using Raylib_cs;

// 类似水墨效果
public class Rewrite_W2B {

    Random rd;
    byte[,] data;
    Color wcolor;
    Color bcolor;

    public Rewrite_W2B(int width, int height, int startX, int startY, Color wcolor, Color bcolor) {
        rd = new Random(width * height * startX * startY);
        data = new byte[width, height];
        data[startX, startY] = 1;
        this.wcolor = wcolor;
        this.bcolor = bcolor;
    }

    public void AddB(int x, int y) {
        data[x, y] = 1;
    }

    public void Update() {
        for (int i = 0; i < data.GetLength(0); i += 1) {
            for (int j = 0; j < data.GetLength(1); j += 1) {
                byte old = data[i, j];
                if (old == 1) {
                    // Neighbor 3*3 random
                    int x = i + rd.Next(-1, 2);
                    int y = j + rd.Next(-1, 2);
                    if (x >= 0 && x < data.GetLength(0) && y >= 0 && y < data.GetLength(1)) {
                        data[x, y] = 1;
                    }
                }
            }
        }
    }

    public void Draw() {
        for (int i = 0; i < data.GetLength(0); i += 1) {
            for (int j = 0; j < data.GetLength(1); j += 1) {
                byte old = data[i, j];
                if (old == 1) {
                    // Draw
                    Raylib.DrawRectangle(i, j, 1, 1, bcolor);
                } else {
                    Raylib.DrawRectangle(i, j, 1, 1, wcolor);
                }
            }
        }
    }

}