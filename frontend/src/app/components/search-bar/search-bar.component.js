import searchBarService from "./search-bar.service.js";
import { searchByName, searchByIdentifier, searchByEmail } from "../../helpers/search.helper.js";
import { showDropdown, hideDropdown } from "../../helpers/animation.helper.js";


export class SearchBarComponent extends HTMLElement {

    #dropdownOptionState = {
        state: false,
        active: "name",
        title: "🆎 Fullname"
    };

    #dropdownBtn;
    #dropdownOptions;
    #menuItems;
    #menuItemsArr;
    #searchField;
    #searchForm;

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#dropdownBtn = document.querySelector("#se_dropdown_btn");
        this.#dropdownOptions = document.querySelector("#se_dropdown_options");
        this.#menuItems = document.querySelectorAll(".se-menu-item");
        this.#menuItemsArr = Array.from(this.#menuItems);
        this.#searchField = document.querySelector("#se_table_search_field");
        this.#searchForm = document.querySelector("#se_table_search_form");

        this.#dropdownBtn.addEventListener("click", function () {
            if (this.#dropdownOptionState.state) {
                hideDropdown(this.#dropdownOptions, this.#menuItemsArr, this.#dropdownOptionState);
            } else {
                showDropdown(this.#dropdownOptions, this.#menuItemsArr, this.#dropdownOptionState);
            }
        }.bind(this));

        this.#dropdownOptions.addEventListener("click", function (event) {
            if (!event.target.classList.contains("se-menu-item")) {
                return;
            }
            switch (event.target.id) {
                case "menu-item-0":
                    this.#dropdownBtn.firstElementChild.textContent = "🆎 Fullname";
                    this.#dropdownOptionState.active = "name";
                    break;
                case "menu-item-1":
                    this.#dropdownBtn.firstElementChild.textContent = "🔑 Identifier";
                    this.#dropdownOptionState.active = "id";
                    break;
                case "menu-item-2":
                    this.#dropdownBtn.firstElementChild.textContent = "💌 Email";
                    this.#dropdownOptionState.active = "email";
                    break;
            }
            hideDropdown(this.#dropdownOptions, this.#menuItemsArr, this.#dropdownOptionState);
        }.bind(this));

        this.#searchForm.addEventListener("submit", function (event) {
            event.preventDefault();
            let results;
            switch (this.#dropdownOptionState.active) {
                case "name":
                    results = searchByName(getStudents(), this.#searchField.value);
                    break;
                case "id":
                    results = searchById(getStudents(), this.#searchField.value);
                    break;
                case "email":
                    results = searchByEmail(getStudents(), this.#searchField.value);
                    break;
            }

            searchBarService.trigger("search", results);
        }.bind(this));
    }

    disconnectedCallback() {

    }

    #render() {
        return `
        <div class="rounded-tr-lg sticky top-0 z-40 flex h-20 shrink-0 items-center gap-x-6 border-b border-white/5 px-4 shadow-sm sm:px-6 lg:px-8">
            <button type="button" class="-m-2.5 p-2.5 text-white xl:hidden">
                <span class="sr-only">Open sidebar</span>
                <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                        <path fill-rule="evenodd"
                            d="M2 4.75A.75.75 0 012.75 4h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 4.75zM2 10a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 10zm0 5.25a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75a.75.75 0 01-.75-.75z"
                            clip-rule="evenodd" />
                </svg>
            </button>

            <div class="flex flex-1 gap-x-4 self-stretch lg:gap-x-6">
                <form class="flex flex-1" id="se_table_search_form">
                    <label for="se_table_search_field" class="sr-only">Search</label>
                    <div class="relative w-full flex items-center gap-x-4">
                        <svg class="pointer-events-none inset-y-0 left-0 h-full w-5 text-gray-500"
                                viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                <path fill-rule="evenodd"
                                    d="M9 3.5a5.5 5.5 0 100 11 5.5 5.5 0 000-11zM2 9a7 7 0 1112.452 4.391l3.328 3.329a.75.75 0 11-1.06 1.06l-3.329-3.328A7 7 0 012 9z"
                                    clip-rule="evenodd" />
                        </svg>
                        
                        <div class="relative z-10" aria-labelledby="modal-title" role="dialog" aria-modal="true">
                            
                            <div class="relative inline-block text-left">
                                <div>
                                    <button type="button"
                                        class="focus-visible:outline-none inline-flex w-full justify-center gap-x-1.5 rounded-md bg-gray-900 px-3 py-2 text-xs font-semibold text-white shadow-sm hover:bg-gray-950"
                                        id="se_dropdown_btn" aria-expanded="true" aria-haspopup="true">
                                        <span class="w-20">${this.#dropdownOptionState.title}</span>
                                        <svg class="-mr-1 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                            <path fill-rule="evenodd"
                                                d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                                clip-rule="evenodd" />
                                        </svg>
                                    </button>
                                </div>
                                <div id="se_dropdown_options"
                                    class="transform opacity-0 scale-95 transition ease-out duration-700 absolute left-0 z-10 mt-3 w-56 origin-top-right rounded-md bg-gray-900 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                                    role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                                    <div class="" role="none">
                                        <span
                                            class="text-white px-4 py-2 text-sm se-menu-item rounded-t-md h-10 flex items-center hover:bg-gray-700"
                                            role="menuitem" tabindex="-1" id="menu-item-0">${"🆎 Search by fullname"}</span>
                                        <span class="text-white px-4 py-2 text-sm se-menu-item h-10 flex items-center hover:bg-gray-700"
                                            role="menuitem" tabindex="-1" id="menu-item-1">${"🔑 Search by identifier"}</span>
                                        <span
                                            class="text-white px-4 py-2 text-sm se-menu-item rounded-b-md h-10 flex items-center hover:bg-gray-700"
                                            role="menuitem" tabindex="-1" id="menu-item-2">${"💌 Search by email"}</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <input id="se_table_search_field"
                                class="block h-full w-full border-0 bg-transparent py-0 pr-0 pl-0 text-gray-900 dark:text-white focus:ring-0 focus:outline-none sm:text-sm"
                                placeholder="${"Search for students by name, identifier or email....."}" type="search" name="search">
                    </div>
                </form>
            </div>
        </div>
        `;
    }
}

customElements.define("search-bar", SearchBarComponent);