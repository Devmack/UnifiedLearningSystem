namespace UnifiedLearningSystem.CommonAbstraction.Interfaces
{
    public interface ILogger
    {
        public void SendLog(string message, DateTime timeStamp);
    }
}
