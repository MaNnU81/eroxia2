namespace eroxia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new DBStorage();
            var logic = new BusinessLogic(storage);
            var tui = new Tui(logic);
            tui.Start();
        }


    }
}
