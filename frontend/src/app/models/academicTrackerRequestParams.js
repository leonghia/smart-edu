export class AcademicTrackerRequestParams {
    #studentId;
    #from;
    #to;

    constructor() {

    }

    get studentId() {
        return this.#studentId;
    }

    get from() {
        return this.#from;
    }

    get to() {
        return this.#to;
    }

    set studentId(newStudentId) {
        this.#studentId = newStudentId;
    }

    set from(newFrom) {
        this.#from = newFrom;
    }

    set to(newTo) {
        this.#to = newTo;
    }
}