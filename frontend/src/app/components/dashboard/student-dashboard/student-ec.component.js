export class StudentExtraClassComponent extends HTMLElement {
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
        <student-ec-stat></student-ec-stat>
        <student-ec-new></student-ec-new>
        `;
    }

}

customElements.define("student-ec", StudentExtraClassComponent);

