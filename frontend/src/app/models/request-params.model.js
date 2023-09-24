export class RequestParams {
    pageSize;
    pageNumber;

    constructor() {
        this.pageSize = 50;
        this.pageNumber = 1;
    }

    constructor(pageSize, pageNumber) {
        this.pageSize = pageSize;
        this.pageNumber = pageNumber;
    }
}

