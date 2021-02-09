using System;

namespace StoryFine
{
    class SFChoice : ISFModule
    {
        private string id;
        public string Id { get { return id; } }
        private ISFModule prev;
        private ISFModule a;
        private ISFModule b;
        private ChoiceResult result = ChoiceResult.UNKNOWN;
        public ChoiceResult Result { get { return result; } }
        public enum ChoiceResult { UNKNOWN, A, B };
        public SFChoice(string id, ISFModule p)
        {
            this.id = id;
            prev = p;
        }
        public ISFModule Previous { get { return prev; } }
        public ISFModule A
        {
            get { return a; }
            set
            {
                if (a != null) throw new NextAlreadySetException();
                a = value;
            }
        }
        public ISFModule B
        {
            get { return b; }
            set
            {
                if (b != null) throw new NextAlreadySetException();
                b = value;
            }
        }
        public void Choose(ChoiceResult r)
        {
            if(result != ChoiceResult.UNKNOWN) throw new ChoiceAlreadyMadeException();
            if(r == ChoiceResult.UNKNOWN) throw new CannotChooseUnknownException();
            result = r;
        }
        public ISFModule Next
        {
            get
            {
                if (result == ChoiceResult.UNKNOWN)
                {
                    throw new ChoiceNotMadeException();
                }
                return result == ChoiceResult.A ? a : b;
            }
        }
        public class ChoiceNotMadeException : Exception
        {

        }
        public class ChoiceAlreadyMadeException : Exception
        {

        }
        public class CannotChooseUnknownException : Exception
        {

        }
    }
}
