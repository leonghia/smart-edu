export class RequestParams {
    pageSize;
    pageNumber;

    constructor(pageSize = 50, pageNumber = 1) {
        this.pageSize = pageSize;
        this.pageNumber = pageNumber;
    }
}

