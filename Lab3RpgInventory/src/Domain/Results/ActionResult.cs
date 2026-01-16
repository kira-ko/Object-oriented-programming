namespace RpgInventory.Domain.Results;

public class ActionResult
{
    public bool Success { get; }
    public string Message { get; }

    protected ActionResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static ActionResult Ok(string message) => new(true, message);
    public static ActionResult Fail(string message) => new(false, message);
}
