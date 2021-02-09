namespace StoryFine
{
    class SFEntry : ISFModule
    {
        private string id;
        public string Id { get { return id; } }
        private ISFModule next;
        public SFEntry(string id)
        {
            this.id = id;
        }
        public ISFModule Next {
            get { return next; }
            set
            {
                if (next != null) throw new NextAlreadySetException();
                next = value;
            }
        }
    }
}
