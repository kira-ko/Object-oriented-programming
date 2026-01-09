namespace RpgInventory.Domain.Results;

public abstract class ActionResult
{
    public bool Success { get; }
    public string Message { get; }

    protected ActionResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}
