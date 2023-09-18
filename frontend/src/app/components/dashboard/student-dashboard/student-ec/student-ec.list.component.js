import { data } from "../../../../app.store";
import { convertDateTimeToVn } from "../../../../helpers/datetime.helper";
import studentEcService from "./student-ec.service";

export class StudentExtraClassListComponent extends HTMLElement {

    #extraClasses;

    constructor() {
        super();
        this.#extraClasses = data.currentUser.student.extraClasses;
        
        // studentEcService.subscribe("bookmarked", {
        //     component: this,
        //     eventHandler: this.#displayBookmarkedExtraClasses
        // });
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#displayRegisteredExtraClasses(this.#extraClasses);
        this.#displayBookmarkedExtraClasses();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
<div class="h-1/2 overflow-x-hidden overflow-y-scroll">
    <div class="pb-1">
        <h3 class="text-base font-semibold leading-6 text-fuchsia-600">📁 Registered Classes</h3>
        <p class="mt-2 max-w-4xl text-sm text-gray-500">Listing all the extra classes you have successfully registered. From here you can cancel any class you would want to. Note that sometimes, the teacher can also remove you from the class if you don't behave properly.</p>
    </div>
    <div>
        <ul role="list" class="relative your-registered-ec divide-y divide-dashed divide-gray-400">
            
            
        </ul>
    </div>   
</div>   

<div class="h-1/2 overflow-x-hidden overflow-y-scroll">
    <div class="pb-1">
        <h3 class="text-base font-semibold leading-6 text-fuchsia-600">📌 Bookmarked Classes</h3>
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
            <h3 class="mt-2 text-sm font-semibold text-gray-900">No extra classes</h3>
            <p class="mt-1 text-sm text-gray-500">Get started by registering an extra class.</p>      
        </div>
            `);
                return;
            }
            extraClasses.forEach(ec => {
                ul.insertAdjacentHTML("beforeend", this.#renderItem(ec));
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
            <h3 class="mt-2 text-sm font-semibold text-gray-900">No bookmarked extra classes</h3>
            <p class="mt-1 text-sm text-gray-500">Get started by adding a bookmarked class.</p>      
        </div>
          
            `);
                return;
            }
            extraClasses.forEach(ec => {
                ul.insertAdjacentHTML("beforeend", this.#renderItem(ec));
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

    #renderItem(extraClass) {
        const e = data.extraClasses.find(ec => ec.id == extraClass.id);
        return `
    <li class="flex items-center justify-between gap-x-6 py-5">
        <div class="min-w-0">
            <div class="flex items-start gap-x-3">
            <p class="text-sm font-semibold leading-6 text-gray-900">${e.name}</p>
            
            </div>
            <div class="mt-1 flex items-center gap-x-2 text-xs leading-5 text-gray-500">
            <p class="whitespace-nowrap">Scheduled on <time datetime="">${e.from} - ${e.to} (${e.weekday})</time></p>
            <svg viewBox="0 0 2 2" class="h-0.5 w-0.5 fill-current">
                <circle cx="1" cy="1" r="1" />
            </svg>
            <p class="truncate">Taught by teacher ${e.teacher.user.fullName}</p>
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
                <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-0-item-0">Edit<span class="sr-only">, GraphQL API</span></a>
                <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-0-item-1">Move<span class="sr-only">, GraphQL API</span></a>
                <a href="#" class="block px-3 py-1 text-sm leading-6 text-gray-900" role="menuitem" tabindex="-1" id="options-menu-0-item-2">Delete<span class="sr-only">, GraphQL API</span></a>
            </div>
            </div>
        </div>
    </li>
        `;
    }
}

customElements.define("student-ec-list", StudentExtraClassListComponent);