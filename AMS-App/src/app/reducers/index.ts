import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';


export interface AMSState {

}

export const reducers: ActionReducerMap<AMSState> = {

};


export const metaReducers: MetaReducer<AMSState>[] = !environment.production ? [] : [];
