namespace StoryFine
{
    public class SFCondition : ISFModule
    {
        private string id;
        public string Id { get { return id; } }
        private ISFModule prev;
        private ISFLogical l;
        private ISFModule _then;
        private ISFModule _else;
        private ConditionResult result = ConditionResult.UNKNOWN;
        public ConditionResult Result { get { return result; } }
        public enum ConditionResult { UNKNOWN, TRUE, FALSE };
        public SFCondition(string id, ISFModule p, ISFLogical l)
        {
            this.id = id;
            prev = p;
            this.l = l;
        }
        public ISFModule Previous { get { return prev; } }
        public ISFModule Then
        {
            get { return _then; }
            set
            {
                if (_then != null) throw new NextAlreadySetException();
                _then = value;
            }
        }
        public ISFModule Else
        {
            get { return _else; }
            set
            {
                if (_else != null) throw new NextAlreadySetException();
                _else = value;
            }
        }
        public ISFModule Next
        {
            get
            {
                if (result == ConditionResult.UNKNOWN)
                {
                    if (l.Value) result = ConditionResult.TRUE;
                    else result = ConditionResult.FALSE;
                }
                return result == ConditionResult.TRUE ? _then : _else;
            }
        }
    }
}
