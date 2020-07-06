export interface IRole {
    id: number;
    description: string;
    isActive: boolean;
}

export interface IRoles {
    currentPage: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
    roles: IRole[];
}

export interface IRoleToSave {
    description: string;
    isActive: boolean;
}
