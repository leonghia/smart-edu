export class StudentMainComponent extends HTMLElement {
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
    <div>
        <timetable-week-view></timetable-week-view>
    </div>
        `;
    }
}

customElements.define("student-main", StudentMainComponent);