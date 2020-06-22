export class User {
  public fullName: string;

  constructor(
    // tslint:disable-next-line:variable-name
    private _id: string,
    public firstName: string,
    public lastName: string,
    public email: string,
  ) {
    this.fullName = firstName + ' ' + lastName;
  }

  get id() {
    return this._id;
  }
}
