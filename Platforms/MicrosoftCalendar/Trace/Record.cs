namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Trace
{
    public class Record
    {
        public bool Ignored { get; set; }

        public string RefHash { get; set; }

        public bool RefChanged { get; set; }

        public string DetailHash { get; set; }

        public bool DetailChanged { get; set; }
    }
}