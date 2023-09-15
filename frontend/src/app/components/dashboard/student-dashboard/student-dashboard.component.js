export class StudentDashboardComponent extends HTMLElement {
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
        <div class="h-full">
            <student-sidebar></student-sidebar>
            <student-navbar></student-navbar>
            <student-secondary-col></student-secondary-col>
        </div>
        `;
    }
}

customElements.define("student-dashboard", StudentDashboardComponent);