import dataService from "../../../../services/data.service";
import { data } from "../../../../app.store";
import studentEcService from "./student-ec.service";
import { StudentExtraClassQuickviewComponent } from "../../../modal/quickview-modal/student-ec-quickview.component";
import { OverlayComponent } from "../../../overlay/overlay.component";
import { isExtraClassFull, isExtraClassFull, isExtraClassRegistered } from "../../../../helpers/util.helper";
import paginationService from "../../../pagination/pagination.service";

export class StudentExtraClassGridComponent extends HTMLElement {

  #ecList;
  #extraClasses;

  constructor() {
    super();
    this.#extraClasses = data.extraClasses;
    studentEcService.subscribe("refreshEcGrid", {
      component: this,
      eventHandler: this.#displayExtraClasses
    });
    
  }

  // calculateTranslateX(step) {
  //   const currentIndex = parseInt(this.#ecList.style.transform.match(/translateX\((.*?)%\)/)[1]) || 0;
  //   const newIndex = currentIndex + step * 100; // Di chuyển mỗi lần một slide (100%)
  //   return Math.max(Math.min(newIndex, 0), -((extraClasses.length - 1) / 9) * 100); // Giới hạn giá trị translateX
  // }

  connectedCallback() {
    this.innerHTML = this.#render();
    this.#ecList = document.querySelector(".ec-list");
    
    this.#displayExtraClasses(this.#extraClasses);

    this.#ecList.addEventListener("click", function (event) {
      const clicked = event.target.closest(".view-detail-btn") || event.target.closest(".register-btn");
      if (!clicked) {
        return;
      }
      document.querySelector("student-ec").insertAdjacentHTML("afterend", `
        <app-overlay se-class="bg-gray-900/[.85] dark:bg-gray-600/75"></app-overlay>
      `);
      const studentEcQuickview = new StudentExtraClassQuickviewComponent(document.querySelector("app-overlay"));
      document.querySelector(".overlay-wrapper").insertAdjacentElement("beforeend", studentEcQuickview);
      setTimeout(function () {
        studentEcQuickview.entering();
      }, 100);
      const extraClass = this.#extraClasses.find(ec => ec.id == clicked.dataset.ec);
      studentEcService.trigger("showQuickview", extraClass);
    }.bind(this));

  }

  disconnectedCallback() {
    studentEcService.unSubscribe("refreshEcGrid", this);
  }

  #render() {
    return `
        <div class="w-full">

            <student-ec-filter></student-ec-filter>

            <div class="ec-list slider flex gap-6 mb-6">

            </div>
        </div>
        `;
  }

  #displayExtraClasses(extraClasses) {
    setTimeout(function () {
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

      this.#ecList.nextElementSibling ?? this.#ecList.parentElement.insertAdjacentHTML("beforeend", `<app-pagination></app-pagination>`);
      paginationService.trigger("reset", null);
    }.bind(this), 100);

    
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
    extraClass.total = extraClass.students.length;
    const isRegisterDisabled = isExtraClassRegistered(extraClass, data.currentUser.student.extraClasses) || isExtraClassFull(extraClass);
    const isExtraClassAvailable = !isExtraClassFull(extraClass);
    const isExtraClassNotRegistered = !isExtraClassRegistered(extraClass, data.currentUser.student.extraClasses);
    return `
    <div class="rounded-lg bg-gray-100/60 basis-1/3">
      <div class="flex w-full items-center justify-between space-x-6 p-6">
        <div class="w-full">
          <div class="flex items-center justify-between space-x-3">
            <div class="flex items-center gap-5">
              <div>
                <h3 class="truncate text-base font-medium text-gray-900">${extraClass.name}</h3>
                <div class="flex items-center gap-2 mt-1">
                  <span>
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-4 h-4 text-indigo-500">
                      <path d="M4.5 6.375a4.125 4.125 0 118.25 0 4.125 4.125 0 01-8.25 0zM14.25 8.625a3.375 3.375 0 116.75 0 3.375 3.375 0 01-6.75 0zM1.5 19.125a7.125 7.125 0 0114.25 0v.003l-.001.119a.75.75 0 01-.363.63 13.067 13.067 0 01-6.761 1.873c-2.472 0-4.786-.684-6.76-1.873a.75.75 0 01-.364-.63l-.001-.122zM17.25 19.128l-.001.144a2.25 2.25 0 01-.233.96 10.088 10.088 0 005.06-1.01.75.75 0 00.42-.643 4.875 4.875 0 00-6.957-4.611 8.586 8.586 0 011.71 5.157v.003z" />
                    </svg>                
                  </span>
                  <p class="text-xs text-gray-500">${extraClass.total} / ${extraClass.capacity}</p>
                </div>
              </div>
              <span class="inline-flex items-center gap-x-1.5 rounded-md ${isExtraClassAvailable ? "bg-green-100" : "bg-red-100"} px-1.5 py-0.5 text-xs font-medium ${isExtraClassAvailable ? "text-green-700" : "text-gren-700"}">
                <svg class="h-1.5 w-1.5 ${isExtraClassAvailable ? "fill-green-500" : "fill-red-500"}" viewBox="0 0 6 6" aria-hidden="true">
                  <circle cx="3" cy="3" r="3" />
                </svg>
                ${isExtraClassAvailable ? "Available" : "Fullslot"}
              </span>
            </div>
            <div>
              <img class="h-10 w-10 flex-shrink-0 rounded bg-gray-300" src="${extraClass.image}" alt="${extraClass.name}">
            </div>
          </div>
          <p class="mt-4 text-sm text-gray-500 line-clamp-3">${extraClass.description}</p>
        </div>
      </div>
      <div>
        <div class="-mt-px flex">
          <div class="flex w-0 flex-1">
            <a href="#" class="view-detail-btn relative -mr-px inline-flex w-0 flex-1 items-center justify-center gap-x-3 rounded-bl-lg py-4 text-sm font-semibold text-gray-900" data-ec="${extraClass.id}">
              <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-sky-500">
                  <path d="M4.5 3.75a3 3 0 00-3 3v.75h21v-.75a3 3 0 00-3-3h-15z" />
                  <path fill-rule="evenodd" d="M22.5 9.75h-21v7.5a3 3 0 003 3h15a3 3 0 003-3v-7.5zm-18 3.75a.75.75 0 01.75-.75h6a.75.75 0 010 1.5h-6a.75.75 0 01-.75-.75zm.75 2.25a.75.75 0 000 1.5h3a.75.75 0 000-1.5h-3z" clip-rule="evenodd" />
              </svg>        
              Details
            </a>
          </div>
          <div class="-ml-px flex w-0 flex-1">
            <a href="#" class="register-btn relative inline-flex w-0 flex-1 items-center justify-center gap-x-3 rounded-br-lg py-4 text-sm font-semibold ${isRegisterDisabled ? "text-gray-400 pointer-events-none" : "text-gray-900"}" data-ec="${extraClass.id}">
              <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 ${isRegisterDisabled ? "text-gray-400" : "text-orange-500"}">
                  <path fill-rule="evenodd" d="M17.303 5.197A7.5 7.5 0 006.697 15.803a.75.75 0 01-1.061 1.061A9 9 0 1121 10.5a.75.75 0 01-1.5 0c0-1.92-.732-3.839-2.197-5.303zm-2.121 2.121a4.5 4.5 0 00-6.364 6.364.75.75 0 11-1.06 1.06A6 6 0 1118 10.5a.75.75 0 01-1.5 0c0-1.153-.44-2.303-1.318-3.182zm-3.634 1.314a.75.75 0 01.82.311l5.228 7.917a.75.75 0 01-.777 1.148l-2.097-.43 1.045 3.9a.75.75 0 01-1.45.388l-1.044-3.899-1.601 1.42a.75.75 0 01-1.247-.606l.569-9.47a.75.75 0 01.554-.68z" clip-rule="evenodd" />
              </svg>              
              ${isExtraClassNotRegistered ? "Register" : "Registered"}
            </a>
          </div>
        </div>
      </div>
    </div>
      `;
  }
}

customElements.define("student-ec-grid", StudentExtraClassGridComponent);