//  --> TODO: Merge with CloudSyncHelper project.
namespace XElement.DesignPatterns.BehavioralPatterns.Command
{
    public interface IDoUndoCommand
    {
        void Do();
        void Undo();
    }
}