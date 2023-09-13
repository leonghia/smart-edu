import { OverlayComponent } from "../../overlay/overlay.component";
import Datepicker from "flowbite-datepicker/js/Datepicker";
import { showDropdown, hideDropdown } from "../../../helpers/animation.helper";
import { displayMainClassFilterDropdown, getTotalStudents } from "../../../helpers/filter.helper";

export class CreateStudentModalComponent extends HTMLElement {
    #modal;
    #closeModalBtn;
    #datepickerEl;
    #datepickerDropdown;
    #addStudentMainClassInput;
    #addStudentMainClassDropdown;
    #addStudentMainClassDropdownContainer;
    #addStudentMainClassDropdownState = {
        state: false,
    };
    #timesDatepickerClicked = 0;

    constructor() {
        super();
        
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#modal = document.querySelector(".se-modal");
        this.#closeModalBtn = document.querySelector(".se-close-modal-btn");
        this.#datepickerEl = document.querySelector("#se_datepicker");
        this.#addStudentMainClassInput = document.querySelector("#add_student_class");
        this.#addStudentMainClassDropdown = document.querySelector("#add_student_main_class_dropdown");
        this.#addStudentMainClassDropdownContainer = document.querySelector("#add_student_main_class_dropdown_container");

        new Datepicker(this.#datepickerEl, {
            format: "dd/mm/yyyy",
        });

        this.#addStudentMainClassInput.addEventListener("click", function(event) {
            if (this.#addStudentMainClassDropdownState.state) {
                hideDropdown(this.#addStudentMainClassDropdown, [], this.#addStudentMainClassDropdownState);
                return;
            }
            showDropdown(this.#addStudentMainClassDropdown, [], this.#addStudentMainClassDropdownState);
        }.bind(this));

        this.#datepickerEl.addEventListener("click", function() {         
            this.#datepickerDropdown = Array.from(document.querySelectorAll(".datepicker-dropdown")).at(-1);
            const fixedTop =  +this.#datepickerDropdown.style.top.slice(0, -2);
            if (this.#timesDatepickerClicked === 0) {
                this.#datepickerDropdown.style.top = fixedTop - 10 + "px";
                this.#timesDatepickerClicked++;
            } else {
                return;  
            }
        }.bind(this));

        this.#closeModalBtn.addEventListener("click", function() {
            this._leaving();
            const overlayComponent = new OverlayComponent();
            overlayComponent._leaving();
        }.bind(this));

        setTimeout(function() {
            this._entering();
        }.bind(this), 100);

        displayMainClassFilterDropdown(this.#addStudentMainClassDropdownContainer);
    }

    disconnectedCallback() {
        
    }

    #render() {
        return `     
        <div class="se-modal relative transform overflow-hidden rounded-lg bg-white dark:bg-gray-800 px-4 pb-4 pt-5 text-left shadow-xl transition-all opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95 sm:my-8 sm:w-[42rem] sm:max-w-2xl sm:p-6">
            <div class="relative bg-white dark:bg-gray-800">
                <!-- Modal header -->
                <div class="flex justify-between items-center pb-4 mb-4 rounded-t border-b sm:mb-5 dark:border-gray-600">
                    <h3 class="text-lg font-semibold text-fuchsia-500 dark:text-fuchsia-400">
                        Add New Student
                    </h3>
                    <button type="button"
                        class="se-close-modal-btn text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm p-1.5 ml-auto inline-flex items-center dark:hover:bg-gray-600 dark:hover:text-white"
                        data-modal-toggle="updateProductModal">
                        <svg aria-hidden="true" class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20"
                            xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd"
                                d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                                clip-rule="evenodd"></path>
                        </svg>
                        <span class="sr-only">Close modal</span>
                    </button>
                </div>
                <!-- Modal body -->
                <form action="#">
                    <div class="grid gap-4 mb-5 sm:grid-cols-2">
                        <div>
                            <label for="add-student-name"
                                class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Full Name</label>
                            <input type="text" name="add-student-name" id="add_student_name" value=""
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-600 focus:border-fuchsia-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500"
                                placeholder="Ex. Trinh Dinh Quoc">
                        </div>
                        <div>
                            <label for="add-student-email"
                                class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email</label>
                            <input type="email" name="add-student-email" id="add_student_email" value=""
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-600 focus:border-fuchsia-600 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500"
                                placeholder="Ex. draogon10a3@gmail.com">
                        </div>
                        <div>
                            <label for="price"
                                class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Date of birth
                            </label>                          
                            <div class="relative max-w-sm">
                                <div class="absolute inset-y-0 left-0 flex items-center pl-3.5 pointer-events-none">
                                    <svg class="w-4 h-4 text-gray-500 dark:text-gray-400" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                                        <path d="M20 4a2 2 0 0 0-2-2h-2V1a1 1 0 0 0-2 0v1h-3V1a1 1 0 0 0-2 0v1H6V1a1 1 0 0 0-2 0v1H2a2 2 0 0 0-2 2v2h20V4ZM0 18a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V8H0v10Zm5-8h10a1 1 0 0 1 0 2H5a1 1 0 0 1 0-2Z"/>
                                    </svg>
                                </div>
                                <input id="se_datepicker" datepicker type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-500 focus:border-fuchsia-500 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500" placeholder="Select date">
                            </div>
                        </div>
                        <div class="relative">
                            <label for="add_student_class"
                                class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Main class</label>
                            <input id="add_student_class" type="text"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-500 focus:border-fuchsia-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500" placeholder="Select class">
                            <div id="add_student_main_class_dropdown"
                                class="transform opacity-0 scale-95 transition ease-out duration-700 absolute left-0 z-10 mt-2 w-52 origin-top-right rounded-lg bg-white dark:bg-gray-900 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                                role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                                <div class="w-56 p-3" role="none">
                                    
                                    <ul id="add_student_main_class_dropdown_container" class="-mb-3 space-y-2 text-sm max-h-44 overflow-scroll mr-1 pl-1 pt-1" aria-labelledby="dropdownDefault">
                                                                                        
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="sm:col-span-2">
                            <label for="description"
                                class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Description</label>
                            <textarea id="description" rows="5"
                                class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 focus:ring-fuchsia-500 focus:border-fuchsia-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500"
                                placeholder="Write a description...">Standard glass, 3.8GHz 8-core 10th-generation Intel Core i7 processor, Turbo Boost up to 5.0GHz, 16GB 2666MHz DDR4 memory, Radeon Pro 5500 XT with 8GB of GDDR6 memory, 256GB SSD storage, Gigabit Ethernet, Magic Mouse 2, Magic Keyboard - US</textarea>
                        </div>
                    </div>
                    <div class="flex items-center space-x-4">
                        <button type="button"
                            class="text-white bg-fuchsia-600 hover:bg-fuchsia-700 focus:ring-4 focus:outline-none focus:ring-fuchsia-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-fuchsia-600 dark:hover:bg-fuchsia-700 dark:focus:ring-fuchsia-800">
                            Add student
                        </button>       
                    </div>
                </form>
            </div>
        </div>
        `;
    }

    _entering() {
        this.#modal.classList.remove(..."ease-in duration-500".split(" "));
        this.#modal.classList.add(..."ease-out duration-700".split(" "));
        this.#modal.classList.remove(..."opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95".split(" "));
        this.#modal.classList.add(..."opacity-100 translate-y-0 sm:scale-100".split(" "));
    }

    _leaving() {
        this.#modal.classList.remove(..."ease-out duration-700".split(" "));
        this.#modal.classList.add(..."ease-in duration-500".split(" "));
        this.#modal.classList.remove(..."opacity-100 translate-y-0 sm:scale-100".split(" "));
        this.#modal.classList.add(..."opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95".split(" "));
    }
}

customElements.define("create-student-modal", CreateStudentModalComponent);