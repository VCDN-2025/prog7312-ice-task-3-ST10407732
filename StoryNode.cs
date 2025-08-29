namespace GameScriptManager
{
    public class StoryNode
    {
        public int Number;
        public string Text;
        public StoryNode Next;

        public StoryNode(int number, string text)
        {
            Number = number;
            Text = text;
            Next = null;
        }

        public override string ToString()
        {
            return $"{Number} {Text}";
        }
    }
}
