namespace Service_Layer.Dtos
{
    public class TransactionTypeToSaveDto
    {
        public string Description { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; }
    }
}