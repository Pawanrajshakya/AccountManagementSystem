import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from 'src/User/login/login.component';
import { AddUserComponent } from 'src/user/add-user/add-user.component';
import { ListComponent } from 'src/user/list/list.component';
import { HomeComponent } from 'src/home/home.component';
import { AuthGuard } from 'src/_services/auth.guard';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'addUser', component: AddUserComponent, canActivate: [AuthGuard] },
    { path: 'addUser/:id', component: AddUserComponent, canActivate: [AuthGuard] },
    { path: 'listUser', component: ListComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: [AuthGuard]
})
export class AppRoutingModule { }
