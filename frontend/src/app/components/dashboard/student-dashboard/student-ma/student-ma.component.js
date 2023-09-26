export class StudentMarkAssessmentComponent extends HTMLElement {
    constructor() {
        super();
    }

    connectedCallback() {
       
        setTimeout(() => {
            this.innerHTML = this.#render();
        }, 500);
        this.innerHTML = `
        <div class="absolute -translate-x-1/2 -translate-y-1/2 top-2/4 left-1/2">
            <loading-spinner se-class ="w-10 h-10 mr-10 text-gray-400"></loading-spinner>
        </div>
        `;
    }

    disconnectedCallback() {

    }

    #render() {
        return `
            <ma-nav></ma-nav>
            <div class="w-full flex gap-x-10">
                <mark-table class="w-3/4"></mark-table>
                <mark-info class="w-1/4"></mark-info>
            </div>
        `;
    }
}

customElements.define("student-ma", StudentMarkAssessmentComponent);