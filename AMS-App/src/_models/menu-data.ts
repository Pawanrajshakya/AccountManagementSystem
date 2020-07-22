export class IMenu {
    id: number;
    title: string;
    link?: string;
    iconName?: string;
    mainMenuId?: number;
    sortId?: number;
    roles?: any[];
    isActive: boolean;

}

export interface IMenus {
    currentPage: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
    menus: IMenu[];
}

export interface IMenuToSave {
    title: string;
    link?: string;
    iconName?: string;
    mainMenuId?: number;
    sortId?: number;
    userRoles?: string;
    isActive: boolean;
}

export interface IMainMenu {
    id: number;
    title: string;
}
