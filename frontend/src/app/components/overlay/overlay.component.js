import adminSidebarService from "../dashboard/admin-dashboard/admin-sidebar/admin-sidebar.service.js";

export class OverlayComponent extends HTMLElement {

    #overlay;
    _overlayWrapper;
    constructor() {
        super();
    }

    connectedCallback() {
        adminSidebarService.overlaySidebar();
        this.innerHTML = this._render();
        // this.#overlayWrapper = document.querySelector(".se-overlay-wrapper");
        // this.#overlayWrapper.innerHTML = `<create-student-modal></create-student-modal>`;
        this._overlayWrapper = document.querySelector(".se-overlay-wrapper");
        const modal = this.getAttribute("modal");
        console.log(modal);
    }

    disconnectedCallback() {
        
    }

    _render() {
        return `
        <div class="relative z-[998]" aria-labelledby="modal-title" role="dialog" aria-modal="true">
            <div class="inset-0 bg-gray-800 bg-opacity-80 transition-opacity ease-out duration-700 opacity-0 se-overlay"></div>
            <div class="fixed inset-0 z-10 overflow-y-auto">
                <div class="se-overlay-wrapper flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">

                <div>
            <div>
        </div>
        `;
    }

    _entering() {
        this.#overlay = document.querySelector(".se-overlay");
        this._overlayWrapper = document.querySelector(".se-overlay-wrapper");
        this.#overlay.classList.add("fixed");
        this.#overlay.classList.remove("ease-in", "duration-500");
        this.#overlay.classList.add("ease-out", "duration-700");
        this.#overlay.classList.remove("opacity-0");
        this.#overlay.classList.add("opacity-100");
    }

    _leaving() {
        this.#overlay = document.querySelector(".se-overlay");
        this._overlayWrapper = document.querySelector(".se-overlay-wrapper");
        this.#overlay.classList.remove("ease-out", "duration-700");
        this.#overlay.classList.add("ease-in", "duration-500");
        this.#overlay.classList.remove("opacity-100");
        this.#overlay.classList.add("opacity-0");
        setTimeout(function() {
            this.#overlay.classList.remove("fixed");  
        }.bind(this), 500);
        setTimeout(function() {
            adminSidebarService.unOverlaySidebar();
        }, 500);
    }
}

customElements.define("app-overlay", OverlayComponent);