
export interface IUser {
  id: number;
  username: string;
  name: string;
  password: string;
  email: string;
  isActive: boolean;
  userRole: any[];
}

export interface IUsers {
  currentPage: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  users: IUser[];
}

export interface IUserToSave {
  username: string;
  password: string;
  name: string;
  email?: string;
  isActive: boolean;
  userRole: any[];
}