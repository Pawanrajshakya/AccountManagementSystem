namespace Service_Layer.Dtos
{
    public class TransactionTypeToEditDto
    {
        public string Description { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; }
    }
}