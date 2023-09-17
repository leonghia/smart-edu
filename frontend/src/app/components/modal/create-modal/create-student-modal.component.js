import { OverlayComponent } from "../../overlay/overlay.component";
import Datepicker from "flowbite-datepicker/js/Datepicker";
import { showDropdown, hideDropdown } from "../../../helpers/animation.helper";
import { displayMainClassFilterDropdown, getTotalStudents } from "../../../helpers/filter.helper";
import { state } from "../../../app.store";

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
    
    #addMoreStudentCount = 0;
    #addMoreStudentBtn;
    #saveAddStudentBtn

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
        this.#addMoreStudentBtn = document.querySelector(".add-more-student-btn");
        this.#saveAddStudentBtn = document.querySelector("#save_add_student_btn");

        if (state.darkMode) {
            this.#addStudentMainClassDropdownContainer.classList.remove("light-scrollbar");
            this.#addStudentMainClassDropdownContainer.classList.add("dark-scrollbar");
        } else {
            this.#addStudentMainClassDropdownContainer.classList.remove("dark-scrollbar");
            this.#addStudentMainClassDropdownContainer.classList.add("light-scrollbar");
        }

        new Datepicker(this.#datepickerEl, {
            format: "dd/mm/yyyy",
        });

        this.#saveAddStudentBtn.addEventListener("click", function() {
            const forms = Array.from(document.querySelectorAll(".add-student-form"));
            const registerUserDTOs = [];
            forms.forEach(f => {
                const inputs = Array.from(f.querySelectorAll("input"));
                registerUserDTOs.push({
                    fullName: inputs[0].value,
                    email: inputs[1].value,
                    dateOfBirth: inputs[2].value,
                    mainClassId: Number(inputs[3].id)
                });
            });
            console.log(registerUserDTOs);
        }.bind(this));

        this.#addStudentMainClassDropdownContainer.addEventListener("click", function (event) {
            const clicked = event.target.closest("input");
            if (!clicked) {
                return;
            }
            this.#addStudentMainClassInput.value = "Class " + clicked.value;
            this.#addStudentMainClassInput.setAttribute("main-class-id", clicked.getAttribute("id"));
            hideDropdown(this.#addStudentMainClassDropdown, [], this.#addStudentMainClassDropdownState);
            return;
        }.bind(this));

        this.#addStudentMainClassInput.addEventListener("click", function (event) {
            if (this.#addStudentMainClassDropdownState.state) {
                hideDropdown(this.#addStudentMainClassDropdown, [], this.#addStudentMainClassDropdownState);
                return;
            }
            showDropdown(this.#addStudentMainClassDropdown, [], this.#addStudentMainClassDropdownState);
        }.bind(this));


        this.#closeModalBtn.addEventListener("click", function () {
            this._leaving();
            const overlayComponent = new OverlayComponent();
            overlayComponent.leaving();
        }.bind(this));

        setTimeout(function () {
            this._entering();
        }.bind(this), 100);

        displayMainClassFilterDropdown(this.#addStudentMainClassDropdownContainer);

        this.#addMoreStudentBtn.addEventListener("click", function(event) {
            event.preventDefault();
            if (document.querySelectorAll(".add-student-form").length === 1) {
                this.#addMoreStudentCount = 0;
            }
            this.#addMoreStudentCount++;
            document.querySelector(".add-student-form-container").insertAdjacentHTML("beforeend", `
        <form action="#" class="mt-8 add-student-form">
            <div class="mb-5">
                <div class="flex items-center gap-4">
                    <div>
                        <h5 class="mb-2 font-medium leading-none tracking-tight text-gray-900 dark:text-white"><span class="underline underline-offset-4 decoration-4 decoration-fuchsia-500 dark:decoration-fuchsia-500">Student #${this.#addMoreStudentCount + 1}</span></h5>            
                    </div>
                    
                </div>           
            </div>
            <div class="grid gap-4 mb-5 sm:grid-cols-2">
                <div>
                    <label for="add-student-name-${this.#addMoreStudentCount}"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Full Name
                    </label>
                    <div class="relative max-w-sm">
                        <div class="absolute inset-y-0 left-0 flex items-center pl-3.5 pointer-events-none">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-4 h-4 text-gray-500 dark:text-gray-400">
                                <path fill-rule="evenodd" d="M7.5 6a4.5 4.5 0 119 0 4.5 4.5 0 01-9 0zM3.751 20.105a8.25 8.25 0 0116.498 0 .75.75 0 01-.437.695A18.683 18.683 0 0112 22.5c-2.786 0-5.433-.608-7.812-1.7a.75.75 0 01-.437-.695z" clip-rule="evenodd" />
                            </svg>                                                                               
                        </div>
                        <input type="text" name="add-student-name-${this.#addMoreStudentCount}" id="add_student_name_${this.#addMoreStudentCount}" value=""
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-600 focus:border-fuchsia-600 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500"
                        placeholder="Ex. Trinh Dinh Quoc">
                    </div>
                </div>
                <div>
                    <label for="add-student-email-${this.#addMoreStudentCount}"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email
                    </label>
                    <div class="relative max-w-sm">
                        <div class="absolute inset-y-0 left-0 flex items-center pl-3.5 pointer-events-none">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-4 h-4 text-gray-500 dark:text-gray-400">
                                <path d="M1.5 8.67v8.58a3 3 0 003 3h15a3 3 0 003-3V8.67l-8.928 5.493a3 3 0 01-3.144 0L1.5 8.67z" />
                                <path d="M22.5 6.908V6.75a3 3 0 00-3-3h-15a3 3 0 00-3 3v.158l9.714 5.978a1.5 1.5 0 001.572 0L22.5 6.908z" />
                            </svg>                                                   
                        </div>
                        <input type="email" name="add-student-email-${this.#addMoreStudentCount}" id="add_student_email_${this.#addMoreStudentCount}" value=""
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-600 focus:border-fuchsia-600 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500"
                        placeholder="Ex. draogon10a3@gmail.com">
                    </div>
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
                        <input id="se_datepicker_${this.#addMoreStudentCount}" datepicker type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-500 focus:border-fuchsia-500 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500" placeholder="Select date">
                    </div>
                </div>
                <div class="relative">
                    <label for="add_student_class"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Main class
                    </label>
                    <div id="add_student_main_class_dropdown_${this.#addMoreStudentCount}"
                        class="transform opacity-0 scale-95 transition ease-out duration-700 absolute bottom-12 left-0 z-10 mt-2 w-52 origin-top-right rounded-lg bg-white dark:bg-gray-700 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none pointer-events-none"
                        role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                        <div class="w-56 p-3" role="none">
                            
                            <ul id="add_student_main_class_dropdown_container_${this.#addMoreStudentCount}" class="light-scrollbar -mb-3 space-y-2 text-sm max-h-44 overflow-scroll mr-1 pl-1 pt-1" aria-labelledby="dropdownDefault">
                                                                                
                            </ul>
                        </div>
                    </div>
                    <div class="relative max-w-sm">
                        <div class="absolute inset-y-0 left-0 flex items-center pl-3.5 pointer-events-none">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-gray-500 dark:text-gray-400">
                                <path fill-rule="evenodd" d="M3 6a3 3 0 013-3h12a3 3 0 013 3v12a3 3 0 01-3 3H6a3 3 0 01-3-3V6zm4.5 7.5a.75.75 0 01.75.75v2.25a.75.75 0 01-1.5 0v-2.25a.75.75 0 01.75-.75zm3.75-1.5a.75.75 0 00-1.5 0v4.5a.75.75 0 001.5 0V12zm2.25-3a.75.75 0 01.75.75v6.75a.75.75 0 01-1.5 0V9.75A.75.75 0 0113.5 9zm3.75-1.5a.75.75 0 00-1.5 0v9a.75.75 0 001.5 0v-9z" clip-rule="evenodd" />
                            </svg>                              
                        </div>
                        <input id="add_student_class_${this.#addMoreStudentCount}" type="text"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-500 focus:border-fuchsia-500 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500" placeholder="Select class">
                    </div>
                    
                </div>                       
            </div>
                        
        </form>
            `);
            new Datepicker(document.querySelector(`#se_datepicker_${this.#addMoreStudentCount}`), {
                format: "dd/mm/yyyy",
            });
            displayMainClassFilterDropdown(document.querySelector(`#add_student_main_class_dropdown_container_${this.#addMoreStudentCount}`));

            document.querySelector(`#add_student_main_class_dropdown_container_${this.#addMoreStudentCount}`).addEventListener("click", function (event) {
                const clicked = event.target.closest("input");
                if (!clicked) {
                    return;
                }
                document.querySelector(`#add_student_class_${this.#addMoreStudentCount}`).value = "Class " + clicked.value;
                document.querySelector(`#add_student_class_${this.#addMoreStudentCount}`).setAttribute("main-class-id", clicked.getAttribute("id"));
                hideDropdown(document.querySelector(`#add_student_main_class_dropdown_${this.#addMoreStudentCount}`), [], this.#addStudentMainClassDropdownState);
                return;
            }.bind(this));
    
            document.querySelector(`#add_student_class_${this.#addMoreStudentCount}`).addEventListener("click", function (event) {
                if (this.#addStudentMainClassDropdownState.state) {
                    hideDropdown(document.querySelector(`#add_student_main_class_dropdown_${this.#addMoreStudentCount}`), [], this.#addStudentMainClassDropdownState);
                    return;
                }
                showDropdown(document.querySelector(`#add_student_main_class_dropdown_${this.#addMoreStudentCount}`), [], this.#addStudentMainClassDropdownState);
            }.bind(this));

            const clearAddStudentBtnMarkup = `
                <div class="clear-add-student-btn">
                    <p class="text-gray-500 dark:text-gray-400 text-sm"> 
                        <a href="#" id="clear_add_student_form_${this.#addMoreStudentCount}" class="inline-flex items-center font-medium text-red-500 dark:text-red-500">
                        Clear
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-4 h-4 ml-1">
                                <path fill-rule="evenodd" d="M16.5 4.478v.227a48.816 48.816 0 013.878.512.75.75 0 11-.256 1.478l-.209-.035-1.005 13.07a3 3 0 01-2.991 2.77H8.084a3 3 0 01-2.991-2.77L4.087 6.66l-.209.035a.75.75 0 01-.256-1.478A48.567 48.567 0 017.5 4.705v-.227c0-1.564 1.213-2.9 2.816-2.951a52.662 52.662 0 013.369 0c1.603.051 2.815 1.387 2.815 2.951zm-6.136-1.452a51.196 51.196 0 013.273 0C14.39 3.05 15 3.684 15 4.478v.113a49.488 49.488 0 00-6 0v-.113c0-.794.609-1.428 1.364-1.452zm-.355 5.945a.75.75 0 10-1.5.058l.347 9a.75.75 0 101.499-.058l-.346-9zm5.48.058a.75.75 0 10-1.498-.058l-.347 9a.75.75 0 001.5.058l.345-9z" clip-rule="evenodd" />
                            </svg>                          
                        </a>
                    </p>
                </div>
            `;

            document.querySelector(`#add_student_name_${this.#addMoreStudentCount}`).closest("form").firstElementChild.firstElementChild.insertAdjacentHTML("beforeend", clearAddStudentBtnMarkup);

            document.querySelector(`#clear_add_student_form_${this.#addMoreStudentCount}`).addEventListener("click", function(event) {
                event.target.closest("form").remove();
            });
        }.bind(this));
    }

    disconnectedCallback() {

    }

    #render() {
        return `     
        <div class="se-modal relative transform rounded-lg bg-white dark:bg-gray-800 px-4 pb-4 pt-5 text-left shadow-xl transition-all opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95 sm:my-8 sm:w-[42rem] sm:max-w-2xl sm:p-6 max-h-[500px] overflow-scroll">
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
                <div class="add-student-form-container">
                    <form action="#" class="add-student-form">
                        <div class="mb-5">
                            <h5 class="font-medium leading-none tracking-tight text-gray-900 dark:text-white"><span class="underline underline-offset-4 decoration-4 decoration-fuchsia-500 dark:decoration-fuchsia-500">Student #1</span></h5>
                        </div>
                        <div class="grid gap-4 mb-5 sm:grid-cols-2">
                            <div>
                                <label for="add-student-name"
                                    class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Full Name
                                </label>
                                <div class="relative max-w-sm">
                                    <div class="absolute inset-y-0 left-0 flex items-center pl-3.5 pointer-events-none">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-4 h-4 text-gray-500 dark:text-gray-400">
                                            <path fill-rule="evenodd" d="M7.5 6a4.5 4.5 0 119 0 4.5 4.5 0 01-9 0zM3.751 20.105a8.25 8.25 0 0116.498 0 .75.75 0 01-.437.695A18.683 18.683 0 0112 22.5c-2.786 0-5.433-.608-7.812-1.7a.75.75 0 01-.437-.695z" clip-rule="evenodd" />
                                        </svg>                                                                               
                                    </div>
                                    <input type="text" name="add-student-name" id="add_student_name" value=""
                                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-600 focus:border-fuchsia-600 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500"
                                    placeholder="Ex. Trinh Dinh Quoc">
                                </div>
                            </div>
                            <div>
                                <label for="add-student-email"
                                    class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email
                                </label>
                                <div class="relative max-w-sm">
                                    <div class="absolute inset-y-0 left-0 flex items-center pl-3.5 pointer-events-none">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-4 h-4 text-gray-500 dark:text-gray-400">
                                            <path d="M1.5 8.67v8.58a3 3 0 003 3h15a3 3 0 003-3V8.67l-8.928 5.493a3 3 0 01-3.144 0L1.5 8.67z" />
                                            <path d="M22.5 6.908V6.75a3 3 0 00-3-3h-15a3 3 0 00-3 3v.158l9.714 5.978a1.5 1.5 0 001.572 0L22.5 6.908z" />
                                        </svg>                                                   
                                    </div>
                                    <input type="email" name="add-student-email" id="add_student_email" value=""
                                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-600 focus:border-fuchsia-600 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500"
                                    placeholder="Ex. draogon10a3@gmail.com">
                                </div>
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
                                    class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Main class
                                </label>
                                <div id="add_student_main_class_dropdown"
                                    class="transform opacity-0 scale-95 transition ease-out duration-700 absolute bottom-12 left-0 z-10 mt-2 w-52 origin-top-right rounded-lg bg-white dark:bg-gray-700 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none pointer-events-none"
                                    role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                                    <div class="w-56 p-3" role="none">
                                        
                                        <ul id="add_student_main_class_dropdown_container" class="light-scrollbar -mb-3 space-y-2 text-sm max-h-44 overflow-scroll mr-1 pl-1 pt-1" aria-labelledby="dropdownDefault">
                                                                                            
                                        </ul>
                                    </div>
                                </div>
                                <div class="relative max-w-sm">
                                    <div class="absolute inset-y-0 left-0 flex items-center pl-3.5 pointer-events-none">
                                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-gray-500 dark:text-gray-400">
                                            <path fill-rule="evenodd" d="M3 6a3 3 0 013-3h12a3 3 0 013 3v12a3 3 0 01-3 3H6a3 3 0 01-3-3V6zm4.5 7.5a.75.75 0 01.75.75v2.25a.75.75 0 01-1.5 0v-2.25a.75.75 0 01.75-.75zm3.75-1.5a.75.75 0 00-1.5 0v4.5a.75.75 0 001.5 0V12zm2.25-3a.75.75 0 01.75.75v6.75a.75.75 0 01-1.5 0V9.75A.75.75 0 0113.5 9zm3.75-1.5a.75.75 0 00-1.5 0v9a.75.75 0 001.5 0v-9z" clip-rule="evenodd" />
                                        </svg>                              
                                    </div>
                                    <input id="add_student_class" type="text"
                                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-fuchsia-500 focus:border-fuchsia-500 block w-full pl-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-fuchsia-500 dark:focus:border-fuchsia-500" placeholder="Select class">
                                </div>
                                
                            </div>                       
                        </div>
                                        
                    </form>
                </div>
                <div class="relative mt-6">
                    <div class="absolute inset-0 flex items-center" aria-hidden="true">
                        <div class="w-full border-t border-gray-300"></div>
                    </div>
                    <div class="relative flex justify-center">
                        <button type="button" class="add-more-student-btn inline-flex items-center gap-x-1.5 rounded-full bg-white px-3 py-1.5 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50">
                            <svg class="-ml-1 -mr-0.5 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                <path d="M10.75 4.75a.75.75 0 00-1.5 0v4.5h-4.5a.75.75 0 000 1.5h4.5v4.5a.75.75 0 001.5 0v-4.5h4.5a.75.75 0 000-1.5h-4.5v-4.5z" />
                            </svg>
                        Add more
                        </button>
                    </div>
                </div>
                <div class="flex justify-end items-center space-x-4 mt-1">   
                                                       
                    <div>
                        <button id="save_add_student_btn" type="button" class="inline-flex items-center gap-x-1.5 rounded-md bg-fuchsia-600 px-3 py-2 font-semibold text-white shadow-sm hover:bg-fuchsia-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-fuchsia-600">
                            <svg class="-ml-0.5 h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" />
                            </svg>
                            <span class="text-sm">Save All</span>
                        </button>
                    </div>      
                </div>
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