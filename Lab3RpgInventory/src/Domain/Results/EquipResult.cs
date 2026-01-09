namespace RpgInventory.Domain.Results;

public sealed class EquipResult : ActionResult
{
    private EquipResult(bool success, string message) : base(success, message) { }

    public static EquipResult Ok(string message = "Equipped") => new(true, message);
    public static EquipResult Fail(string message) => new(false, message);
}
