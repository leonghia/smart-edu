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
        <div class="w-full flex items-center justify-between gap-10 h-full">
          <student-ec-grid class="w-3/4 h-full"></student-ec-grid>
          
        </div>
        `;
    }
}

customElements.define("student-ec", StudentExtraClassComponent);

