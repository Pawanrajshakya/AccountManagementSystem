namespace Service_Layer.Dtos
{
    public class TransactionTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; }
    }
}