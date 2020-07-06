import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from 'src/auth/login/login.component';
import { AddUserComponent } from 'src/user/add/add-user.component';
import { ListUserComponent } from 'src/user/list/list-user.component';
import { HomeComponent } from 'src/home/home.component';
import { AuthGuard } from 'src/_services/auth.guard';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'addUser', component: AddUserComponent, canActivate: [AuthGuard] },
    { path: 'addUser/:id', component: AddUserComponent, canActivate: [AuthGuard] },
    { path: 'listUser', component: ListUserComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: [AuthGuard]
})
export class AppRoutingModule { }
