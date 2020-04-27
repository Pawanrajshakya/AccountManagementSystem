namespace Service_Layer.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BusinessId { get; set; }

        public bool IsActive { get; set; }
    }
}