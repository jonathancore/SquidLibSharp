﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SquidLib.SquidGrid {
    public class Grid<T> {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private T[] raw;
        public T Outside { get; set; }

        public Grid() : this(80, 24, default) { }

        public Grid(int width, int height) : this(width, height, default) { }

        public Grid(int width, int height, T outside) {
            Width = Math.Max(1, width);
            Height = Math.Max(1, height);
            Outside = outside;
            raw = new T[Width * Height];
        }
        public Grid(int width, int height, T outside, T initialFill) : this(width, height, outside){
            for(int i = Width * Height - 1; i >= 0; i--) {
                raw[i] = initialFill;
            }
        }

        public T this[int x, int y] { get {
                if (x < 0 || x >= Width || y < 0 || y >= Height)
                    return Outside;
                return raw[y * Width + x];
            }
            set {
                if (x >= 0 && x < Width && y >= 0 && y < Height)
                    raw[y * Width + x] = value;
            }
        }
        public void RowEdit(int x, int y, IEnumerable<T> sequence) {
            if(!(sequence is null) && x >= 0 && x < Width && y >= 0 && y < Height) {
                foreach(T item in sequence) {
                    raw[y * Width + x++] = item;
                    if (x >= Width) break;
                }
            }
        }
        /// <summary>
        /// The data this uses internally, as a row-major 1D array of T with length <code>Width * Height</code>.
        /// You can place rows directly into this, but they will not be validated for bounds.
        /// </summary>
        /// <returns>The row-major 1D T array this uses internally.</returns>
        public T[] RawData() => raw;
    }

}