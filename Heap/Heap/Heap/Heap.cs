using System;
using System.Collections.Generic;
using System.Text;

namespace Heap
{
    public class Heap
    {
        private int[] items = new int[10];
        private int size;

        public void Insert(int value)
        {
            if (this.IsFull())
            {
                throw new IndexOutOfRangeException();
            }
            items[size++] = value;
           
            this.BubbleUp();
        }

        public bool IsFull()
        {
            return size == items.Length;
        }

        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index] > items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
