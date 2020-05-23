export class User {
  public fullName: string;

  constructor(
    private id: string,
    public firstName: string,
    public lastName: string,
    public email: string,
    private expTimestamp: number,
  ) {
    this.fullName = firstName + ' ' + lastName;
  }

  get _id() {
    if (!this.expTimestamp || new Date().getTime() > (this.expTimestamp * 1000)) {
      return null;
    }
    return this.id;
  }

  get _tokenExp() {
    if (!this.expTimestamp || new Date().getTime() > (this.expTimestamp * 1000)) {
      return null;
    }
    return this.expTimestamp * 1000;
  }
}