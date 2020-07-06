import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';

export const loginStateFeatureKey = 'loginState';

export interface LoginState {

}

export const reducers: ActionReducerMap<LoginState> = {

};


export const metaReducers: MetaReducer<LoginState>[] = !environment.production ? [] : [];
