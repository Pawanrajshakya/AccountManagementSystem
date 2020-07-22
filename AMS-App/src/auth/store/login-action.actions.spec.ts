import * as fromLoginAction from './login-action.actions';

describe('loadLoginActions', () => {
  it('should return an action', () => {
    expect(fromLoginAction.loadLoginActions().type).toBe('[LoginAction] Load LoginActions');
  });
});
