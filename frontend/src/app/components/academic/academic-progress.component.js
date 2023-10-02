import { MONTHS, WEEKDAYS } from "../../app.enum";
import { data } from "../../app.store";
import { getFirstDayOfMonth, getLastDayOfMonth, getLastDateOfMonth, displayAcademicProgresses, toISOVNString } from "../../helpers/datetime.helper";
import { AcademicProgressRequestParams } from "../../models/academicProgressRequestParams";
import { TimetableRequestParams } from "../../models/timetableRequestParams";
import dataService from "../../services/data.service";
import { hideDropdown, showDropdown } from "../../helpers/animation.helper";

export class AcademicProgressComponent extends HTMLElement {

    #date = new Date();
    #today = new Date();
    #calendarContainer;
    #dateButtons;
    #nextMonthButton;
    #prevMonthButton;
    #monthYearDiv;
    #selectedDateHeading;
    #nextDateButton;
    #prevDateButton;
    #currentDateText;
    #academicProgressOl;
    #dropdownButton;
    #dropdown;
    #dropdownItems;
    #trackerTab;

    #dropdownState = {
        state: false
    }

    #timetableRequestParams = new TimetableRequestParams(data.currentUser.student.mainClass.id);

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#calendarContainer = this.querySelector(".calendar-container");
        this.#dateButtons = Array.from(this.#calendarContainer.querySelectorAll("button"));
        this.#nextMonthButton = this.querySelector(".next-month-btn");
        this.#prevMonthButton = this.querySelector(".prev-month-btn");
        this.#monthYearDiv = this.querySelector(".month-year-div");
        this.#selectedDateHeading = this.querySelector(".selected-date-heading");
        this.#nextDateButton = this.querySelector(".next-date-btn");
        this.#prevDateButton = this.querySelector(".prev-date-btn");
        this.#currentDateText = this.querySelector(".current-date-text");
        this.#academicProgressOl = this.querySelector(".academic-progresses-ol");
        this.#dropdownButton = this.querySelector(".dropdown-btn");
        this.#dropdown = this.querySelector(".dropdown");
        this.#dropdownItems = Array.from(this.#dropdown.querySelectorAll("a"));
        this.#trackerTab = this.querySelector("#tracker_tab");

        this.#trackerTab.addEventListener("click", () => {
            document.querySelector(".main-wrapper").innerHTML = "<academic-tracker></academic-tracker>";
        });

        this.#dropdownButton.addEventListener("click", () => {
            if (this.#dropdownState.state) hideDropdown(this.#dropdown, this.#dropdownItems, this.#dropdownState);
            else showDropdown(this.#dropdown, this.#dropdownItems, this.#dropdownState);
        });

        this.#nextDateButton.addEventListener("click", () => {
            this.#date.setDate(this.#date.getDate() + 1);
            this.#displayCalendar(this.#date);
            this.#highlightCurrentDate(this.#date);
            this.#currentDateText.textContent = this.#date.toLocaleDateString("vi-VN");
        });

        this.#prevDateButton.addEventListener("click", () => {
            this.#date.setDate(this.#date.getDate() - 1);
            this.#displayCalendar(this.#date);
            this.#highlightCurrentDate(this.#date);
            this.#currentDateText.textContent = this.#date.toLocaleDateString("vi-VN");
        });

        this.#calendarContainer.addEventListener("click", event => {
            const clicked = event.target.closest("button");
            if (!clicked) return;
            this.#dateButtons.forEach(b => {
                b.classList.remove("font-semibold", "text-white");
                b.firstElementChild.classList.remove("bg-fuchsia-600");
            });
            clicked.classList.add("font-semibold", "text-white");
            clicked.firstElementChild.classList.add("bg-fuchsia-600");

            this.#date = new Date(clicked.firstElementChild.dateTime);

            this.#displayAcademicProgress(this.#date);
            this.#currentDateText.textContent = this.#date.toLocaleDateString("vi-VN");
        });

        this.#nextMonthButton.addEventListener("click", () => {
            this.#date.setDate(1);
            this.#date.setMonth(this.#date.getMonth() + 1);
            this.#displayCalendar(this.#date);
        });

        this.#prevMonthButton.addEventListener("click", () => {
            this.#date.setDate(1);
            this.#date.setMonth(this.#date.getMonth() - 1);
            this.#displayCalendar(this.#date);
        });

        this.#displayCalendar(this.#date);
    }

    disconnectedCallback() {

    }

    #highlightCurrentDate(date = new Date()) {
        this.#dateButtons.forEach(b => {
            b.classList.remove("font-semibold", "text-white");
            b.firstElementChild.classList.remove("bg-fuchsia-600");
            const d = new Date(b.firstElementChild.dateTime);
            if (date.getFullYear() === d.getFullYear() && date.getMonth() === d.getMonth() && date.getDate() === d.getDate()) {
                b.classList.add("font-semibold", "text-white");
                b.firstElementChild.classList.add("bg-fuchsia-600");
            }
        });
    }

    #displayCalendar(date = new Date()) {
        const temp = new Date(date);
        this.#monthYearDiv.textContent = MONTHS[date.getMonth()] + " " + date.getFullYear();
        let firstDayOfMonth = getFirstDayOfMonth(date.getFullYear(), date.getMonth()) - 1;
        if (firstDayOfMonth < 0) firstDayOfMonth = 6;
        const lastDateOfMonth = getLastDateOfMonth(date.getFullYear(), date.getMonth());
        let start = 0;
        let startOfNextMonth = 0;
        const d = new Date(date);
        d.setMonth(d.getMonth() - 1);
        const lastDateOfPreviousMonth = getLastDateOfMonth(d.getFullYear(), d.getMonth());
        this.#dateButtons.forEach((currentElement, currentIndex) => {
            if (currentIndex >= firstDayOfMonth && currentIndex < lastDateOfMonth + firstDayOfMonth) {
                currentElement.firstElementChild.textContent = start + 1;
                temp.setDate(start + 1);
                currentElement.firstElementChild.dateTime = toISOVNString(temp);
                currentElement.classList.remove("text-gray-400", "bg-gray-50", "pointer-events-none");
                currentElement.classList.add("text-gray-900", "bg-white");
                start++;
            }

            if (currentIndex < firstDayOfMonth) {
                currentElement.firstElementChild.textContent = lastDateOfPreviousMonth - (firstDayOfMonth - 1) + currentIndex;
                currentElement.firstElementChild.datetime = "";
                currentElement.classList.remove("text-gray-900", "bg-white");
                currentElement.classList.add("text-gray-400", "bg-gray-50", "pointer-events-none");
            }
            if (currentIndex >= lastDateOfMonth + firstDayOfMonth) {
                currentElement.firstElementChild.textContent = ++startOfNextMonth;
                currentElement.firstElementChild.datetime = "";
                currentElement.classList.remove("text-gray-900", "bg-white");
                currentElement.classList.add("text-gray-400", "bg-gray-50", "pointer-events-none");
            }
        });

        this.#highlightCurrentDate(this.#date);

        this.#displayAcademicProgress(this.#date);
    }

    #displayAcademicProgress(date = new Date()) {
        const temp = new Date(date);

        this.#selectedDateHeading.children[1].textContent = `${MONTHS[date.getMonth()]} ${date.getDate()}, ${date.getFullYear()}`;

        if (date.getDay() === 0) {
            this.#academicProgressOl.innerHTML = "";
            return;
        }

        this.#timetableRequestParams.from = date;
        temp.setDate(temp.getDate() + 1);
        this.#timetableRequestParams.to = temp;

        // dataService.getTimetableByWeek(this.#timetableRequestParams)
        //     .then(res => {
        //         displayAcademicProgresses(this.#academicProgressOl, res.data);
        //     });

        const academicProgressRequestParams = new AcademicProgressRequestParams();
        academicProgressRequestParams.studentId = data.currentUser.student.id;
        academicProgressRequestParams.date = this.#timetableRequestParams.from;

        dataService.getAcademicProgressByDate(academicProgressRequestParams)
            .then(res => {
                if (res.data) displayAcademicProgresses(this.#academicProgressOl, res.data);
            });
    }

    #render() {
        return `
    <div class="flex h-full flex-col">
        <header class="flex flex-none items-center justify-between border-b border-gray-200 px-6 py-4">
            <div>
                <h1 class="selected-date-heading text-base font-semibold leading-6 text-gray-900">
                    <time datetime="2022-01-22" class="sm:hidden">Jan 22, 2022</time>
                    <time datetime="2022-01-22" class="hidden sm:inline"></time>
                </h1>
                <p class="selected-weekday-text mt-1 text-sm text-gray-500">Academic progress</p>
            </div>
            <div class="flex items-center">
                <div class="relative flex items-center rounded-md bg-white shadow-sm md:items-stretch">
                    <button type="button"
                        class="prev-date-btn flex h-9 w-12 items-center justify-center rounded-l-md border-y border-l border-gray-300 pr-1 text-gray-400 hover:text-gray-500 focus:relative md:w-9 md:pr-0 md:hover:bg-gray-50">
                        <span class="sr-only">Previous day</span>
                        <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path fill-rule="evenodd"
                                d="M12.79 5.23a.75.75 0 01-.02 1.06L8.832 10l3.938 3.71a.75.75 0 11-1.04 1.08l-4.5-4.25a.75.75 0 010-1.08l4.5-4.25a.75.75 0 011.06.02z"
                                clip-rule="evenodd" />
                        </svg>
                    </button>
                    <button type="button"
                        class="current-date-text hidden border-y border-gray-300 px-3.5 text-sm font-semibold text-gray-900 hover:bg-gray-50 focus:relative md:block">Today</button>
                    <span class="relative -mx-px h-5 w-px bg-gray-300 md:hidden"></span>
                    <button type="button"
                        class="next-date-btn flex h-9 w-12 items-center justify-center rounded-r-md border-y border-r border-gray-300 pl-1 text-gray-400 hover:text-gray-500 focus:relative md:w-9 md:pl-0 md:hover:bg-gray-50">
                        <span class="sr-only">Next day</span>
                        <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path fill-rule="evenodd"
                                d="M7.21 14.77a.75.75 0 01.02-1.06L11.168 10 7.23 6.29a.75.75 0 111.04-1.08l4.5 4.25a.75.75 0 010 1.08l-4.5 4.25a.75.75 0 01-1.06-.02z"
                                clip-rule="evenodd" />
                        </svg>
                    </button>
                </div>
                <div class="hidden md:ml-4 md:flex md:items-center">
                    <div class="relative">
                        <button type="button"
                            class="dropdown-btn flex items-center gap-x-1.5 rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
                            id="menu-button" aria-expanded="false" aria-haspopup="true">
                            Progress
                            <svg class="-mr-1 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor"
                                aria-hidden="true">
                                <path fill-rule="evenodd"
                                    d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                    clip-rule="evenodd" />
                            </svg>
                        </button>
    
                        <!--
                  Dropdown menu, show/hide based on menu state.
      
                  Entering: "transition ease-out duration-100"
                    From: "transform opacity-0 scale-95"
                    To: "transform opacity-100 scale-100"
                  Leaving: "transition ease-in duration-75"
                    From: "transform opacity-100 scale-100"
                    To: "transform opacity-0 scale-95"
                -->
                        <div class="dropdown opacity-0 absolute right-0 z-10 mt-3 w-36 origin-top-right overflow-hidden rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                            role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                            <div class="py-1" role="none">
                                <!-- Active: "bg-gray-100 text-gray-900", Not Active: "text-gray-700" -->
                                <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                    id="progress_tab">Progress</a>
                                <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                    id="tracker_tab">Tracker</a>                            
                            </div>
                        </div>
                    </div>
                    <div class="ml-6 h-6 w-px bg-gray-300"></div>
                    <button type="button"
                        class="ml-6 rounded-md bg-fuchsia-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-fuchsia-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-fuchsia-500">Add
                        event</button>
                </div>
                <div class="relative ml-6 md:hidden">
                    <button type="button"
                        class="-mx-2 flex items-center rounded-full border border-transparent p-2 text-gray-400 hover:text-gray-500"
                        id="menu-0-button" aria-expanded="false" aria-haspopup="true">
                        <span class="sr-only">Open menu</span>
                        <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path
                                d="M3 10a1.5 1.5 0 113 0 1.5 1.5 0 01-3 0zM8.5 10a1.5 1.5 0 113 0 1.5 1.5 0 01-3 0zM15.5 8.5a1.5 1.5 0 100 3 1.5 1.5 0 000-3z" />
                        </svg>
                    </button>
    
                    <!--
                Dropdown menu, show/hide based on menu state.
      
                Entering: "transition ease-out duration-100"
                  From: "transform opacity-0 scale-95"
                  To: "transform opacity-100 scale-100"
                Leaving: "transition ease-in duration-75"
                  From: "transform opacity-100 scale-100"
                  To: "transform opacity-0 scale-95"
              -->
                    <div class="absolute right-0 z-10 mt-3 w-36 origin-top-right divide-y divide-gray-100 overflow-hidden rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                        role="menu" aria-orientation="vertical" aria-labelledby="menu-0-button" tabindex="-1">
                        <div class="py-1" role="none">
                            <!-- Active: "bg-gray-100 text-gray-900", Not Active: "text-gray-700" -->
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-0-item-0">Create event</a>
                        </div>
                        <div class="py-1" role="none">
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-0-item-1">Go to today</a>
                        </div>
                        <div class="py-1" role="none">
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-0-item-2">Day view</a>
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-0-item-3">Week view</a>
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-0-item-4">Month view</a>
                            <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1"
                                id="menu-0-item-5">Year view</a>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <div class="isolate flex flex-auto overflow-hidden bg-white">
            <div class="flex flex-auto flex-col overflow-auto">
                <div
                    class="sticky top-0 z-10 grid flex-none grid-cols-7 bg-white text-xs text-gray-500 shadow ring-1 ring-black ring-opacity-5 md:hidden">
                    <button type="button" class="flex flex-col items-center pb-1.5 pt-3">
                        <span>W</span>
                        <!-- Default: "text-gray-900", Selected: "bg-gray-900 text-white", Today (Not Selected): "text-fuchsia-600", Today (Selected): "bg-fuchsia-600 text-white" -->
                        <span
                            class="mt-3 flex h-8 w-8 items-center justify-center rounded-full text-base font-semibold text-gray-900">19</span>
                    </button>
                    <button type="button" class="flex flex-col items-center pb-1.5 pt-3">
                        <span>T</span>
                        <span
                            class="mt-3 flex h-8 w-8 items-center justify-center rounded-full text-base font-semibold text-fuchsia-600">20</span>
                    </button>
                    <button type="button" class="flex flex-col items-center pb-1.5 pt-3">
                        <span>F</span>
                        <span
                            class="mt-3 flex h-8 w-8 items-center justify-center rounded-full text-base font-semibold text-gray-900">21</span>
                    </button>
                    <button type="button" class="flex flex-col items-center pb-1.5 pt-3">
                        <span>S</span>
                        <span
                            class="mt-3 flex h-8 w-8 items-center justify-center rounded-full bg-gray-900 text-base font-semibold text-white">22</span>
                    </button>
                    <button type="button" class="flex flex-col items-center pb-1.5 pt-3">
                        <span>S</span>
                        <span
                            class="mt-3 flex h-8 w-8 items-center justify-center rounded-full text-base font-semibold text-gray-900">23</span>
                    </button>
                    <button type="button" class="flex flex-col items-center pb-1.5 pt-3">
                        <span>M</span>
                        <span
                            class="mt-3 flex h-8 w-8 items-center justify-center rounded-full text-base font-semibold text-gray-900">24</span>
                    </button>
                    <button type="button" class="flex flex-col items-center pb-1.5 pt-3">
                        <span>T</span>
                        <span
                            class="mt-3 flex h-8 w-8 items-center justify-center rounded-full text-base font-semibold text-gray-900">25</span>
                    </button>
                </div>
                <div class="flex w-full flex-auto">
                    <div class="w-14 flex-none bg-white ring-1 ring-gray-100"></div>
                    <div class="grid flex-auto grid-cols-1 grid-rows-1">
                        <!-- Horizontal lines -->
                        <div class="col-start-1 col-end-2 row-start-1 grid divide-y divide-gray-100"
                            style="grid-template-rows: repeat(24, minmax(3.5rem, 1fr))">
                            <div class="row-end-1 h-7"></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">7AM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">8AM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">9AM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">10AM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">11AM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">12PM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">1PM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">2PM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">3PM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">4PM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">5PM</div>
                            </div>
                            <div></div>
                            <div>
                                <div class="-ml-14 -mt-2.5 w-14 pr-2 text-right text-xs leading-5 text-gray-400">6PM</div>
                            </div>
                            <div></div>                        
                        </div>
    
                        <!-- Events -->
                        <ol class="academic-progresses-ol col-start-1 col-end-2 row-start-1 grid grid-cols-1"
                            style="grid-template-rows: 1.75rem repeat(144, minmax(0, 1fr)) auto">
                            
                        </ol>
                    </div>
                </div>
            </div>
            <div class="hidden w-1/2 max-w-md flex-none border-l border-gray-100 px-8 py-10 md:block">
                <div class="flex items-center text-center text-gray-900">
                    <button type="button"
                        class="prev-month-btn -m-1.5 flex flex-none items-center justify-center p-1.5 text-gray-400 hover:text-gray-500">
                        <span class="sr-only">Previous month</span>
                        <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path fill-rule="evenodd"
                                d="M12.79 5.23a.75.75 0 01-.02 1.06L8.832 10l3.938 3.71a.75.75 0 11-1.04 1.08l-4.5-4.25a.75.75 0 010-1.08l4.5-4.25a.75.75 0 011.06.02z"
                                clip-rule="evenodd" />
                        </svg>
                    </button>
                    <div class="month-year-div flex-auto text-sm font-semibold">${MONTHS[this.#date.getMonth()]} ${this.#date.getFullYear()}</div>
                    <button type="button"
                        class="next-month-btn -m-1.5 flex flex-none items-center justify-center p-1.5 text-gray-400 hover:text-gray-500">
                        <span class="sr-only">Next month</span>
                        <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path fill-rule="evenodd"
                                d="M7.21 14.77a.75.75 0 01.02-1.06L11.168 10 7.23 6.29a.75.75 0 111.04-1.08l4.5 4.25a.75.75 0 010 1.08l-4.5 4.25a.75.75 0 01-1.06-.02z"
                                clip-rule="evenodd" />
                        </svg>
                    </button>
                </div>
                <div class="mt-6 grid grid-cols-7 text-center text-xs leading-6 text-gray-500">
                    <div>M</div>
                    <div>T</div>
                    <div>W</div>
                    <div>T</div>
                    <div>F</div>
                    <div>S</div>
                    <div>S</div>
                </div>
                <div
                    class="calendar-container isolate mt-2 grid grid-cols-7 gap-px rounded-lg bg-gray-200 text-sm shadow ring-1 ring-gray-200">
                    <!--
                Always include: "py-1.5 hover:bg-gray-100 focus:z-10"
                Is current month, include: "bg-white"
                Is not current month, include: "bg-gray-50"
                Is selected or is today, include: "font-semibold"
                Is selected, include: "text-white"
                Is not selected, is not today, and is current month, include: "text-gray-900"
                Is not selected, is not today, and is not current month, include: "text-gray-400"
                Is today and is not selected, include: "text-fuchsia-600"
      
                Top left day, include: "rounded-tl-lg"
                Top right day, include: "rounded-tr-lg"
                Bottom left day, include: "rounded-bl-lg"
                Bottom right day, include: "rounded-br-lg"
              -->
                    <button type="button"
                        class="rounded-tl-lg bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <!--
                  Always include: "mx-auto flex h-7 w-7 items-center justify-center rounded-full"
                  Is selected and is today, include: "bg-fuchsia-600"
                  Is selected and is not today, include: "bg-gray-900"
                -->
                        <time datetime="2021-12-27"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">27</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2021-12-28"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">28</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2021-12-29"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">29</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2021-12-30"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">30</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2021-12-31"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">31</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-01"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">1</time>
                    </button>
                    <button type="button" class="rounded-tr-lg bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-02"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">2</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-03"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">3</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-04"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">4</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-05"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">5</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-06"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">6</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-07"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">7</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-08"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">8</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-09"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">9</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-10"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">10</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-11"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">11</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-12"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">12</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-13"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">13</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-14"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">14</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-15"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">15</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-16"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">16</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-17"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">17</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-18"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">18</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-19"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">19</time>
                    </button>
                    <button type="button"
                        class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-20"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">20</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-21"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">21</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-22"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">22</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-23"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">23</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-24"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">24</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-25"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">25</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-26"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">26</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-27"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">27</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-28"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">28</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-29"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">29</time>
                    </button>
                    <button type="button" class="bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-30"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">30</time>
                    </button>
                    <button type="button" class="rounded-bl-lg bg-white py-1.5 text-gray-900 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-01-31"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">31</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-02-01"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">1</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-02-02"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">2</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-02-03"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">3</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-02-04"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">4</time>
                    </button>
                    <button type="button" class="bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-02-05"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">5</time>
                    </button>
                    <button type="button"
                        class="rounded-br-lg bg-gray-50 py-1.5 text-gray-400 hover:bg-gray-100 focus:z-10">
                        <time datetime="2022-02-06"
                            class="mx-auto flex h-7 w-7 items-center justify-center rounded-full">6</time>
                    </button>
                </div>
            </div>
        </div>
    </div>    
        `;
    }
}

customElements.define("academic-progress", AcademicProgressComponent);