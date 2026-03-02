
import { FilterDesc, SortDesc } from "./FilterSortDesc"

export class APIRequestDTO {
  constructor() {
    this.page = 0;
    this.filters = [];
    this.sorts = [];
  }
  page: number;
  pageSize: number=0;
  filters: FilterDesc[];
  sorts: SortDesc[];

}
