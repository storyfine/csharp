namespace StoryFine
{
    public interface ISFModule
    {
        string Id { get; }
        ISFModule Next { get; }
    }
}
