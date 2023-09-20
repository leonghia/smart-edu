export class DeleteModalComponent extends HTMLElement {
    
    #overlayComponent;
    #title;
    #description;
    #cta;
    #modal;
    #unregisterBtn;
    #cancelBtn;

    constructor(overlayComponent, title, description, cta) {
        super();
        this.#overlayComponent = overlayComponent;
        this.#title = title;
        this.#description = description;
        this.#cta = cta;
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#modal = this.firstElementChild;
        this.#unregisterBtn = this.querySelector(".unregister-btn");
        this.#cancelBtn = this.querySelector(".cancel-btn");

        setTimeout(function() {
            this.#entering();
        }.bind(this), 100);

        this.#cancelBtn.addEventListener("click", function () {
            this.#leaving();
            this.#overlayComponent.leaving();
        }.bind(this));

        this.#unregisterBtn.addEventListener("click", function () {
            setTimeout(() => {
                this.#unregisterBtn.innerHTML = "";
                this.#unregisterBtn.textContent = "Unregister";
                this.#unregisterBtn.classList.add("pointer-events-none");
            }, 2000);
            this.#unregisterBtn.textContent = "Unregistering...";
            this.#unregisterBtn.insertAdjacentHTML("afterbegin", `
        <span class="flex items-center">
          <loading-spinner se-class="mr-2 w-4 h-4 text-gray-100"></loading-spinner>
        </span>
            `);
        }.bind(this));
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="ease-out duration-500 opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95 relative transform overflow-hidden rounded-lg bg-white text-left shadow-xl transition-all sm:my-8 sm:w-full sm:max-w-lg">
        <div class="bg-white px-4 pb-4 pt-5 sm:p-6 sm:pb-4">
          <div class="sm:flex sm:items-start">
            <div class="mx-auto flex h-12 w-12 flex-shrink-0 items-center justify-center rounded-full bg-fuchsia-100 sm:mx-0 sm:h-10 sm:w-10">
              <svg class="h-6 w-6 text-fuchsia-600" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                <path stroke-linecap="round" stroke-linejoin="round" d="M12 9v3.75m-9.303 3.376c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126zM12 15.75h.007v.008H12v-.008z" />
              </svg>
            </div>
            <div class="mt-3 text-center sm:ml-4 sm:mt-0 sm:text-left">
              <h3 class="text-base font-semibold leading-6 text-gray-900" id="modal-title">${this.#title}</h3>
              <div class="mt-2">
                <p class="text-sm text-gray-500">${this.#description}</p>
              </div>
            </div>
          </div>
        </div>
        <div class="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse justify-between sm:px-6 items-center">
            
            <div class="sm:flex sm:flex-row-reverse">
                <button type="button" class="unregister-btn inline-flex w-full justify-center items-center rounded-md bg-fuchsia-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-fuchsia-500 sm:ml-3 sm:w-auto">${this.#cta}</button>
                <button type="button" class="cancel-btn mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto">Cancel</button>
            </div>

            <div class="rounded-md">
                <div class="flex">
                    <div class="flex-shrink-0">
                        <svg class="h-5 w-5 text-green-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                        <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" />
                        </svg>
                    </div>
                    <div class="ml-3">
                        <p class="text-sm font-medium text-green-800">Successfully unregistered</p>
                    </div>          
                </div>
            </div>
        </div>
    </div>
        `;
    }

    #entering() {
        this.#modal.classList.remove(..."ease-in duration-300".split(" "));
        this.#modal.classList.add(..."ease-out duration-500".split(" "));
        this.#modal.classList.remove(..."opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95".split(" "));
        this.#modal.classList.add(..."opacity-100 translate-y-0 sm:scale-100".split(" "));
    }

    #leaving() {
        this.#modal.classList.remove(..."ease-out duration-500".split(" "));
        this.#modal.classList.add(..."ease-in duration-300".split(" "));
        this.#modal.classList.remove(..."opacity-100 translate-y-0 sm:scale-100".split(" "));
        this.#modal.classList.add(..."opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95".split(" "));
        setTimeout(function () {
            this.remove();
        }.bind(this), 300);
    }
}

customElements.define("delete-modal", DeleteModalComponent);