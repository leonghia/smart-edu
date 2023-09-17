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
            <student-navbar></student-navbar>
            <student-sidebar></student-sidebar>
            <student-main></student-main>
        </div>
        `;
    }
}

customElements.define("student-dashboard", StudentDashboardComponent);