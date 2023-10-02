export class AcademicProgressRequestParams {
    #studentId;
    #date;

    constructor() {
        
    }

    get studentId() {
        return this.#studentId;
    }

    get date() {
        return this.#date;
    }

    set studentId(newStudentId) {
        this.#studentId = newStudentId;
    }

    set date(newDate) {
        this.#date = newDate;
    }
}