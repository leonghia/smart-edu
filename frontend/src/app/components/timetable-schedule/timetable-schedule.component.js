export class TimetableScheduleComponent extends HTMLElement {
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
<app-timetable></app-timetable>
        `;
    }
}

customElements.define("timetable-schedule", TimetableScheduleComponent);