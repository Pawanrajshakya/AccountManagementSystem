import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'src/home/home.component';
import { AuthGuard } from 'src/_services/auth.guard';
import { AddUserComponent } from 'src/user/components/add/add-user.component';
import { ListUserComponent } from 'src/user/components/list/list-user.component';
import { LoginComponent } from 'src/auth/components/login/login.component';
import { ListRoleComponent } from 'src/role/components/list/list-role.component';
import { MenuListComponent } from 'src/menu/components/menu-list/menu-list.component';
import { MenuAddComponent } from 'src/menu/components/menu-add/menu-add.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'addUser', component: AddUserComponent, canActivate: [AuthGuard] },
    { path: 'addUser/:id', component: AddUserComponent, canActivate: [AuthGuard] },
    { path: 'user', component: ListUserComponent, canActivate: [AuthGuard] },
    { path: 'role', component: ListRoleComponent, canActivate: [AuthGuard] },
    { path: 'menu', component: MenuListComponent, canActivate: [AuthGuard] },
    { path: 'addMenu', component: MenuAddComponent, canActivate: [AuthGuard] },
    { path: 'addMenu/:id', component: MenuAddComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: [AuthGuard]
})
export class AppRoutingModule { }
