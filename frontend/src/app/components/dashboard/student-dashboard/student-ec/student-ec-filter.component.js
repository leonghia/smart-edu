import { GRADES, SHIFTS } from "../../../../app.enum";
import { data } from "../../../../app.store";
import { hideDropdown, showDropdown } from "../../../../helpers/animation.helper";
import { filterExtraClasses } from "../../../../helpers/filter.helper";
import dataService from "../../../../services/data.service";
import studentEcService from "./student-ec.service";

export class StudentExtraClassFilterComponent extends HTMLElement {

    #container;
    #subjects;
    #states = [
        {
            state: false
        },
        {
            state: false
        },
        {
            state: false
        }
    ];
    #filterOption = {
        subject: null,
        grade: null,
        shift: null
    }

    constructor() {
        super();
        
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#container = this.querySelector(".container");

        if (data.subjects.length === 0) {
            dataService.getSubjects()
                .then(res => {
                    data.subjects = res.data;
                    this.#subjects = data.subjects;
                    this.querySelector(".subject-filter-form").innerHTML = this.#renderSubjects(this.#subjects);
                });
        } else {
            this.#subjects = data.subjects;
            this.querySelector(".subject-filter-form").innerHTML = this.#renderSubjects(this.#subjects);
        }

        this.#container.addEventListener("click", function(event) {
            
            const clicked = event.target.closest("button") || event.target.closest("input");
            if (!clicked) {
                return;
            }

            if (clicked instanceof HTMLInputElement) {
                if (clicked.closest("#subject_filter")) {
                    this.querySelector("#subject_label").textContent = clicked.nextElementSibling.textContent;
                    this.#filterOption.subject = Number(clicked.value);
                } else if (clicked.closest("#grade_filter")) {
                    this.querySelector("#grade_label").textContent = clicked.nextElementSibling.textContent;
                    this.#filterOption.grade = Number(clicked.value);
                } else {
                    this.querySelector("#shift_label").textContent = clicked.nextElementSibling.textContent;
                    this.#filterOption.shift = clicked.value;
                }
                return;
            }

            const btns = Array.from(this.#container.querySelectorAll("button")).slice(0, 3);
            btns.forEach((btn, currentIndex) => {
                const dropdown = btn.parentElement.nextElementSibling;
                const items = Array.from(dropdown.querySelectorAll("input"));
                hideDropdown(dropdown, items, this.#states[currentIndex].state);
            });

            if (clicked.classList.contains("filter-ec-btn")) {
                const extraClasses = filterExtraClasses(data.extraClasses, this.#filterOption);
                studentEcService.trigger("refreshEcGrid", extraClasses);
                return;
            }

            const dropdown = clicked.parentElement.nextElementSibling;
            const items = Array.from(dropdown.querySelectorAll("input"));
            const index = Number(clicked.dataset.btn);
            const state = this.#states[index];

            if (!state.state) {
                showDropdown(dropdown, items, state);
            } else {
                hideDropdown(dropdown, items, state);
            }

        }.bind(this));
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="mx-auto max-w-3xl px-4 text-center sm:px-6 lg:max-w-7xl lg:px-4 mb-2">

        <section aria-labelledby="filter-heading" class="py-3">
            <h2 id="filter-heading" class="sr-only">Product filters</h2>
    
            <div class="flex items-center justify-end">
    
                <div class="container hidden sm:flex sm:items-center sm:space-x-8 sm:justify-end">
                    <div id="subject_filter" class="relative inline-block text-left">
                        <div>
                            <button type="button" data-btn="0"
                                class="group inline-flex items-center justify-center text-sm font-medium text-gray-700 hover:text-gray-900"
                                aria-expanded="false">
                                <span>Subject</span>
                                <span id="subject_label"
                                    class="ml-1.5 rounded bg-gray-200 px-1.5 py-0.5 text-xs font-semibold tabular-nums text-gray-700">All</span>
                                <svg class="-mr-1 ml-1 h-5 w-5 flex-shrink-0 text-gray-400 group-hover:text-gray-500"
                                    viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                    <path fill-rule="evenodd"
                                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                        clip-rule="evenodd" />
                                </svg>
                            </button>
                        </div>
                        <div
                            class="opacity-0 absolute right-0 z-10 mt-2 origin-top-right rounded-md bg-white p-4 shadow-2xl ring-1 ring-black ring-opacity-5 focus:outline-none">
                            <form class="subject-filter-form space-y-4">                             
                                
                                
                            </form>
                        </div>
                    </div>

                    <div id="grade_filter" class="relative inline-block text-left">
                        <div>
                            <button type="button" data-btn="1"
                                class="group inline-flex items-center justify-center text-sm font-medium text-gray-700 hover:text-gray-900"
                                aria-expanded="false">
                                <span>Grade</span>
                                <span id="grade_label"
                                    class="ml-1.5 rounded bg-gray-200 px-1.5 py-0.5 text-xs font-semibold tabular-nums text-gray-700">All</span>
                                <svg class="-mr-1 ml-1 h-5 w-5 flex-shrink-0 text-gray-400 group-hover:text-gray-500"
                                    viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                    <path fill-rule="evenodd"
                                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                        clip-rule="evenodd" />
                                </svg>
                            </button>
                        </div>
                        <div
                            class="opacity-0 absolute right-0 z-10 mt-2 origin-top-right rounded-md bg-white p-4 shadow-2xl ring-1 ring-black ring-opacity-5 focus:outline-none">
                            <form class="space-y-4">
                                <div class="flex items-center">
                                    <input id="filter-category-0" name="category[]" value="" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-0"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">All</label>
                                </div>
                                <div class="flex items-center">
                                    <input id="filter-category-0" name="category[]" value="10" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-0"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">${GRADES[0]}</label>
                                </div>
                                <div class="flex items-center">
                                    <input id="filter-category-1" name="category[]" value="11" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-1"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">${GRADES[1]}</label>
                                </div>
                                <div class="flex items-center">
                                    <input id="filter-category-2" name="category[]" value="12" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-2"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">${GRADES[2]}</label>
                                </div>
                            </form>
                        </div>
                    </div>

                    <div id="shift_filter" class="relative inline-block text-left">
                        <div>
                            <button type="button" data-btn="2"
                                class="group inline-flex items-center justify-center text-sm font-medium text-gray-700 hover:text-gray-900"
                                aria-expanded="false">
                                <span>Shift</span>
                                <span id="shift_label"
                                    class="ml-1.5 rounded bg-gray-200 px-1.5 py-0.5 text-xs font-semibold tabular-nums text-gray-700">All</span>
                                <svg class="-mr-1 ml-1 h-5 w-5 flex-shrink-0 text-gray-400 group-hover:text-gray-500"
                                    viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                    <path fill-rule="evenodd"
                                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                        clip-rule="evenodd" />
                                </svg>
                            </button>
                        </div>
                        <div
                            class="opacity-0 absolute right-0 z-10 mt-2 origin-top-right rounded-md bg-white p-4 shadow-2xl ring-1 ring-black ring-opacity-5 focus:outline-none">
                            <form class="space-y-4">
                                <div class="flex items-center">
                                    <input id="filter-category-0" name="category[]" value="" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-0"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">All</label>
                                </div>
                                <div class="flex items-center">
                                    <input id="filter-category-0" name="category[]" value="M" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-0"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">${SHIFTS.M}</label>
                                </div>
                                <div class="flex items-center">
                                    <input id="filter-category-1" name="category[]" value="A" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-1"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">${SHIFTS.A}</label>
                                </div>
                                <div class="flex items-center">
                                    <input id="filter-category-2" name="category[]" value="E" type="radio"
                                        class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
                                    <label for="filter-category-2"
                                        class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">${SHIFTS.E}</label>
                                </div>
                            </form>
                        </div>
                    </div>

                    <div class="relative inline-block text-left">
                        <button type="button" class="filter-ec-btn inline-flex items-center gap-x-1.5 rounded-md bg-fuchsia-600 px-3 py-1.5 text-sm font-semibold text-white shadow-sm hover:bg-fuchsia-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-fuchsia-600">                         
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="-ml-0.5 h-4 w-4">
                                <path fill-rule="evenodd" d="M3.792 2.938A49.069 49.069 0 0112 2.25c2.797 0 5.54.236 8.209.688a1.857 1.857 0 011.541 1.836v1.044a3 3 0 01-.879 2.121l-6.182 6.182a1.5 1.5 0 00-.439 1.061v2.927a3 3 0 01-1.658 2.684l-1.757.878A.75.75 0 019.75 21v-5.818a1.5 1.5 0 00-.44-1.06L3.13 7.938a3 3 0 01-.879-2.121V4.774c0-.897.64-1.683 1.542-1.836z" clip-rule="evenodd" />
                            </svg>
                            Filter
                        </button>                        
                    </div>
    
                </div>
            </div>
        </section>
    </div>    
        `;
    }

    #renderSubjects(subjects) {
        return subjects.reduce((accumulator, currentValue) => accumulator + `
        <div class="flex items-center">
            <input id="filter-category-0" name="category[]" value="${currentValue.id}" type="radio"
            class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
            <label for="filter-category-0"
            class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">${currentValue.name}</label>
        </div>
        `, `
        <div class="flex items-center">
            <input id="filter-category-0" name="category[]" value="" type="radio"
            class="h-4 w-4 border-gray-300 text-fuchsia-600 focus:ring-fuchsia-500">
            <label for="filter-category-0"
            class="ml-3 whitespace-nowrap pr-6 text-sm font-medium text-gray-900">All</label>
        </div>
        `);
    }
}

customElements.define("student-ec-filter", StudentExtraClassFilterComponent);