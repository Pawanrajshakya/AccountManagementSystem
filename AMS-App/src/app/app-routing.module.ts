import { NgModule } from '@angular/core';
import { Routes, RouterModule} from '@angular/router';
import { LoginComponent } from 'src/User/login/login.component';
import { AddUserComponent } from 'src/user/add-user/add-user.component';

const routes: Routes = [
    {path: '', component: AddUserComponent},
    {path: 'login', component: LoginComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
