export class AdminMainComponent extends HTMLElement {
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
        <div class="xl:pl-72 se-right-container h-full">
            <search-bar></search-bar>
            <main class="" style="height: calc(100% - 5rem);">
                <students-mgt></students-mgt>
            </main>
        </div>
        `;
    }

    
}

customElements.define("admin-main", AdminMainComponent);