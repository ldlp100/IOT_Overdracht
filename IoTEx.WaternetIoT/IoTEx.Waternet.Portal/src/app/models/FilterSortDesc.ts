import { BaseDTO } from "./baseDTO";

export enum FilterOperator {
  Eq = 0, NotEq = 1, Contains = 2, DoesNotContain = 3, StartWith = 4,
  EndWith = 5, IsNull = 6, IsNotNull = 7, Greater = 8, GreaterEqual = 9, Lower = 10, LowerEqual = 11
}
export enum SortDirection {
  ASC = 0, DESC = 1
}

export class FilterDesc {
  member: string | undefined;
  operator: FilterOperator | undefined;
  value: any | undefined;
}
export class SortDesc {
  member: string | undefined;
  direction: SortDirection | undefined;
}
