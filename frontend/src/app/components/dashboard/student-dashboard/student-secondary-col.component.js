export class StudentSecondaryColumnComponent extends HTMLElement {
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
        <aside class="fixed bottom-0 left-20 top-16 hidden w-96 overflow-y-auto px-4 py-6 sm:px-6 lg:px-8 xl:block">
        <!-- Secondary column (hidden on smaller screens) -->
            <student-ec-stat></student-ec-stat>
        </aside>
        `;
    }
}

customElements.define("student-secondary-col", StudentSecondaryColumnComponent);