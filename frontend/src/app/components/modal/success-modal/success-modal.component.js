import { OverlayComponent } from "../../overlay/overlay.component";

export class SuccessModalComponent extends HTMLElement {

    #title;
    #message;
    #goBackBtn;
    #overlayComponent;
    constructor(title, message, overlayComponent) {
        super();
        this.#title = title;
        this.#message = message;
        this.#overlayComponent = overlayComponent;
    }

    connectedCallback() {
        this.innerHTML = this.#render();

        this.#goBackBtn = document.querySelector(".go-back-btn");

        this.#goBackBtn.addEventListener("click", function () { 
            this.leaving();
            this.#overlayComponent.leaving();
        }.bind(this));
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="ease-out duration-300 opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95 relative transform overflow-hidden rounded-lg bg-white px-4 pb-4 pt-5 text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-md sm:p-6">
        <div>
          <div class="mx-auto flex h-12 w-12 items-center justify-center rounded-full bg-green-100">
            <svg class="h-6 w-6 text-green-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
              <path stroke-linecap="round" stroke-linejoin="round" d="M4.5 12.75l6 6 9-13.5" />
            </svg>
          </div>
          <div class="mt-3 text-center sm:mt-5">
            <h3 class="text-base font-semibold leading-6 text-gray-900" id="modal-title">${this.#title}</h3>
            <div class="mt-2">
              <p class="text-sm text-gray-500">${this.#message}</p>
            </div>
          </div>
        </div>
        <div class="mt-5 sm:mt-6">
          <button type="button" class="go-back-btn inline-flex w-full justify-center rounded-md bg-fuchsia-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-fuchsia-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-fuchsia-600">Go back to dashboard</button>
        </div>
    </div>
        `;
    }

    entering() {
        this.firstElementChild.classList.remove(..."ease-in duration-300".split(" "));
        this.firstElementChild.classList.add(..."ease-out duration-500".split(" "));
        this.firstElementChild.classList.remove(..."opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95".split(" "));
        this.firstElementChild.classList.add(..."opacity-100 translate-y-0 sm:scale-100".split(" "));

    }

    leaving() {
        this.firstElementChild.classList.remove(..."ease-out duration-500".split(" "));
        this.firstElementChild.classList.add(..."ease-in duration-300".split(" "));
        this.firstElementChild.classList.remove(..."opacity-100 translate-y-0 sm:scale-100".split(" "));
        this.firstElementChild.classList.add(..."opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95".split(" "));

    }
}

customElements.define("success-modal", SuccessModalComponent);