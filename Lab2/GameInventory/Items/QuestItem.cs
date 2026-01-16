namespace GameInventory.Items 
{
    public class QuestItem : ItemBase 
    {
        public string QuestId { get; } 

        public QuestItem(string id, string name, int level, string questId) 
            : base(id, name, level)
        {
            QuestId = questId;
        }

        public override string GetInfo() 
        {
            return $"QuestItem: {Name}, Level: {Level}, QuestId: {QuestId}";
        }
    }
}
