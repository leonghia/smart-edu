import adminSidebarService from "../dashboard/admin-dashboard/admin-sidebar/admin-sidebar.service.js";

export class OverlayComponent extends HTMLElement {

    #overlay

    constructor() {
        super();
    }

    connectedCallback() {
        adminSidebarService.overlaySidebar();
        this.innerHTML = this.#render();
        this.#overlay = document.querySelector(".se-overlay");
        this.#overlay.classList.add("fixed");
        this.#overlay.classList.remove("ease-in", "duration-500");
        this.#overlay.classList.add("ease-out", "duration-700");
        this.#overlay.classList.remove("opacity-0");
        this.#overlay.classList.add("opacity-100");
    }

    disconnectedCallback() {
        this.#overlay.classList.remove("ease-out", "duration-700");
        this.#overlay.classList.add("ease-in", "duration-[5000ms]");
        this.#overlay.classList.remove("opacity-100");
        this.#overlay.classList.add("opacity-0");
        setTimeout(function() {
            this.#overlay.classList.remove("fixed");  
        }.bind(this), 500);
        setTimeout(function() {
            adminSidebarService.unOverlaySidebar();
        }, 500);
    }

    #render() {
        return `<div class="inset-0 bg-gray-800 bg-opacity-80 transition-opacity ease-out duration-700 opacity-0 se-overlay"></div>`;
    }
}

customElements.define("app-overlay", OverlayComponent);