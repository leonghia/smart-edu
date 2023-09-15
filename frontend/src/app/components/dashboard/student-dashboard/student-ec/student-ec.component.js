export class StudentExtraClassComponent extends HTMLElement {
    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
<ul role="list" class="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3">
  <li class="col-span-1 divide-y divide-gray-200 rounded-lg bg-white shadow-nghia">
    <div class="flex w-full items-center justify-between space-x-6 p-6">
      <div class="flex-1 truncate">
        <div class="flex items-center space-x-3">
          <h3 class="truncate text-sm font-medium text-gray-900">Jane Cooper</h3>
          <span class="inline-flex flex-shrink-0 items-center rounded-full bg-green-50 px-1.5 py-0.5 text-xs font-medium text-green-700 ring-1 ring-inset ring-green-600/20">Admin</span>
        </div>
        <p class="mt-1 truncate text-sm text-gray-500">Regional Paradigm Technician</p>
      </div>
      <img class="h-10 w-10 flex-shrink-0 rounded-full bg-gray-300" src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=4&w=256&h=256&q=60" alt="">
    </div>
    <div>
      <div class="-mt-px flex divide-x divide-gray-200">
        <div class="flex w-0 flex-1">
          <a href="mailto:janecooper@example.com" class="relative -mr-px inline-flex w-0 flex-1 items-center justify-center gap-x-3 rounded-bl-lg border border-transparent py-4 text-sm font-semibold text-gray-900">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-sky-500">
                <path d="M4.5 3.75a3 3 0 00-3 3v.75h21v-.75a3 3 0 00-3-3h-15z" />
                <path fill-rule="evenodd" d="M22.5 9.75h-21v7.5a3 3 0 003 3h15a3 3 0 003-3v-7.5zm-18 3.75a.75.75 0 01.75-.75h6a.75.75 0 010 1.5h-6a.75.75 0 01-.75-.75zm.75 2.25a.75.75 0 000 1.5h3a.75.75 0 000-1.5h-3z" clip-rule="evenodd" />
            </svg>        
            Details
          </a>
        </div>
        <div class="-ml-px flex w-0 flex-1">
          <a href="tel:+1-202-555-0170" class="relative inline-flex w-0 flex-1 items-center justify-center gap-x-3 rounded-br-lg border border-transparent py-4 text-sm font-semibold text-gray-900">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-orange-500">
                <path fill-rule="evenodd" d="M17.303 5.197A7.5 7.5 0 006.697 15.803a.75.75 0 01-1.061 1.061A9 9 0 1121 10.5a.75.75 0 01-1.5 0c0-1.92-.732-3.839-2.197-5.303zm-2.121 2.121a4.5 4.5 0 00-6.364 6.364.75.75 0 11-1.06 1.06A6 6 0 1118 10.5a.75.75 0 01-1.5 0c0-1.153-.44-2.303-1.318-3.182zm-3.634 1.314a.75.75 0 01.82.311l5.228 7.917a.75.75 0 01-.777 1.148l-2.097-.43 1.045 3.9a.75.75 0 01-1.45.388l-1.044-3.899-1.601 1.42a.75.75 0 01-1.247-.606l.569-9.47a.75.75 0 01.554-.68z" clip-rule="evenodd" />
            </svg>              
            Register
          </a>
        </div>
      </div>
    </div>
  </li>

  <!-- More people... -->
</ul>
        `;
    }

}

customElements.define("student-ec", StudentExtraClassComponent);

