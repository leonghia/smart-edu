import dataService from "../../../../services/data.service";
import { getExtraClasses, saveExtraClasses } from "../../../../app.store";

export class StudentExtraClassComponent extends HTMLElement {

    #ecList;

    constructor() {
        super();
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#ecList = document.querySelector(".ec-list");
        if (getExtraClasses().length === 0) {
          dataService.getExtraClasses()
            .then(res => {
              saveExtraClasses(res.data);
              this.#displayExtraClasses(getExtraClasses());
            });
        } else {
          this.#displayExtraClasses(getExtraClasses());
        }    

        
    }

    disconnectedCallback() {

    }

    #render() {
        return `
<div class="max-w-7xl">
  <div class="ec-list slider flex gap-6 mb-6">

    <!-- More classes... -->
  </div>
</div>

        `;
    }

    #displayExtraClasses(extraClasses) {
      setTimeout(function() {
        this.#ecList.innerHTML = "";
        extraClasses.forEach((currentElement, currentIndex) => {

          if (currentIndex === 0) {
            this.#ecList.insertAdjacentHTML("beforeend", `
              <div class="slide" style="transform: translateX(0%);">
                <div class="flex items-center justify-center gap-6 mb-6"><div>
              </div>
            `);
            this.#ecList.lastElementChild.lastElementChild.firstElementChild.remove();
          } 

          if (currentIndex !== 0 && currentIndex % 9 === 0) {
            this.#ecList.insertAdjacentHTML("beforeend", `
              <div class="slide" style="transform: translateX(${100 * currentIndex / 9}%);">
                <div class="flex items-center justify-center gap-6 mb-6"><div>
              </div>
            `);
            this.#ecList.lastElementChild.lastElementChild.firstElementChild.remove();
          }

          if (currentIndex % 3 === 0 && currentIndex % 9 !== 0) {
            this.#ecList.lastElementChild.insertAdjacentHTML("beforeend", `
              <div class="flex items-center justify-center gap-6 mb-6"></div>
            `);
          }

          this.#ecList.lastElementChild.lastElementChild.insertAdjacentHTML("beforeend", this.#renderExtraClass(currentElement));
        });

        this.#ecList.parentElement.insertAdjacentHTML("beforeend", `<app-pagination></app-pagination>`);
      }.bind(this), 500);
      this.#ecList.innerHTML = "";
      this.#ecList.innerHTML = `
        <div class="absolute -translate-x-1/2 -translate-y-1/2 top-2/4 left-1/2">
        </div>
        `;
      this.#ecList.firstElementChild.innerHTML = `
            <loading-spinner se-class ="w-10 h-10 mr-10 text-gray-400"></loading-spinner>
        `;
    }

    #renderExtraClass(extraClass) {
      return `
    <div class="divide-y divide-gray-200 rounded-lg bg-white shadow-nghia basis-1/3">
      <div class="flex w-full items-center justify-between space-x-6 p-6">
        <div class="w-full">
          <div class="flex items-center justify-between space-x-3">
            <div class="flex items-center gap-3">
              <h3 class="truncate text-sm font-medium text-gray-900">${extraClass.name}</h3>
              <span class="inline-flex flex-shrink-0 items-center rounded-full bg-green-50 px-1.5 py-0.5 text-xs font-medium text-green-700 ring-1 ring-inset ring-green-600/20">Available</span>
            </div>
            <div>
              <img class="h-10 w-10 flex-shrink-0 rounded bg-gray-300" src="${extraClass.image}" alt="${extraClass.name}">
            </div>
          </div>
          <p class="mt-4 text-sm text-gray-500">${extraClass.description.slice(0, 150)}.....</p>
        </div>
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
    </div>
      `;
    }
}

customElements.define("student-ec", StudentExtraClassComponent);

