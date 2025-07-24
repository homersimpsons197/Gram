namespace GramR.View
{
    // Interfaces define a "contract" — what methods a class MUST implement
    public interface IEventAwareControl
    {
        // Any class using this interface must provide its own version of these methods:

        // This method is where the class should attach event handlers (e.g., Button.Click)
        void SubscribeEvents();

        // This method is for removing those event handlers to prevent bugs or memory leaks
        void UnsubscribeEvents();
    }
}
