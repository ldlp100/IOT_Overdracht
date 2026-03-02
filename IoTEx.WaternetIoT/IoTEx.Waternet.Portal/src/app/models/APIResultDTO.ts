
export class APIResultDTO<T> {
  public error: string | undefined;
  public value: T | undefined;
  public isOk: boolean =true;
}
