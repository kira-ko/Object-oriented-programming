namespace RpgInventory.Domain.Entities;

public sealed class QuestItem : Item
{
    public string QuestKey { get; }

    public QuestItem(string name, double weight, string questKey)
        : base(name, weight)
    {
        if (string.IsNullOrWhiteSpace(questKey))
            throw new ArgumentException("QuestKey cannot be empty.", nameof(questKey));

        QuestKey = questKey;
    }

    public override string ToString() => $"{base.ToString()}, quest: {QuestKey}";
}
