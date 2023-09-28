import { getAcademicYears, getMarksFromAcademicYearAndSemester } from "../../helpers/util.helper";
import { data } from "../../app.store";
import studentMaService from "../dashboard/student-dashboard/student-ma/student-ma.service";
import { hideDropdown, showDropdown } from "../../helpers/animation.helper";

export class MarkAssessmentNavigationComponent extends HTMLElement {

    #yearTabContainer;
    #semesterTabContainer;
    #academicYears;
    #option;
    #dropdown;
    #dropdownBtn;
    #semsester1Tab;

    #dropdownState = {
        state: false
    };

    constructor() {
        super();
        this.#academicYears = getAcademicYears(data.currentUser.student.marks);
        this.#option = {
            fromYear: this.#academicYears[0].fromYear,
            toYear: this.#academicYears[0].toYear,
            semester: 1
        };

    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#yearTabContainer = this.querySelector(".year-tab-container");
        this.#semesterTabContainer = this.querySelector(".semester-tab-container");
        this.#dropdown = this.querySelector(".dropdown");
        this.#dropdownBtn = this.querySelector(".dropdown-btn");
        this.#semsester1Tab = this.querySelector("#semester_1_tab");
        const items = Array.from(this.#dropdown.querySelectorAll("a"));

        this.#dropdownBtn.addEventListener("click", () => {
            if (this.#dropdownState.state) {
                hideDropdown(this.#dropdown, items, this.#dropdownState);
            } else {
                showDropdown(this.#dropdown, items, this.#dropdownState);
            }
        });

        const firstYearTab = this.#yearTabContainer.querySelector("a");
        firstYearTab.classList.remove(..."border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700".split(" "));
        firstYearTab.classList.add(..."border-fuchsia-500 text-fuchsia-600".split(" "));

        const firstSemesterTab = this.#semesterTabContainer.querySelector("a");
        firstSemesterTab.classList.remove(..."text-gray-500 hover:text-gray-700".split(" "));
        firstSemesterTab.classList.add(..."bg-fuchsia-100 text-fuchsia-700".split(" "));

        this.#semesterTabContainer.addEventListener("click", event => {
            const clicked = event.target.closest("a");
            if (!clicked) {
                return;
            }
            const links = this.#semesterTabContainer.querySelectorAll("a");
            links.forEach(l => {
                l.classList.remove(..."bg-fuchsia-100 text-fuchsia-700".split(" "));
                l.classList.add(..."text-gray-500 hover:text-gray-700".split(" "));
            });
            clicked.classList.remove(..."text-gray-500 hover:text-gray-700".split(" "));
            clicked.classList.add(..."bg-fuchsia-100 text-fuchsia-700".split(" "));
            this.#option.semester = Number(clicked.dataset.semester);
            if (this.#option.semester !== 999) {
                const marks = getMarksFromAcademicYearAndSemester(data.currentUser.student.marks, this.#option);
                studentMaService.trigger("switchSemester", marks);
            } else {
                this.#option.semester = 1;
                const marksSemester1 = getMarksFromAcademicYearAndSemester(data.currentUser.student.marks, this.#option);
                studentMaService.trigger("switchSummary", marksSemester1);
            }
            
        });

        this.#yearTabContainer.addEventListener("click", event => {
            const clicked = event.target.closest("a");
            if (!clicked) {
                return;
            }
            const links = this.#yearTabContainer.querySelectorAll("a");
            links.forEach(l => {
                l.classList.remove(..."border-fuchsia-500 text-fuchsia-600".split(" "));
                l.classList.add(..."border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700".split(" "));
            });
            clicked.classList.remove(..."border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700".split(" "));
            clicked.classList.add(..."border-fuchsia-500 text-fuchsia-600".split(" "));
            this.#option.fromYear = Number(clicked.dataset.from);
            this.#option.toYear = Number(clicked.dataset.to);
            const marks = getMarksFromAcademicYearAndSemester(data.currentUser.student.marks, this.#option);
            studentMaService.trigger("switchSemester", marks);

            const semesterLinks = this.#semesterTabContainer.querySelectorAll("a");
            semesterLinks.forEach(l => {
                l.classList.remove(..."bg-fuchsia-100 text-fuchsia-700".split(" "));
                l.classList.add(..."text-gray-500 hover:text-gray-700".split(" "));
            });
            this.#semsester1Tab.classList.remove(..."text-gray-500 hover:text-gray-700".split(" "));
            this.#semsester1Tab.classList.add(..."bg-fuchsia-100 text-fuchsia-700".split(" "));
        });
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="mb-8">
        <div class="sm:hidden">
            <label for="tabs" class="sr-only">Select a tab</label>
            <!-- Use an "onChange" listener to redirect the user to the selected tab URL. -->
            <select id="tabs" name="tabs"
                class="block w-full rounded-md border-gray-300 focus:border-fuchsia-500 focus:ring-fuchsia-500">
                <option>My Account</option>
                <option>Company</option>
                <option selected>Team Members</option>
                <option>Billing</option>
            </select>
        </div>
        <div class="hidden sm:block">
            <div class="border-b border-gray-200">
                <nav class="-mb-px flex year-tab-container" aria-label="Tabs">
                    <!-- Current: "border-fuchsia-500 text-fuchsia-600", Default: "border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700" -->
                    
                    ${this.#renderAcademicYears(this.#academicYears)}
                </nav>
            </div>
        </div>
    </div>  
    
    <div class="mb-8 w-3/4 pr-8">
        <div class="sm:hidden">
            <label for="tabs" class="sr-only">Select a tab</label>
            <!-- Use an "onChange" listener to redirect the user to the selected tab URL. -->
            <select id="tabs" name="tabs"
                class="block w-full rounded-md border-gray-300 focus:border-fuchsia-500 focus:ring-fuchsia-500">
                <option>My Account</option>
                <option>Company</option>
                <option selected>Team Members</option>
                <option>Billing</option>
            </select>
        </div>
        <div class="hidden sm:block">
            <nav class="flex justify-between" aria-label="Tabs">
                <div class="flex space-x-4 semester-tab-container">
                    <!-- Current: "bg-fuchsia-100 text-fuchsia-700", Default: "text-gray-500 hover:text-gray-700" -->
                    <a href="#" id="semester_1_tab" data-semester="1" class="text-gray-500 hover:text-gray-700 rounded-md px-3 py-2 text-sm font-medium">Semester 1</a>
                    <a href="#" data-semester="2" class="text-gray-500 hover:text-gray-700 rounded-md px-3 py-2 text-sm font-medium">Semester 2</a>
                    <a href="#" data-semester="999" class="text-gray-500 hover:text-gray-700 rounded-md px-3 py-2 text-sm font-medium"
                    aria-current="page">Summary</a> 
                </div>
                <div class="hidden relative inline-block text-left">
                    <div>
                        <button type="button"
                            class="dropdown-btn inline-flex w-full justify-center gap-x-1.5 rounded-md bg-gray-100 px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-0 ring-inset ring-gray-300"
                            id="menu-button" aria-expanded="true" aria-haspopup="true">
                            Options
                            <svg class="-mr-1 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                <path fill-rule="evenodd"
                                    d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                    clip-rule="evenodd" />
                            </svg>
                        </button>
                    </div>
                
                    <!--
                      Dropdown menu, show/hide based on menu state.
                  
                      Entering: "transition ease-out duration-100"
                        From: "transform opacity-0 scale-95"
                        To: "transform opacity-100 scale-100"
                      Leaving: "transition ease-in duration-75"
                        From: "transform opacity-100 scale-100"
                        To: "transform opacity-0 scale-95"
                    -->
                    <div class="dropdown opacity-0 absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                        role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                        <div class="py-1" role="none">
                            <!-- Active: "bg-gray-100 text-gray-900", Not Active: "text-gray-700" -->
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-item-0">Marks table</a>
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-item-1">Assessments</a>   
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-item-2">Academic Progress</a>                                  
                        </div>
                    </div>
                </div>      
            </nav>
        </div>
    </div>
        `;
    }

    #renderAcademicYears(years) {
        return years.reduce((accumulator, currentValue) => accumulator + this.#renderAcademicYear(currentValue), "");
    }

    #renderAcademicYear(year) {
        return `
        <a href="#" data-from="${year.fromYear}" data-to="${year.toYear}"
        class="border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700 w-1/3 border-b-2 py-4 px-1 text-center text-sm font-medium">Year ${year.fromYear} - ${year.toYear}</a>
        `;
    }
}

customElements.define("ma-nav", MarkAssessmentNavigationComponent);