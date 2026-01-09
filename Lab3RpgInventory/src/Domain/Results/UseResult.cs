namespace RpgInventory.Domain.Results;

public sealed class UseResult : ActionResult
{
    private UseResult(bool success, string message) : base(success, message) { }

    public static UseResult Ok(string message = "Used") => new(true, message);
    public static UseResult Fail(string message) => new(false, message);
}
