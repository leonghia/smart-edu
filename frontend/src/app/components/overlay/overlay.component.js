import { data, state } from "../../app.store.js";
import adminSidebarService from "../dashboard/admin-dashboard/admin-sidebar/admin-sidebar.service.js";

export class OverlayComponent extends HTMLElement {
    #overlayContainer;
    #overlay;
    overlayWrapper;

    constructor() {
        super();
        this.#overlay = document.querySelector(".se-overlay");
        this.overlayWrapper = document.querySelector(".overlay-wrapper");
        this.#overlayContainer = document.querySelector("app-overlay");
    }

    connectedCallback() {
        if (state.userType === 0) {
            adminSidebarService.overlaySidebar();
        }
        this.innerHTML = this._render();
        this.#overlay = document.querySelector(".se-overlay");
        this.overlayWrapper = document.querySelector(".overlay-wrapper");
        const modal = this.getAttribute("modal");
        const classes = this.getAttribute("se-class");

        if (classes) {
            this.firstElementChild.firstElementChild.classList.remove(..."bg-gray-800 dark:bg-gray-600 bg-opacity-75 dark:bg-opacity-75".split(" "));
            this.firstElementChild.firstElementChild.classList.add(...classes.split(" "));
        }
        
        setTimeout(function () {
            this.#entering();
        }.bind(this), 100);
    }

    disconnectedCallback() {

    }

    _render() {
        return `
        <div class="relative z-[998]" aria-labelledby="modal-title" role="dialog" aria-modal="true">
            <div class="inset-0 bg-gray-800 dark:bg-gray-600 bg-opacity-75 dark:bg-opacity-75 transition-opacity opacity-0 se-overlay"></div>
            <div class="fixed inset-0 z-10 overflow-y-auto">
                <div class="overlay-wrapper flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">

                </div>
            </div>
        </div>
        `;
    }

    #entering() {
        this.#overlay.classList.add("fixed");
        this.#overlay.classList.remove("ease-in", "duration-300");
        this.#overlay.classList.add("ease-out", "duration-500");
        this.#overlay.classList.remove("opacity-0");
        this.#overlay.classList.add("opacity-100");
    }

    leaving() {
        this.#overlay.classList.remove("ease-out", "duration-500");
        this.#overlay.classList.add("ease-in", "duration-300");
        this.#overlay.classList.remove("opacity-100");
        this.#overlay.classList.add("opacity-0");
        setTimeout(function () {
            this.#overlay.classList.remove("fixed");
            if (data.currentUser.type === 0) {
                adminSidebarService.unOverlaySidebar();
            }
            this.remove();
        }.bind(this), 500);
    }
}

customElements.define("app-overlay", OverlayComponent);