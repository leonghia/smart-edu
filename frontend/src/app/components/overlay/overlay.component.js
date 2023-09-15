import adminSidebarService from "../dashboard/admin-dashboard/admin-sidebar/admin-sidebar.service.js";

export class OverlayComponent extends HTMLElement {
    #overlayContainer;
    #overlay;
    #overlayWrapper;

    constructor() {
        super();
        this.#overlay = document.querySelector(".se-overlay");
        this.#overlayWrapper = document.querySelector(".se-overlay-wrapper");
        this.#overlayContainer = document.querySelector("app-overlay");
    }

    connectedCallback() {
        adminSidebarService.overlaySidebar();
        this.innerHTML = this._render();
        this.#overlay = document.querySelector(".se-overlay");
        this.#overlayWrapper = document.querySelector(".se-overlay-wrapper");
        const modal = this.getAttribute("modal");
        switch (modal) {
            case "create-student-modal":
                this.#overlayWrapper.innerHTML = `<create-student-modal></create-student-modal>`;
                break;
            case "update-student-modal":
                break;
            case "delete-student-modal":
                this.#overlayWrapper.innerHTML = `<delete-modal se-entity="student"></delete-modal>`;
                break;
        }
        setTimeout(function() {
            this._entering();
        }.bind(this), 100);
    }

    disconnectedCallback() {
        
    }

    _remove() {
        this.#overlayContainer.remove();
    }

    _render() {
        return `
        <div class="relative z-[998]" aria-labelledby="modal-title" role="dialog" aria-modal="true">
            <div class="inset-0 bg-gray-800 dark:bg-gray-600 bg-opacity-75 dark:bg-opacity-75 transition-opacity opacity-0 se-overlay"></div>
            <div class="fixed inset-0 z-10 overflow-y-auto">
                <div class="se-overlay-wrapper flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">

                </div>
            </div>
        </div>
        `;
    }

    _entering() {
        this.#overlay.classList.add("fixed");
        this.#overlay.classList.remove("ease-in", "duration-500");
        this.#overlay.classList.add("ease-out", "duration-700");
        this.#overlay.classList.remove("opacity-0");
        this.#overlay.classList.add("opacity-100");
    }

    _leaving() {
        this.#overlay.classList.remove("ease-out", "duration-700");
        this.#overlay.classList.add("ease-in", "duration-500");
        this.#overlay.classList.remove("opacity-100");
        this.#overlay.classList.add("opacity-0");
        setTimeout(function() {
            this.#overlay.classList.remove("fixed"); 
            adminSidebarService.unOverlaySidebar();
            this._remove();
        }.bind(this), 500);
    }
}

customElements.define("app-overlay", OverlayComponent);