namespace NewLinqFeatures
{
    public class Cyclist
    {
        public static readonly Cyclist Empty = new Cyclist(){Id =-1 , Name = "None", Age = -1};

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}