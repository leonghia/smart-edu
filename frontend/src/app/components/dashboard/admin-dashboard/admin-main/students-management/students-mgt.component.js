import { convertDateTimeToVn } from "../../../../../helpers/datetime.helper.js";
import searchBarService from "../../../../search-bar/search-bar.service.js";
import { hideDropdown, showDropdown } from "../../../../../helpers/animation.helper.js";
import dataService from "../../../../../services/data.service.js";
import { filterStudentByMainClass, getTotalStudents, renderMainClassesDropdownItem } from "../../../../../helpers/filter.helper.js";
import { sortByDob, sortByMainClass, sortByName } from "../../../../../helpers/sort.helper.js";
import studentsMgtService from "./students-mgt.service.js";
import { OverlayComponent } from "../../../../overlay/overlay.component.js";

export class StudentsMgtComponent extends HTMLElement {


    #filterBtn;
    #filterDropdown;
    #filterDropdownItems;
    #filterDropdownState = {
        state: false,
    }

    #sortBtn;
    #sortDropdown;
    #sortDropdownItems;
    #sortDropdownState = {
        state: false,
    }

    #mainClassFilterContainer;
    #tableBody;
    #table;

    #loadingSpinner = `
    <div role="status" class="absolute -translate-x-1/2 -translate-y-1/2 top-2/4 left-1/2">
        <loading-spinner se-class="w-10 h-10 text-gray-200 dark:text-gray-600 mr-12"></loading-spinner>                                     
    </div>
    `;

    #addDtoBtn;

    #orderOption = {
        orderBy: "name",
        asc: true,
    }

    #sortDropdownContainer;
    #ascInput;
    #descInput;

    constructor() {
        super();

        searchBarService.subscribe("search", {
            component: this,
            eventHandler: this.handleSearch
        })
    }


    connectedCallback() {
        this.innerHTML = this.#render();
        this.#filterBtn = document.querySelector("#se_filter_btn");
        this.#filterDropdown = document.querySelector("#se_filter_dropdown");
        this.#sortBtn = document.querySelector("#se_sort_btn");
        this.#sortDropdown = document.querySelector("#se_sort_dropdown");
        this.#sortDropdownItems = document.querySelectorAll(".se-sort-dropdown-item");
        const sortDropdownItemsArr = Array.from(this.#sortDropdownItems);
        this.#mainClassFilterContainer = document.querySelector("#se_main_class_filter_container");
        this.#tableBody = document.querySelector("tbody");
        this.#table = document.querySelector("table");
        this.#addDtoBtn = document.querySelector("#se_add_dto_btn");
        this.#sortDropdownContainer = document.querySelector("#se_sort_dropdown_container");
        this.#ascInput = document.querySelector("#asc");
        this.#descInput = document.querySelector("#desc");

        this.#ascInput.addEventListener("click",function(event){
            const clicked = event.target.closest("#asc");
            if(!clicked){
                return;
            }
            this.#orderOption.asc = true;
            switch(this.#orderOption.orderBy){
                case "name":
                    const results0 = sortByName(getStudents(),true);
                    this.#displayStudents(results0);
                    break;
                case "dob":
                    const results1 = sortByDob(getStudents(),true);
                    this.#displayStudents(results1);
                    break;
            }            

        }.bind(this));

        this.#descInput.addEventListener("click",function(event){
            const clicked = event.target.closest("#desc");
            if(!clicked){
                return;
            }
            this.#orderOption.asc = false;
            switch(this.#orderOption.orderBy){
                case "name":
                    const results0 = sortByName(getStudents(),false);
                    this.#displayStudents(results0);
                    break;
                case "dob":
                    const results1 = sortByDob(getStudents(),false);
                    this.#displayStudents(results1);
                    break;
            }
            
        }.bind(this));

        this.#sortDropdownContainer.addEventListener("click", function (event) {
            // kiem tra xem nguoi dung an vao mot trong 2 nut "Sort by date of birth" khong 
            const clicked = event.target.closest(".se-sort-dropdown-item");
            if (!clicked){
                return;
            }

            switch (clicked.id) {
                case "menu-item-0":
                    this.#orderOption.orderBy = "name";
                    break;
                case "menu-item-1":
                    this.#orderOption.orderBy = "dob";
                    break;
            }
        }.bind(this));

        // B1: Click the add new student button
        // B2: Display the overlay and the button on the DOM (connectedCallback)
        // B3: Wait 100ms
        // B4: After 100ms, toggle the classLists of the overlay and the button (opacity-0 to opacity-100)
        this.#addDtoBtn.addEventListener("click", function() {
            this.#addDtoBtn.parentElement.insertAdjacentHTML("beforeend", `
                <app-overlay modal="create-student-modal"></app-overlay>
            `);
        }.bind(this));

        // B1: Click the close modal button
        // B2: Toggle the classLists of the overlay and the button (opacity-0 to opacity-100)
        // B3: Wait 100ms
        // B4: After 100ms, remove the overlay and the button from the DOM (disconnectedCallback)
        

        // Gan su kien cho cac the input
        this.#mainClassFilterContainer.addEventListener("click", function (event) {
            const clicked = event.target.closest("input");
            if (!clicked) {
                return;  //khong lam gi nua 
            }
            // Buoc 1: Lay id lop hoc tu the input
            const mainClassId = clicked.id;
            // Buoc 2: Truyen id lop hoc vao ham loc hoc sinh theo id lop 
            const students = getStudents();
            const results = filterStudentByMainClass(students, +mainClassId);
            // hien thi ket qua loc
            this.#displayStudents(results);
        }.bind(this));

        this.#sortDropdownContainer.addEventListener("click", function (event) {
            const clicked = event.target.closest(".se-sort-dropdown-item");
            if (!clicked) {
                return;
            }

            const menuItems = this.#sortDropdown.querySelectorAll(".se-sort-dropdown-item");
            Array.from(menuItems).forEach(e => {
                e.classList.remove("text-fuchsia-500");
                e.classList.remove("font-medium");
                e.classList.add("text-white");
            });

            clicked.classList.remove("text-white");
            clicked.classList.add("text-fuchsia-500");
            clicked.classList.add("font-medium");


            const id = clicked.id;
            switch (id) {
                case "menu-item-0":
                    // const results = sortByName(getStudents());
                    // this.#displayStudents(results);
                    break;
                case "menu-item-1":
                    
                    break;
            }
        }.bind(this));


        this.#filterBtn.addEventListener("click", function () {
            if (this.#filterDropdownState.state) {
                hideDropdown(this.#filterDropdown, [], this.#filterDropdownState);
                return;
            }
            showDropdown(this.#filterDropdown, [], this.#filterDropdownState);
            if (this.#sortDropdownState.state) {
                hideDropdown(this.#sortDropdown, sortDropdownItemsArr, this.#sortDropdownState);
            }
        }.bind(this));

        this.#sortBtn.addEventListener("click", function () {
            if (this.#sortDropdownState.state) {
                hideDropdown(this.#sortDropdown, sortDropdownItemsArr, this.#sortDropdownState);
                return;
            }
            showDropdown(this.#sortDropdown, sortDropdownItemsArr, this.#sortDropdownState);
            if (this.#filterDropdownState.state) {
                hideDropdown(this.#filterDropdown, [], this.#filterDropdownState);
            }
        }.bind(this))

        dataService.getStudents()
            .then(res => {
                saveStudents(sortByMainClass(sortByName(res.data)));
                this.#displayStudents(getStudents());
                this.#displayClassesFilterDropdown();
            });

        // this.#sortDropdown.addEventListener("click", function(event) {
        //     const clicked = event.target.closest(".se-sort-dropdown-item");
        //     if (!clicked) {
        //         return;
        //     }
        //     hideDropdown(this.#sortDropdown, sortDropdownItemsArr, this.#sortDropdownState);
        // }.bind(this));
    }

    handleSearch(data) {
        this.#displayStudents(data);
    }

    #displayStudents(students) {
        setTimeout(function(){
            this.#tableBody.innerHTML = "";
            students.forEach((currentValue, currentIndex) => {
                this.#tableBody.insertAdjacentHTML("beforeend", this.#renderStudentsRow(currentValue, currentIndex));
            });
        }.bind(this), 500);
        this.#tableBody.innerHTML = "";
        this.#tableBody.innerHTML = `
        <div class="absolute -translate-x-1/2 -translate-y-1/2 top-2/4 left-1/2">
        </div>
        `;
        this.#tableBody.firstElementChild.innerHTML = `
            <loading-spinner se-class ="w-10 h-10 mr-10 text-gray-400"></loading-spinner>
        `;    
    }

    disconnectedCallback() {

    }

    #render() {
        return `
        <div class="h-full">
            <div class="mx-auto max-w-full h-full">
                <div class="py-10 h-full">
                    <div class="px-4 sm:px-6 lg:px-8 h-full">
                        <div class="sm:flex sm:items-center h-16">
                            <div class="sm:flex-auto">
                            <h1 class="text-base font-semibold leading-6 text-gray-900 dark:text-white">Students</h1>
                            <p class="mt-2 text-sm text-gray-700 dark:text-gray-300">A list of all the students in your application including their identifiers, names, dates of birth, emails, classes and parents.</p>
                            </div>
                            <div class="sm:ml-6 relative">
                                <div>
                                    <button id="se_filter_btn" type="button" class="inline-flex items-center gap-x-1.5 rounded-md bg-gray-900 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-gray-950 focus-visible:outline-none">
                                        <span class="">📢</span>
                                        <span class="mr-2">Filter</span>
                                        <svg class="-mr-1 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                            <path fill-rule="evenodd"
                                            d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                            clip-rule="evenodd" />
                                        </svg>
                                    </button>
                                </div>
                                <div id="se_filter_dropdown"
                                    class="transform opacity-0 scale-95 transition ease-out duration-700 absolute right-0 z-10 mt-3 w-52 origin-top-right rounded-lg bg-gray-900 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                                    role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                                    <div class="w-56 p-3" role="none">
                                    <h6 class="underline underline-offset-4 decoration-2 decoration-fuchsia-500 mb-3 text-sm font-medium text-white dark:text-white pl-1">
                                    Main Class
                                    </h6>
                                  <ul id="se_main_class_filter_container" class="-mb-3 space-y-2 text-sm max-h-44 overflow-scroll mr-1 pl-1" aria-labelledby="dropdownDefault">
                                                                                            
                                  </ul>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="sm:ml-6 relative">
                                <div>
                                    <button id="se_sort_btn" type="button" class="inline-flex items-center gap-x-1.5 rounded-md bg-gray-900 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-gray-950 focus-visible:outline-none">
                                        <span class="">🧲</span>
                                        <span class="mr-3">Sort</span>
                                            <svg class="-mr-1 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                                <path fill-rule="evenodd"
                                            d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                            clip-rule="evenodd" />
                                            </svg>
                                    </button>
                                </div>
                                <div id="se_sort_dropdown"
                                    class="transform opacity-0 scale-95 transition ease-out duration-700 absolute right-0 z-10 mt-3 w-56 origin-top-right rounded-lg bg-gray-900 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                                    role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                                
                                    <div class="">
                                        <div id = "se_sort_dropdown_container">
                                            <div
                                            class="text-white px-4 py-2 text-sm se-sort-dropdown-item rounded-t-md h-10 flex items-center"
                                            role="menuitem" tabindex="-1" id="menu-item-0">${"Sort by Full name"}
                                            </div>
                                            <div class="text-white px-4 py-2 text-sm se-sort-dropdown-item h-10 flex items-center"
                                                role="menuitem" tabindex="-1" id="menu-item-1">${"Sort by Date of birth"}
                                            </div>     
                                        </div>     
                                        <div class="text-white px-4 py-6 text-sm se-sort-dropdown-item rounded-b-md h-10 flex items-center justify-between border-t-2 border-fuchsia-500"
                                            role="menuitem" tabindex="-1">
                                            <span class="flex items-center">
                                                <input type="radio" name="order" value="asc" id="asc" class="w-4 h-4 bg-gray-100 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500 dark:focus:ring-fuchsia-600 dark:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500">
                                                <label for="asc" class="ml-2 text-sm font-medium text-gray-100 dark:text-gray-100">Ascend.</label>
                                            </span>
                                            <span class="flex items-center">
                                                <input type="radio" name="order" value="desc" id="desc" class="w-4 h-4 bg-gray-100 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500 dark:focus:ring-fuchsia-600 dark:ring-offset-gray-700 focus:ring-2 dark:bg-gray-600 dark:border-gray-500">
                                                <label for="desc" class="ml-2 text-sm font-medium text-gray-100 dark:text-gray-100">Descend.</label>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
                            <button id="se_add_dto_btn" type="button" class="flex items-center justify-center rounded-md bg-fuchsia-500 px-3 py-2 text-center text-sm font-semibold text-white hover:bg-fuchsia-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-fuchsia-500">                            
                                <svg xmlns="http://www.w3.org/2000/svg" class="h-4 w-4 mr-2 -ml-1" viewBox="0 0 20 20" fill="currentColor"
                                aria-hidden="true">
                                    <path d="M8 9a3 3 0 100-6 3 3 0 000 6zM8 11a6 6 0 016 6H2a6 6 0 016-6zM16 7a1 1 0 10-2 0v1h-1a1 1 0 100 2h1v1a1 1 0 102 0v-1h1a1 1 0 100-2h-1V7z"/>
                                </svg>
                                Add student
                            </button>                       
                            </div>
                        </div>
                        <div class="mt-8 flow-root h-full" style="height: calc(100% - 4rem);">
                            <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8 h-full">
                                <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8 h-full relative">

                                    <table class="min-w-full divide-y divide-dashed divide-gray-500 dark:divide-gray-600">
                                        <thead>
                                            <tr>
                                            <th scope="col" class="py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-gray-900 dark:text-white">No.</th>
                                            <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 dark:text-white sm:pl-0">Full Name</th>
                                            <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 dark:text-white">Identifier</th>
                                            <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 dark:text-white">Status</th>
                                            <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 dark:text-white">Class</th>
                                            <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 dark:text-white">Date Of Birth</th>
                                            <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 dark:text-white">Email</th>
                                            <th scope="col" class="px-3 py-3.5 text-left text-sm font-semibold text-gray-900 dark:text-white">Parent</th>
                                            <th scope="col" class="relative py-3.5 pl-3 pr-4 sm:pr-0">
                                                <span class="sr-only">Edit</span>
                                            </th>
                                            <th scope="col" class="relative py-3.5 pl-3 pr-4 sm:pr-0">
                                                <span class="sr-only">Delete</span>
                                            </th>
                                            </tr>
                                        </thead>
                                        <tbody class="divide-y divide-dashed divide-gray-500 dark:divide-gray-600">
                                            
                                        </tbody>
                                    </table>                                  
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>  
        `;
    }

    #renderStudentsRow(currentValue, currentIndex) {
        return `
        <tr>
            <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm text-gray-600 dark:text-gray-400">${currentIndex + 1}</td>
            <td class="whitespace-nowrap px-3 py-4 text-sm font-medium text-white sm:pl-0">
                <div class="flex items-center gap-x-4">
                    <img src="https://nghia.b-cdn.net/smart-edu/images/users/default-pfp.webp" alt="${currentValue.user.fullName}" class="h-8 w-8 rounded-full bg-gray-800">
                <div class="truncate text-sm font-medium leading-6 text-gray-900 dark:text-white hover:text-fuchsia-500 dark:hover:text-fuchsia-400 cursor-pointer">${currentValue.user.fullName}</div>
                </div>
            </td>
            <td class="whitespace-nowrap px-3 py-4 font-mono text-sm leading-6 text-gray-600 dark:text-gray-400">${"STU04.002589"}</td>
            <td class="whitespace-nowrap px-3 py-4 text-sm leading-6">
                <div class="flex items-center justify-end gap-x-2 sm:justify-start">
                    <div class="flex-none rounded-full p-1 ${true ? "text-green-400 bg-green-600/50 dark:text-green-400 dark:bg-green-400/10" : "text-gray-500 bg-gray-100/10"}">
                        <div class="h-1.5 w-1.5 rounded-full bg-current"></div>
                    </div>
                    <div class="hidden text-sm leading-6 text-gray-600 dark:text-gray-400 sm:block">${true ? "Online" : "Offline"}</div>
                </div>
            </td>
            <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-600 dark:text-gray-400">${currentValue.mainClass.name}</td>
            <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-600 dark:text-gray-400">${convertDateTimeToVn(currentValue.user.dateOfBirth)}</td>
            <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-600 dark:text-gray-400">${currentValue.user.email}</td>
            <td class="whitespace-nowrap px-3 py-4 text-sm leading-6 text-gray-600 dark:text-gray-400"><span class="hover:text-fuchsia-400 cursor-pointer"> ${currentValue.parent.user.fullName}</span></td>
            <td class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                <a href="#" class="text-emerald-500 dark:text-emerald-400 hover:text-emerald-400 dark:hover:text-emerald-300">Edit<span class="sr-only">, ${currentValue.fullName}</span></a>
            </td>
            <td class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-0">
                <a href="#" class="text-rose-400 hover:text-rose-300">Delete<span class="sr-only">, ${currentValue.fullName}</span></a>
            </td>
        </tr>
        `;
    }

    #displayClassesFilterDropdown() {
        dataService.getMainClasses()
            .then(data => {
                const mainClasses = data.data;
                mainClasses.forEach(mC => {
                    this.#mainClassFilterContainer.insertAdjacentHTML("beforeend", this.#renderClassesFilterDropdownItem(mC));
                });
            });
    }

    #renderClassesFilterDropdownItem(mainClass) {
        return renderMainClassesDropdownItem(mainClass);
    }

    #totalStudents(mainClassId) {
        return getTotalStudents(mainClassId);
    }
}

customElements.define("students-mgt", StudentsMgtComponent);

