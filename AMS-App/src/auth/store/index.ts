import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer,
  createReducer,
  on
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import { IAuthData } from 'src/_models/auth-data';
import { loadAuthsSuccess, loadAuthsFailure } from './auth.actions';

export const loginStateFeatureKey = 'loginState';

export interface LoginState {
  isAuthenticated: boolean;
  data: IAuthData;
}

export const initialState: LoginState = { isAuthenticated: false, data: undefined };

export const reducers = createReducer(
  initialState,
  on(loadAuthsSuccess, (state, action) => {
    return {
      isAuthenticated: true,
      data: action.data
    };
  }),
  on(loadAuthsFailure, (state, action) => {
    return {
      isAuthenticated: false,
      data: state.data
    };
  })
);

export const selectAuthFeature = createFeatureSelector<LoginState>(
  loginStateFeatureKey
);

export const selectIsAuthenticated = createSelector(
  selectAuthFeature,
  (state: LoginState) => state.isAuthenticated
);

export const selectAuthenticatedUser = createSelector(
  selectAuthFeature,
  (state: LoginState) => state.isAuthenticated ? state.data.username : ''
);

export const metaReducers: MetaReducer<LoginState>[] = !environment.production ? [] : [];
