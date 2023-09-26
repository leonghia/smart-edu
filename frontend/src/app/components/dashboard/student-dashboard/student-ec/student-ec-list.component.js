import { data } from "../../../../app.store";
import { hideDropdown, showDropdown } from "../../../../helpers/animation.helper";
import { trimMillisecondsFromTime } from "../../../../helpers/datetime.helper";
import studentEcService from "./student-ec.service";
import { StudentExtraClassQuickviewComponent } from "../../../modal/quickview-modal/student-ec-quickview.component";
import { WEEKDAYS } from "../../../../app.enum";
import { DeleteModalComponent } from "../../../modal/delete-modal/delete-modal.component";
import { BASE_URL } from "../../../../app.config";
import { UnregisterExtraClassModalComponent } from "./unregister-ec-modal.component";
import dataService from "../../../../services/data.service";

export class StudentExtraClassListComponent extends HTMLElement {

    #extraClasses;
    #registeredUl;
    #bookmarkedUl;
    #state = {
        state: false,
    }
    #ecBookmark;

    constructor() {
        super();
        this.#extraClasses = data.currentUser.student.extraClasses;
        this.#ecBookmark = data.currentUser.student.ecBookmark;

        studentEcService.subscribe("refreshEcListReg", {
            component: this,
            eventHandler: this.#displayRegisteredExtraClasses
        });

        studentEcService.subscribe("refreshEcListBook", {
            component: this,
            eventHandler: this.#displayBookmarkedExtraClasses
        });

    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#displayRegisteredExtraClasses(this.#extraClasses);
        this.#displayBookmarkedExtraClasses(this.#ecBookmark.extraClasses);
        this.#registeredUl = this.querySelector(".your-registered-ec");
        this.#bookmarkedUl = this.querySelector(".your-bookmarked-ec");

        this.#bookmarkedUl.addEventListener("click", function (event) {
            const clicked = event.target.closest("button") || event.target.closest(".registered-ec-details") || event.target.closest(".registered-ec-action");
            if (!clicked) {
                return;
            }

            const extraClassId = Number(clicked.dataset.ec);

            if (event.target.closest("button")) {
                const dropdown = clicked.nextElementSibling;
                const items = Array.from(dropdown.querySelectorAll("a"));
                if (this.#state.state === false) {
                    showDropdown(dropdown, items, this.#state);
                } else {
                    hideDropdown(dropdown, items, this.#state);
                }
                return;
            }

            const dropdown = clicked.parentElement;
            const items = Array.from(dropdown.querySelectorAll("a"));
            const extraClass = data.extraClasses.find(ec => ec.id === extraClassId);

            if (event.target.closest(".registered-ec-details")) {
                document.querySelector("student-ec").insertAdjacentHTML("afterend", `
        <app-overlay se-class="bg-gray-900/[.85] dark:bg-gray-600/75"></app-overlay>
            `);
                const overlay = document.querySelector("app-overlay");
                const overlayWrapper = document.querySelector(".overlay-wrapper");
                const studentEcQuickview = new StudentExtraClassQuickviewComponent(overlay);
                overlayWrapper.insertAdjacentElement("beforeend", studentEcQuickview);
                setTimeout(function () {
                    studentEcQuickview.entering();
                }, 100);
                studentEcService.trigger("showQuickviewRegistered", extraClass);
                hideDropdown(dropdown, items, this.#state);
                return;
            }

            if (event.target.closest(".registered-ec-action")) {
                const deleteExtraClassEcBookmarkDTO = {
                    ecBookmarkId: data.currentUser.student.ecBookmark.id,
                    extraClassId: extraClassId
                };
                dataService.unbookmarkExtraClass(deleteExtraClassEcBookmarkDTO)
                    .then(res => {
                        if (res.succeeded) {
                            const index = data.currentUser.student.ecBookmark.extraClasses.findIndex(ec => ec.id === extraClassId);
                            data.currentUser.student.ecBookmark.extraClasses.splice(index, 1);
                            this.#displayBookmarkedExtraClasses(data.currentUser.student.ecBookmark.extraClasses);
                        }
                    });
                hideDropdown(dropdown, items, this.#state);
                return;
            }

        }.bind(this));

        this.#registeredUl.addEventListener("click", function (event) {

            const clicked = event.target.closest("button") || event.target.closest(".registered-ec-details") || event.target.closest(".registered-ec-action");
            if (!clicked) {
                return;
            }

            if (event.target.closest("button")) {
                const dropdown = clicked.nextElementSibling;
                const items = Array.from(dropdown.querySelectorAll("a"));
                if (this.#state.state === false) {
                    showDropdown(dropdown, items, this.#state);
                } else {
                    hideDropdown(dropdown, items, this.#state);
                }
                return;
            }

            const dropdown = clicked.parentElement;
            const items = Array.from(dropdown.querySelectorAll("a"));
            const extraClass = data.extraClasses.find(ec => ec.id === Number(clicked.dataset.ec));
            document.querySelector("student-ec").insertAdjacentHTML("afterend", `
        <app-overlay se-class="bg-gray-900/[.85] dark:bg-gray-600/75"></app-overlay>
            `);

            const overlay = document.querySelector("app-overlay");
            const overlayWrapper = document.querySelector(".overlay-wrapper");

            if (event.target.closest(".registered-ec-details")) {
                const studentEcQuickview = new StudentExtraClassQuickviewComponent(overlay);
                overlayWrapper.insertAdjacentElement("beforeend", studentEcQuickview);
                setTimeout(function () {
                    studentEcQuickview.entering();
                }, 100);
                studentEcService.trigger("showQuickviewRegistered", extraClass);
                hideDropdown(dropdown, items, this.#state);
                return;
            }

            if (event.target.closest(".registered-ec-action")) {
                const option = {
                    overlay: overlay,
                    title: "Unregister extra class",
                    description: "Are you sure want to unregister this extra class? Please note that your parent and the teacher will also know about it. This action cannot be undone.",
                    cta: "Unregister",
                    url: `${BASE_URL}/`,
                    deleteDataDTO: {
                        studentId: data.currentUser.student.id,
                        extraClassId: Number(clicked.dataset.ec)
                    },
                };
                const unregisterEcModal = new UnregisterExtraClassModalComponent(option);
                overlayWrapper.insertAdjacentElement("beforeend", unregisterEcModal);
                hideDropdown(dropdown, items, this.#state);
                return;
            }

        }.bind(this));

    }

    disconnectedCallback() {
        studentEcService.unSubscribe("refreshEcListReg", this);
        studentEcService.unSubscribe("refreshEcListBook", this);
    }

    #render() {
        return `
<div class="h-1/2 overflow-x-hidden overflow-y-scroll bg-green-50 rounded-lg p-6">
    <div class="pb-1">
        <h3 class="text-base font-semibold leading-6 text-green-600">Registered Classes</h3>
        <p class="mt-2 max-w-4xl text-sm text-gray-500">Listing all the extra classes you have successfully registered. From here you can cancel any class you would want to. Note that sometimes, the teacher can also remove you from the class if you don't behave properly.</p>
    </div>
    <div>
        <ul role="list" class="relative your-registered-ec divide-y divide-dashed divide-gray-400">
            
            
        </ul>
    </div>   
</div>   

<div class="h-1/2 overflow-x-hidden overflow-y-scroll bg-blue-50 rounded-lg p-6">
    <div class="pb-1">
        <h3 class="text-base font-semibold leading-6 text-blue-600">Bookmarked Classes</h3>
        <p class="mt-2 max-w-4xl text-sm text-gray-500">Discover and curate your learning journey with our Bookmarked feature. Easily mark and organize the classes that inspire you the most, making it simple to revisit and continue your educational adventure at your own pace.</p>
    </div>
    <div>
        <ul role="list" class="relative your-bookmarked-ec divide-y divide-dashed divide-gray-400">
            
            
        </ul>
    </div>   
</div>
        `;
    }

    #displayRegisteredExtraClasses(extraClasses = []) {

        const ul = this.querySelector(".your-registered-ec");

        setTimeout(function () {
            ul.classList.remove("h-32");
            ul.innerHTML = "";
            if (extraClasses.length === 0) {
                ul.insertAdjacentHTML("beforeend", `
        <div class="text-center mt-4">
            <svg class="mx-auto h-12 w-12 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" aria-hidden="true">
              <path vector-effect="non-scaling-stroke" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 13h6m-3-3v6m-9 1V7a2 2 0 012-2h6l2 2h6a2 2 0 012 2v8a2 2 0 01-2 2H5a2 2 0 01-2-2z" />
            </svg>
            <h3 class="mt-2 text-sm font-semibold text-gray-900">No extra classes registered</h3>
            <p class="mt-1 text-sm text-gray-500">Get started by registering an extra class.</p>      
        </div>
            `);
                return;
            }
            extraClasses.forEach(ec => {
                ul.insertAdjacentHTML("beforeend", this.#renderItem(ec, 0));
            });
        }.bind(this), 100);

        ul.classList.add("h-32");
        ul.innerHTML = `
        <div class="absolute -translate-x-1/2 -translate-y-1/2 top-2/4 left-1/2">
        </div>
        `;
        ul.firstElementChild.innerHTML = `
            <loading-spinner se-class ="w-10 h-10 mr-10 text-gray-400"></loading-spinner>
        `;

    }

    #displayBookmarkedExtraClasses(extraClasses = []) {
        const ul = this.querySelector(".your-bookmarked-ec");

        setTimeout(function () {
            ul.classList.remove("h-32");
            ul.innerHTML = "";
            if (extraClasses.length === 0) {
                ul.insertAdjacentHTML("beforeend", `
        <div class="text-center mt-4">
            <svg class="mx-auto h-12 w-12 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor" aria-hidden="true">
              <path vector-effect="non-scaling-stroke" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 13h6m-3-3v6m-9 1V7a2 2 0 012-2h6l2 2h6a2 2 0 012 2v8a2 2 0 01-2 2H5a2 2 0 01-2-2z" />
            </svg>
            <h3 class="mt-2 text-sm font-semibold text-gray-900">No extra classes bookmarked</h3>
            <p class="mt-1 text-sm text-gray-500">Get started by bookmarking an extra class.</p>      
        </div>
          
            `);
                return;
            }
            extraClasses.forEach(ec => {
                ul.insertAdjacentHTML("beforeend", this.#renderItem(ec, 1));
            });
        }.bind(this), 100);

        ul.classList.add("h-32");

        ul.innerHTML = `
        <div class="absolute -translate-x-1/2 -translate-y-1/2 top-2/4 left-1/2">
        </div>
        `;

        ul.firstElementChild.innerHTML = `
            <loading-spinner se-class ="w-10 h-10 mr-10 text-gray-400"></loading-spinner>
        `;
    }

    #renderItem(extraClass, regOrBook = 0) {
        const e = data.extraClasses.find(ec => ec.id == extraClass.id);
        return `
    <li class="flex items-center justify-between gap-x-6 py-5">
        <div class="min-w-0">
            <div class="flex items-start gap-x-3">
            <p class="text-sm font-semibold leading-6 text-gray-900">${e.name}</p>
            
            </div>
            <div class="mt-2 flex flex-col gap-y-2 text-xs leading-5 text-gray-500">
                <div class="flex items-center gap-x-2">
                    <span>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-amber-500">
                            <path d="M12.75 12.75a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM7.5 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM8.25 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM9.75 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM10.5 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM12 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM12.75 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM14.25 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM15 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM16.5 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM15 12.75a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM16.5 13.5a.75.75 0 100-1.5.75.75 0 000 1.5z" />
                            <path fill-rule="evenodd" d="M6.75 2.25A.75.75 0 017.5 3v1.5h9V3A.75.75 0 0118 3v1.5h.75a3 3 0 013 3v11.25a3 3 0 01-3 3H5.25a3 3 0 01-3-3V7.5a3 3 0 013-3H6V3a.75.75 0 01.75-.75zm13.5 9a1.5 1.5 0 00-1.5-1.5H5.25a1.5 1.5 0 00-1.5 1.5v7.5a1.5 1.5 0 001.5 1.5h13.5a1.5 1.5 0 001.5-1.5v-7.5z" clip-rule="evenodd" />
                        </svg>                  
                    </span>
                    <p class="whitespace-nowrap">Scheduled on <time datetime="">${trimMillisecondsFromTime(e.from)} - ${trimMillisecondsFromTime(e.to)} (${WEEKDAYS[e.weekday]})</time></p>
                </div>
                <div class="flex items-center gap-x-2">
                    <span>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-cyan-500">
                            <path d="M11.7 2.805a.75.75 0 01.6 0A60.65 60.65 0 0122.83 8.72a.75.75 0 01-.231 1.337 49.949 49.949 0 00-9.902 3.912l-.003.002-.34.18a.75.75 0 01-.707 0A50.009 50.009 0 007.5 12.174v-.224c0-.131.067-.248.172-.311a54.614 54.614 0 014.653-2.52.75.75 0 00-.65-1.352 56.129 56.129 0 00-4.78 2.589 1.858 1.858 0 00-.859 1.228 49.803 49.803 0 00-4.634-1.527.75.75 0 01-.231-1.337A60.653 60.653 0 0111.7 2.805z" />
                            <path d="M13.06 15.473a48.45 48.45 0 017.666-3.282c.134 1.414.22 2.843.255 4.285a.75.75 0 01-.46.71 47.878 47.878 0 00-8.105 4.342.75.75 0 01-.832 0 47.877 47.877 0 00-8.104-4.342.75.75 0 01-.461-.71c.035-1.442.121-2.87.255-4.286A48.4 48.4 0 016 13.18v1.27a1.5 1.5 0 00-.14 2.508c-.09.38-.222.753-.397 1.11.452.213.901.434 1.346.661a6.729 6.729 0 00.551-1.608 1.5 1.5 0 00.14-2.67v-.645a48.549 48.549 0 013.44 1.668 2.25 2.25 0 002.12 0z" />
                            <path d="M4.462 19.462c.42-.419.753-.89 1-1.394.453.213.902.434 1.347.661a6.743 6.743 0 01-1.286 1.794.75.75 0 11-1.06-1.06z" />
                        </svg>                  
                    </span>
                    <p class="truncate">Taught by teacher ${e.teacher.user.fullName}</p>
                </div>
            </div>
        </div>
        <div class="flex flex-none items-center gap-x-4">
            
            <div class="relative flex-none">
            <button type="button" class="-m-2.5 block p-2.5 text-gray-500 hover:text-gray-900" id="options-menu-0-button" aria-expanded="false" aria-haspopup="true">
                <span class="sr-only">Open options</span>
                <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                <path d="M10 3a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM10 8.5a1.5 1.5 0 110 3 1.5 1.5 0 010-3zM11.5 15.5a1.5 1.5 0 10-3 0 1.5 1.5 0 003 0z" />
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
            <div class="opacity-0 absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md bg-white py-2 shadow-lg ring-1 ring-gray-900/5 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="options-menu-0-button" tabindex="-1">
                <!-- Active: "bg-gray-50", Not Active: "" -->
                <a href="#" data-ec="${extraClass.id}" class="registered-ec-details block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-0-item-0">Details<span class="sr-only">, Details</span></a>
                <a href="#" data-ec="${extraClass.id}" class="registered-ec-action block px-3 py-1 text-sm leading-6 text-red-500" role="menuitem" tabindex="-1" id="options-menu-0-item-1">${regOrBook === 0 ? "Unregister" : "Unbookmark"}<span class="sr-only">, ${regOrBook === 0 ? "Unregister" : "Unbookmark"}</span></a>          
            </div>
            </div>
        </div>
    </li>
        `;
    }
}

customElements.define("student-ec-list", StudentExtraClassListComponent);