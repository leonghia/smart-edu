export class StudentTimetableComponent extends HTMLElement {
    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
            <timetable-weekview></timetable-weekview>
        `;
    }
}

customElements.define("student-timetable", StudentTimetableComponent);