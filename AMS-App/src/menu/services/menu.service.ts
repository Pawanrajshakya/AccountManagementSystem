import { Injectable } from '@angular/core';
import { Base } from 'src/_services/base';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IMenu, IMenus, IMenuToSave, IMainMenu } from 'src/_models/menu-data';
import { IParam } from 'src/_models/param';

@Injectable({
  providedIn: 'root'
})
export class MenuService extends Base {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) {
    super();
  }

  getById(id: number): Observable<IMenu> {
    console.log('id-getbyid', id);
    if (id === 0) {
      return new Observable((observe) => {
        console.log('id-getbyid', id);

        observe.next({
          id: 0,
          title: '',
          link: '',
          iconName: '',
          mainMenuId: 0,
          sortId: 0,
          roles: [],
          isActive: true
        });
      });
    } else {
      return this.http.get<IMenu>(this.baseUrl + 'menu\\' + id);
    }
  }

  get(parameters: IParam): Observable<IMenus> {
    const httpParams = this.getHttpParams(parameters);

    console.log(parameters.sortDirection);

    return this.http.get<IMenus>(this.baseUrl + 'menu', { params: httpParams });

  }

  getMainMenus(id: number): Observable<IMainMenu[]> {
    return this.http.get<IMainMenu[]>(this.baseUrl + 'menu/mainmenus/' + id);
  }

  add(newMenu: IMenuToSave) {
    console.log(newMenu);
    return this.http.post(this.baseUrl + 'menu', newMenu);
  }

  update(id: number, newMenu: IMenuToSave) {
    return this.http.patch(this.baseUrl + 'menu/' + id, newMenu);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + 'menu/' + id);
  }

}
