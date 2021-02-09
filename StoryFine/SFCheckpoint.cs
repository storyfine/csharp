namespace StoryFine
{
    public class SFCheckpoint : ISFModule, ISFLogical
    {
        private string id;
        public string Id { get{ return id; } }
        private bool isFinal;
        public bool IsFinal { get { return isFinal; } }
        private ISFModule prev;
        private ISFModule next;
        private bool activated = false;
        public SFCheckpoint(string id, ISFModule p, bool f) {
            this.id = id;
            prev = p;
            isFinal = f;
        }
        public ISFModule Previous { get { return prev; } }
        public ISFModule Next {
            get {
                if (IsFinal) throw new FinalCheckpointException();
                activated = true;
                return next;
            }
            set
            {
                if (IsFinal || next != null) throw new NextAlreadySetException();
                next = value;
            }
        }
        public bool Value { get { return activated; } }
    }
}
