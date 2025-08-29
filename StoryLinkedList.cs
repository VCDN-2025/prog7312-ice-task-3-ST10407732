using System.Collections.Generic;
using System.Text;

namespace GameScriptManager
{
    public class StoryLinkedList
    {
        public StoryNode Head;
        public int Count { get; private set; }

        public StoryLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public void Add(int number, string text)
        {
            var node = new StoryNode(number, text);
            if (Head == null)
                Head = node;
            else
            {
                var cur = Head;
                while (cur.Next != null) cur = cur.Next;
                cur.Next = node;
            }
            Count++;
        }

        public StoryNode GetNodeAt(int index)
        {
            if (index < 0 || index >= Count) return null;
            var cur = Head;
            for (int i = 0; i < index; i++) cur = cur.Next;
            return cur;
        }

        public void SortByNumber()
        {
            if (Head == null || Head.Next == null) return;
            bool swapped;
            do
            {
                swapped = false;
                var cur = Head;
                while (cur != null && cur.Next != null)
                {
                    if (cur.Number > cur.Next.Number)
                    {
                        int tmpN = cur.Number;
                        string tmpT = cur.Text;

                        cur.Number = cur.Next.Number;
                        cur.Text = cur.Next.Text;

                        cur.Next.Number = tmpN;
                        cur.Next.Text = tmpT;

                        swapped = true;
                    }
                    cur = cur.Next;
                }
            } while (swapped);
        }

        public string GetCombinedText()
        {
            var sb = new StringBuilder();
            var cur = Head;
            while (cur != null)
            {
                sb.AppendLine(cur.Text.Trim());
                sb.AppendLine();
                cur = cur.Next;
            }
            return sb.ToString().Trim();
        }
    }
}
