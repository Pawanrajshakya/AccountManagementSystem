import { createAction, props } from '@ngrx/store';
import { IAuthData } from 'src/_models/auth-data';

export const loadAuths = createAction(
  '[Auth: Login Component] Load Auths'
);

export const loadAuthsSuccess = createAction(
  '[Auth: Login Component] Load Auths Success',
  props<{ data: IAuthData }>()
);

export const loadAuthsFailure = createAction(
  '[Auth: Login Component] Load Auths Failure',
  props<{ error: any }>()
);
