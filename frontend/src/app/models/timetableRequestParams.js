export class TimetableRequestParams {
    #mainClassId;
    #from = new Date();
    #to = new Date();

    constructor(mainClassId) {
        this.#mainClassId = mainClassId;
    }

    get mainClassId() {
        return this.#mainClassId;
    }

    get from() {
        return this.#from;
    }

    get to() {
        return this.#to;
    }

    set from(from) {
        this.#from = from;
    }

    set to(to) {
        this.#to = to;
    }
}