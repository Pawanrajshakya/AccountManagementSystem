using System.Collections.Generic;

namespace Persistence_Layer.Models
{
    public class Client : Audit
    {
        // public Client()
        // {
        //     //Accounts = new List<Account>();
        // }
        public string Name { get; set; }

        public Business Business { get; set; }
        
        public int BusinessId { get; set; }

        //public List<Account> Accounts { get; set; }
    }
}