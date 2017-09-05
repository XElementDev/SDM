using XElement.DesignPatterns.BehavioralPatterns.Command;

namespace XElement.SDM.ManagementLogic
{
    public interface IProgramLogic : IDoUndoCommand
    {
        void DelayStartup();


        void PromoteStartup();
    }
}
