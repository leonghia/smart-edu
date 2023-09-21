import { DeleteModalComponent } from "../../../modal/delete-modal/delete-modal.component";
import dataService from "../../../../services/data.service";
import { data } from "../../../../app.store";
import { SuccessAlertComponent } from "../../../alert/success-alert.component";
import studentEcService from "./student-ec.service";

export class UnregisterExtraClassModalComponent extends DeleteModalComponent {

    #reasonInput;
    #inputErrorMessage;

    constructor(option) {
        super(option);
    }

    connectedCallback() {
        super.connectedCallback();
        this.#reasonInput = this.querySelector("#reason");
        this.#inputErrorMessage = this.querySelector("#input_error_message");

        this.#reasonInput.addEventListener("input", function () {
            this.#inputErrorMessage.classList.add("hidden");
            this.#reasonInput.classList.remove(..."ring-red-300".split(" "));
            this.#reasonInput.nextElementSibling.classList.add("invisible");
        }.bind(this));

        this._proceedBtn.addEventListener("click", function () {
            if (this.#reasonInput.value.trim() === "" || this.#reasonInput.value.trim().length < 20) {
                this.#reasonInput.classList.add(..."ring-red-300".split(" "));
                this.#reasonInput.nextElementSibling.classList.remove("invisible");
                if (this.#reasonInput.value.trim() === "") {
                    this.#inputErrorMessage.textContent = "This field is required.";
                } else {
                    this.#inputErrorMessage.textContent = "This field needs to be at least 20 characters.";
                }
                this.#inputErrorMessage.classList.remove("hidden");
                return;
            }
            setTimeout(() => {
                dataService.unregisterExtraClass(this._option.deleteDataDTO)
                    .then(res => {
                        this._proceedBtn.innerHTML = "";
                        this._proceedBtn.textContent = `${this._option.cta}`;
                        if (res.succeeded) {
                            this._proceedBtn.classList.add("pointer-events-none");
                            this._proceedBtn.classList.add("bg-gray-400");
                            const successAlert = new SuccessAlertComponent("unregistered");
                            this._proceedBtn.parentElement.after(successAlert);

                            // Trigger the ec-list component
                            dataService.getStudent(data.currentUser.student.id)
                                .then(res => {
                                    data.currentUser.student = res.data;
                                    studentEcService.trigger("refreshEcListReg", data.currentUser.student.extraClasses);              
                                });

                            // Trigger the ec-grid component
                            dataService.getExtraClasses()
                                .then(res => {
                                    data.extraClasses = res.data;
                                    studentEcService.trigger("refreshEcGrid", data.extraClasses);
                                });

                        }
                    });

            }, 500);
            this._proceedBtn.textContent = `${this._option.cta}...`;
            this._proceedBtn.insertAdjacentHTML("afterbegin", `
        <span class="flex items-center">
          <loading-spinner se-class="mr-2 w-4 h-4 text-gray-100"></loading-spinner>
        </span>
            `);
        }.bind(this));
    }

    disconnectedCallback() {
        super.disconnectedCallback();
    }

}

customElements.define("unregister-ec-modal", UnregisterExtraClassModalComponent);