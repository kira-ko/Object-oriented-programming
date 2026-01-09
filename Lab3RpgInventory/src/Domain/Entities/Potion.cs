namespace RpgInventory.Domain.Entities;

public sealed class Potion : Item
{
    public string Effect { get; }
    public int Charges { get; private set; }

    public Potion(string name, double weight, string effect, int charges)
        : base(name, weight)
    {
        if (string.IsNullOrWhiteSpace(effect))
            throw new ArgumentException("Effect cannot be empty.", nameof(effect));
        if (charges <= 0)
            throw new ArgumentOutOfRangeException(nameof(charges), "Charges must be positive.");

        Effect = effect;
        Charges = charges;
    }

    public bool HasCharges => Charges > 0;

    public void ConsumeOneCharge()
    {
        if (Charges <= 0)
            throw new InvalidOperationException("No charges left.");

        Charges--;
    }

    public override string ToString() => $"{base.ToString()}, effect: {Effect}, charges: {Charges}";
}
