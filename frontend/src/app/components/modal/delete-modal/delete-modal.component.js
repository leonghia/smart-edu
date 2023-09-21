import { data } from "../../../app.store";
import dataService from "../../../services/data.service";
import { SuccessAlertComponent } from "../../alert/success-alert.component";
import studentEcService from "../../dashboard/student-dashboard/student-ec/student-ec.service";

export class DeleteModalComponent extends HTMLElement {

    _option = {
        overlay: undefined,
        title: undefined,
        description: undefined,
        cta: undefined,
        url: undefined,
        deleteDataDTO: undefined
    }

    #modal;
    _proceedBtn;
    #cancelBtn;
    

    constructor(option) {
        super();
        this._option = option;
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#modal = this.firstElementChild;
        this._proceedBtn = this.querySelector(".proceed-btn");
        this.#cancelBtn = this.querySelector(".cancel-btn");
        

        setTimeout(function () {
            this.#entering();
        }.bind(this), 100);

        this.#cancelBtn.addEventListener("click", function () {
            this.#leaving();
            this._option.overlay.leaving();
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
                <h3 class="text-base font-semibold leading-6 text-gray-900" id="modal-title">${this._option.title}</h3>
                <div class="mt-2">
                    <p class="text-sm text-gray-500">${this._option.description}</p>
                </div>
                <div class="mt-3">
                    <label for="reason" class="block text-sm font-medium leading-6 text-gray-900">Input your reason</label>
                    <div class="mt-2 relative">
                        <textarea rows="3" name="reason" id="reason" class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-fuchsia-600 sm:text-sm sm:leading-6" placeholder="Tell us why do you unregister?"></textarea>
                        <div class="invisible pointer-events-none absolute top-2 right-0 flex items-center pr-3">
                            <svg class="h-5 w-5 text-red-500" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-8-5a.75.75 0 01.75.75v4.5a.75.75 0 01-1.5 0v-4.5A.75.75 0 0110 5zm0 10a1 1 0 100-2 1 1 0 000 2z" clip-rule="evenodd" />
                            </svg>
                        </div>
                    </div>
                    <p class="hidden mt-2 text-sm text-red-600" id="input_error_message"></p>
                </div>
            </div>
          </div>
        </div>
        <div class="bg-gray-50 px-4 py-3 sm:flex sm:flex-row-reverse justify-between sm:px-6 items-center">
            
            <div class="sm:flex sm:flex-row-reverse">
                <button type="button" class="proceed-btn inline-flex w-full justify-center items-center rounded-md bg-fuchsia-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-fuchsia-500 sm:ml-3 sm:w-auto">${this._option.cta}</button>
                <button type="button" class="cancel-btn mt-3 inline-flex w-full justify-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50 sm:mt-0 sm:w-auto">Cancel</button>
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