export class StudentExtraClassNewComponent extends HTMLElement {

    #extraClassGrid;

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#extraClassGrid = document.querySelector(".extra-class-grid");
        const extraClassMarkup = `
            <li class="col-span-1 divide-y divide-gray-200 rounded-lg bg-white shadow-lg">
                <div class="flex w-full items-center justify-between space-x-6 p-6">
                <div class="flex-1">
                    <div class="flex items-center space-x-3">
                    <h3 class="truncate text-sm font-medium text-gray-900">Maths M2208-10</h3>
                    <span class="inline-flex flex-shrink-0 items-center rounded-full bg-green-50 px-1.5 py-0.5 text-xs font-medium text-green-700 ring-1 ring-inset ring-green-600/20">Available</span>
                    </div>
                    <p class="mt-1 text-sm text-gray-500">How to analyze mathematical models, including variables, constants, and parameters.</p>
                </div>
                <img class="h-10 w-10 flex-shrink-0 rounded-full bg-gray-300" src="https://img.freepik.com/premium-vector/back-school-banner-with-hand-drawn-line-art-icons-education_602612-136.jpg?w=360" alt="">
                </div>
                <div>
                <div class="-mt-px flex divide-x divide-gray-200">
                    <div class="flex w-0 flex-1">
                    <a href="mailto:janecooper@example.com" class="relative -mr-px inline-flex w-0 flex-1 items-center justify-center gap-x-3 rounded-bl-lg border border-transparent py-4 text-sm font-semibold text-gray-900">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-orange-500">
                            <path fill-rule="evenodd" d="M2.25 6a3 3 0 013-3h13.5a3 3 0 013 3v12a3 3 0 01-3 3H5.25a3 3 0 01-3-3V6zm3.97.97a.75.75 0 011.06 0l2.25 2.25a.75.75 0 010 1.06l-2.25 2.25a.75.75 0 01-1.06-1.06l1.72-1.72-1.72-1.72a.75.75 0 010-1.06zm4.28 4.28a.75.75 0 000 1.5h3a.75.75 0 000-1.5h-3z" clip-rule="evenodd" />
                        </svg>               
                        Details
                    </a>
                    </div>
                    <div class="-ml-px flex w-0 flex-1">
                    <a href="tel:+1-202-555-0170" class="relative inline-flex w-0 flex-1 items-center justify-center gap-x-3 rounded-br-lg border border-transparent py-4 text-sm font-semibold text-gray-900">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-sky-500">
                            <path d="M21.731 2.269a2.625 2.625 0 00-3.712 0l-1.157 1.157 3.712 3.712 1.157-1.157a2.625 2.625 0 000-3.712zM19.513 8.199l-3.712-3.712-8.4 8.4a5.25 5.25 0 00-1.32 2.214l-.8 2.685a.75.75 0 00.933.933l2.685-.8a5.25 5.25 0 002.214-1.32l8.4-8.4z" />
                            <path d="M5.25 5.25a3 3 0 00-3 3v10.5a3 3 0 003 3h10.5a3 3 0 003-3V13.5a.75.75 0 00-1.5 0v5.25a1.5 1.5 0 01-1.5 1.5H5.25a1.5 1.5 0 01-1.5-1.5V8.25a1.5 1.5 0 011.5-1.5h5.25a.75.75 0 000-1.5H5.25z" />
                        </svg>         
                        Register
                    </a>
                    </div>
                </div>
                </div>
            </li>
        `;
        for (let i = 0; i < 50; i++) {
            this.#extraClassGrid.insertAdjacentHTML("beforeend", extraClassMarkup);
        }
    }

    disconnectedCallback() {

    }

    #render() {
        return `
        <div class="mx-auto max-w-7xl sm:px-6 lg:px-8 overflow-scroll" style="max-height: 90vh;">
            <div class="pb-5 sm:flex sm:items-center sm:justify-between">
                <h3 class="text-base font-semibold leading-6 text-gray-900">New Extra Classes</h3>
                <div class="mt-3 sm:ml-4 sm:mt-0">
                <label for="mobile-search-candidate" class="sr-only">Search</label>
                <label for="desktop-search-candidate" class="sr-only">Search</label>
                <div class="flex rounded-md shadow-sm">
                    <div class="relative flex-grow focus-within:z-10">
                    <div class="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-3">
                        <svg class="h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                        <path fill-rule="evenodd" d="M9 3.5a5.5 5.5 0 100 11 5.5 5.5 0 000-11zM2 9a7 7 0 1112.452 4.391l3.328 3.329a.75.75 0 11-1.06 1.06l-3.329-3.328A7 7 0 012 9z" clip-rule="evenodd" />
                        </svg>
                    </div>
                    <input type="text" name="mobile-search-candidate" id="mobile-search-candidate" class="block w-full rounded-none rounded-l-md border-0 py-1.5 pl-10 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:hidden" placeholder="Search">
                    <input type="text" name="desktop-search-candidate" id="desktop-search-candidate" class="hidden w-full rounded-none rounded-l-md border-0 py-1.5 pl-10 text-sm leading-6 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:block" placeholder="Search classes....">
                    </div>
                    <button type="button" class="relative -ml-px inline-flex items-center gap-x-1.5 rounded-r-md px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50">
                    <svg class="-ml-0.5 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                        <path fill-rule="evenodd" d="M2 3.75A.75.75 0 012.75 3h11.5a.75.75 0 010 1.5H2.75A.75.75 0 012 3.75zM2 7.5a.75.75 0 01.75-.75h6.365a.75.75 0 010 1.5H2.75A.75.75 0 012 7.5zM14 7a.75.75 0 01.55.24l3.25 3.5a.75.75 0 11-1.1 1.02l-1.95-2.1v6.59a.75.75 0 01-1.5 0V9.66l-1.95 2.1a.75.75 0 11-1.1-1.02l3.25-3.5A.75.75 0 0114 7zM2 11.25a.75.75 0 01.75-.75H7A.75.75 0 017 12H2.75a.75.75 0 01-.75-.75z" clip-rule="evenodd" />
                    </svg>
                    Sort
                    <svg class="-mr-1 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                        <path fill-rule="evenodd" d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z" clip-rule="evenodd" />
                    </svg>
                    </button>
                </div>
                </div>
            </div>
            <ul role="list" class="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3 mt-8 extra-class-grid">

            <!-- More people... -->
            </ul>
        </div> 
        `;
    }
}

customElements.define("student-ec-new", StudentExtraClassNewComponent);