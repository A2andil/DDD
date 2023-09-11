namespace A5bark.Core.BuildingBlocks
{
    public interface IBusinessRule
    {
        string Message { get; }
        bool IsBroken();
    }
}
