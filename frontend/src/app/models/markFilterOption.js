export class MarkFilterOption {
    #semester;
    #fromYear;
    #toYear;

    constructor(semester = 0, fromYear = 0, toYear = 0) {
        this.#semester = semester;
        this.#fromYear = fromYear;
        this.#toYear = toYear;
    }

    get semester() {
        return this.#semester;
    }

    get fromYear() {
        return this.#fromYear;
    }

    get toYear() {
        return this.#toYear;
    }
}