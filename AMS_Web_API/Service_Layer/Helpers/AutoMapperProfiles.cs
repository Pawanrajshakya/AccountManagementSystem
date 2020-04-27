using AutoMapper;
using Service_Layer.Dtos;

namespace Service_Layer.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //User
            CreateMap<Persistence_Layer.Models.User, UserDto>().ForMember(x => x.UserRole, opt => opt.Ignore());
            CreateMap<UserDto, Persistence_Layer.Models.User>().ForMember(x => x.UserRole, opt => opt.Ignore()); ;
            CreateMap<UserToSaveDto, Persistence_Layer.Models.User>().ForMember(x => x.UserRole, opt => opt.Ignore()); ;
            CreateMap<UserToEditDto, Persistence_Layer.Models.User>().ForMember(x => x.UserRole, opt => opt.Ignore()); ;

            //UserHistory
            CreateMap<Persistence_Layer.Models.UserHistory, UserHistoryDto>();
            CreateMap<UserHistoryDto, Persistence_Layer.Models.UserHistory>(); ;

            //Client
            CreateMap<Persistence_Layer.Models.Client, ClientDto>();
            CreateMap<ClientDto, Persistence_Layer.Models.Client>().ForMember(x => x.Business, opt => opt.Ignore());
            CreateMap<ClientToEditDto, Persistence_Layer.Models.Client>().ForMember(x => x.Business, opt => opt.Ignore());
            CreateMap<ClientToSaveDto, Persistence_Layer.Models.Client>().ForMember(x => x.Business, opt => opt.Ignore());
            //.ForMember(x => x.Accounts, opt => opt.Ignore());

            //Role
            CreateMap<Persistence_Layer.Models.Role, Service_Layer.Dtos.RoleDto>();
            CreateMap<Service_Layer.Dtos.RoleDto, Persistence_Layer.Models.Role>();
            CreateMap<Service_Layer.Dtos.RoleToEditDto, Persistence_Layer.Models.Role>();
            CreateMap<Service_Layer.Dtos.RoleToSaveDto, Persistence_Layer.Models.Role>();

            //Group
            CreateMap<Persistence_Layer.Models.Group, Service_Layer.Dtos.GroupDto>();
            CreateMap<Service_Layer.Dtos.GroupDto, Persistence_Layer.Models.Group>();
            CreateMap<Service_Layer.Dtos.GroupToEditDto, Persistence_Layer.Models.Group>();
            CreateMap<Service_Layer.Dtos.GroupToSaveDto, Persistence_Layer.Models.Group>();

            //Relationship
            CreateMap<Persistence_Layer.Models.Relationship, Service_Layer.Dtos.RelationshipDto>();
            CreateMap<Service_Layer.Dtos.RelationshipDto, Persistence_Layer.Models.Relationship>();
            CreateMap<Service_Layer.Dtos.RelationshipToEditDto, Persistence_Layer.Models.Relationship>();
            CreateMap<Service_Layer.Dtos.RelationshipToSaveDto, Persistence_Layer.Models.Relationship>();

            //Business
            CreateMap<Persistence_Layer.Models.Business, Service_Layer.Dtos.BusinessDto>();
            CreateMap<Service_Layer.Dtos.BusinessDto, Persistence_Layer.Models.Business>();
            CreateMap<Service_Layer.Dtos.BusinessToSaveDto, Persistence_Layer.Models.Business>();
            CreateMap<Service_Layer.Dtos.BusinessToEditDto, Persistence_Layer.Models.Business>();

            //Account
            CreateMap<Persistence_Layer.Models.Account, Service_Layer.Dtos.AccountDto>();
            CreateMap<Service_Layer.Dtos.AccountDto, Persistence_Layer.Models.Account>()
            .ForMember(x => x.Client, opt => opt.Ignore())
            .ForMember(x => x.AccountType, opt => opt.Ignore())
            .ForMember(x => x.Relationship, opt => opt.Ignore());
            CreateMap<Service_Layer.Dtos.AccountToSaveDto, Persistence_Layer.Models.Account>()
            .ForMember(x => x.Client, opt => opt.Ignore())
            .ForMember(x => x.AccountType, opt => opt.Ignore())
            .ForMember(x => x.Relationship, opt => opt.Ignore());
            CreateMap<Service_Layer.Dtos.AccountToEditDto, Persistence_Layer.Models.Account>()
            .ForMember(x => x.Client, opt => opt.Ignore())
            .ForMember(x => x.AccountType, opt => opt.Ignore())
            .ForMember(x => x.Relationship, opt => opt.Ignore());
            //.ForMember(x => x.Transactions, opt => opt.Ignore());

            //AccountHistory
            CreateMap<Persistence_Layer.Models.AccountHistory, Service_Layer.Dtos.AccountHistoryDto>();
            CreateMap<Service_Layer.Dtos.AccountHistoryDto, Persistence_Layer.Models.AccountHistory>();

            //AccountType
            CreateMap<Persistence_Layer.Models.AccountType, Service_Layer.Dtos.AccountTypeDto>();
            CreateMap<Service_Layer.Dtos.AccountTypeDto, Persistence_Layer.Models.AccountType>();
            CreateMap<Service_Layer.Dtos.AccountTypeToEditDto, Persistence_Layer.Models.AccountType>();
            CreateMap<Service_Layer.Dtos.AccountTypeToSaveDto, Persistence_Layer.Models.AccountType>();

            //Transaction
            CreateMap<Persistence_Layer.Models.Transaction, Service_Layer.Dtos.TransactionDto>();
            CreateMap<Service_Layer.Dtos.TransactionDto, Persistence_Layer.Models.Transaction>()
            .ForMember(x => x.Account, opt => opt.Ignore())
            .ForMember(x => x.TransactionType, opt => opt.Ignore());
            CreateMap<Service_Layer.Dtos.TransactionToEditDto, Persistence_Layer.Models.Transaction>()
            .ForMember(x => x.Account, opt => opt.Ignore())
            .ForMember(x => x.TransactionType, opt => opt.Ignore());
            CreateMap<Service_Layer.Dtos.TransactionToSaveDto, Persistence_Layer.Models.Transaction>()
            .ForMember(x => x.Account, opt => opt.Ignore())
            .ForMember(x => x.TransactionType, opt => opt.Ignore());

            //TransactionType
            CreateMap<Persistence_Layer.Models.TransactionType, Service_Layer.Dtos.TransactionTypeDto>();
            CreateMap<Service_Layer.Dtos.TransactionTypeToSaveDto, Persistence_Layer.Models.TransactionType>()
            .ForMember(x => x.Account, opt => opt.Ignore());
            CreateMap<Service_Layer.Dtos.TransactionTypeToEditDto, Persistence_Layer.Models.TransactionType>()
            .ForMember(x => x.Account, opt => opt.Ignore()); CreateMap<Service_Layer.Dtos.TransactionTypeDto, Persistence_Layer.Models.TransactionType>()
             .ForMember(x => x.Account, opt => opt.Ignore());
        }
    }
}