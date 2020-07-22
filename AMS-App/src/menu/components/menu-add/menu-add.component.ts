import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from 'src/_services/alert.service';
import { IParam } from 'src/_models/param';
import { IMenu, IMainMenu, IMenuToSave } from 'src/_models/menu-data';
import { MenuService } from 'src/menu/services/menu.service';
import { RoleService } from 'src/role/services/role.service';
import { IRole } from 'src/_models/role-data';

@Component({
  selector: 'app-menu-add',
  templateUrl: './menu-add.component.html',
  styleUrls: ['./menu-add.component.css']
})
export class MenuAddComponent implements OnInit {

  menuForm: FormGroup;

  roles: IRole[];
  mainMenus: IMainMenu[] = [{ id: 0, title: 'None' }];
  menu: IMenu;
  menuToSave: IMenuToSave;
  id = 0;
  roleParam: IParam = {};

  constructor(
    private menuService: MenuService,
    private roleService: RoleService,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService) { }

  ngOnInit() {

    this.menuForm = new FormGroup({
      id: new FormControl(0),
      title: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      link: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      iconName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      selectedMainMenu: new FormControl([]),
      sortId: new FormControl(0, [Validators.required]),
      isActive: new FormControl(true),
      selectedUserRole: new FormControl([], [Validators.required])
    });
    
    this.id = this.route.snapshot.params.id;

    if (this.id === undefined) {
      this.id = 0;
      this.menuForm.get('selectedMainMenu').setValue(0);
    }

    this.roleService.get(this.roleParam).subscribe((data) => {
      console.log(data);
      this.roles = data.roles;
    }, (error) => {
      this.alertService.showAlert(error);
    });

    this.menuService.getMainMenus(this.id).subscribe(data => {
      data.forEach(element => {
        this.mainMenus.push({ id: element.id, title: element.title });
      });
    }, error => {
      this.alertService.showAlert(error);
    });

    

    this.menuService.getById(this.id).subscribe(
      (data) => {
        this.menu = data;
      },
      (error) => {
        this.alertService.showAlert(error);
      },
      () => {
        console.log(1, this.menu);
        this.menuForm.get('id').setValue(this.menu.id);
        this.menuForm.get('title').setValue(this.menu.title);
        this.menuForm.get('link').setValue(this.menu.link);
        this.menuForm.get('iconName').setValue(this.menu.iconName);
        this.menuForm.get('sortId').setValue(this.menu.sortId);
        this.menuForm.get('isActive').setValue(this.menu.isActive);
        const roles = [];

        this.menu.roles.forEach(element => {
          roles.push(element.id);
        });

        this.menuForm.get('selectedMainMenu').setValue(this.menu.mainMenuId);

        this.menuForm.get('selectedUserRole').setValue(roles);
      });

  }

  onSubmit() {

    this.menuToSave = {
      iconName: this.menuForm.get('iconName').value,
      title: this.menuForm.get('title').value,
      link: this.menuForm.get('link').value,
      mainMenuId: this.menuForm.get('selectedMainMenu').value,
      sortId: this.menuForm.get('sortId').value,
      isActive: this.menuForm.get('isActive').value,
      userRoles: this.menuForm.get('selectedUserRole').value.join(',')
    };
    console.log('???', this.menuToSave);
    if (this.id === 0) {
      this.menuService.add(this.menuToSave).subscribe((response) => {
        this.router.navigate(['/menu']);
      }, (error) => {
        this.alertService.showAlert(error);
      });
    } else {
      this.menuService.update(this.id, this.menuToSave).subscribe((response) => {
        this.router.navigate(['/menu']);
      }, (error) => {
        this.alertService.showAlert(error);
      });
    }
  }

  onCancel() {
    this.router.navigate(['/menu']);
  }
}
