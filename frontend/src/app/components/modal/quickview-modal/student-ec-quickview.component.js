import { data } from "../../../app.store";
import dataService from "../../../services/data.service";
import studentEcService from "../../dashboard/student-dashboard/student-ec/student-ec.service";
import { SuccessModalComponent } from "../success-modal/success-modal.component";
import { trimMillisecondsFromTime } from "../../../helpers/datetime.helper.js";
import { checkIfEcIsBookmarked, isExtraClassFull, isExtraClassRegistered } from "../../../helpers/util.helper";
import { WEEKDAYS } from "../../../app.enum";

export class StudentExtraClassQuickviewComponent extends HTMLElement {

  #modal;
  #closeBtn;
  #registerBtn;
  #overlayComponent;
  #bookmarkBtn;

  constructor(overlayComponent) {
    super();
    this.#overlayComponent = overlayComponent;
    studentEcService.subscribe("showQuickview", {
      component: this,
      eventHandler: this.handleShowQuickview
    });
    studentEcService.subscribe("showQuickviewRegistered", {
      component: this,
      eventHandler: this.handleShowQuickview
    });
  }

  connectedCallback() {

  }

  disconnectedCallback() {
    studentEcService.unSubscribe("showQuickview", this);
    studentEcService.unSubscribe("showQuickviewRegistered", this);
  }

  #render(extraClass) {
    const isRegisterDisabled = isExtraClassFull(extraClass) || isExtraClassRegistered(extraClass, data.currentUser.student.extraClasses);
    const isExtraClassAvailable = !isExtraClassFull(extraClass);
    const isExtraClassNotRegistered = !isExtraClassRegistered(extraClass, data.currentUser.student.extraClasses);
    const isExtraClassBookmarked = checkIfEcIsBookmarked(extraClass, data.currentUser.student.ecBookmark);
    return `
    <div class="modal opacity-0 translate-y-4 md:translate-y-0 md:scale-95 flex w-full transform text-left text-base transition md:my-8 md:max-w-2xl md:px-4 lg:max-w-4xl">
        <div class="rounded-lg relative flex w-full items-center overflow-hidden bg-white px-4 pb-8 pt-14 shadow-2xl sm:px-6 sm:pt-8 md:p-6 lg:p-8">
          <button type="button" class="close-quickview-btn absolute right-4 top-4 text-gray-400 hover:text-gray-500 sm:right-6 sm:top-8 md:right-6 md:top-6 lg:right-8 lg:top-8">
            <span class="sr-only">Close</span>
            <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
              <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
            </svg>
          </button>

          <div class="grid w-full grid-cols-1 items-start gap-x-6 gap-y-8 sm:grid-cols-12 lg:gap-x-8">
            <div class="sm:col-span-4 lg:col-span-5">
              <div class="aspect-h-1 aspect-w-1 overflow-hidden rounded-lg bg-gray-100">
                <img src="${extraClass.image}" alt="${extraClass.name}" class="object-cover object-center">
              </div>
            </div>
            <div class="sm:col-span-8 lg:col-span-7">
              <h2 class="text-2xl font-bold text-gray-900 sm:pr-12 flex items-center gap-x-4">
              ${extraClass.name}
              <span class="inline-flex items-center gap-x-1.5 rounded-md ${isExtraClassAvailable ? "bg-green-100" : "bg-red-100"} px-2 py-1 text-xs font-medium ${isExtraClassAvailable ? "text-green-700" : "text-red-700"}">
                <svg class="h-1.5 w-1.5 ${isExtraClassAvailable ? "fill-green-500" : "fill-red-500"}" viewBox="0 0 6 6" aria-hidden="true">
                  <circle cx="3" cy="3" r="3" />
                </svg>
                ${isExtraClassAvailable ? "Available" : "Fullslot"}
              </span>
              </h2>
              
              <section aria-labelledby="information-heading" class="mt-3">
                

                <!-- Reviews -->

                <div class="mt-6 flex w-full flex-none gap-x-8 border-t border-gray-900/5 pt-6">
                  <div class="flex gap-x-2">
                    <dt class="flex-none">
                      <span class="sr-only">Client</span>
                      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="text-indigo-500 w-5 h-5">
                        <path d="M4.5 6.375a4.125 4.125 0 118.25 0 4.125 4.125 0 01-8.25 0zM14.25 8.625a3.375 3.375 0 116.75 0 3.375 3.375 0 01-6.75 0zM1.5 19.125a7.125 7.125 0 0114.25 0v.003l-.001.119a.75.75 0 01-.363.63 13.067 13.067 0 01-6.761 1.873c-2.472 0-4.786-.684-6.76-1.873a.75.75 0 01-.364-.63l-.001-.122zM17.25 19.128l-.001.144a2.25 2.25 0 01-.233.96 10.088 10.088 0 005.06-1.01.75.75 0 00.42-.643 4.875 4.875 0 00-6.957-4.611 8.586 8.586 0 011.71 5.157v.003z" />
                      </svg>

                    </dt>
                    <dd class="text-sm font-medium leading-6 text-gray-900">${extraClass.total} / ${extraClass.capacity} students</dd>
                  </div>

                  <div class="flex gap-x-2">
                    <dt class="flex-none">
                      <span class="sr-only">Client</span>
                      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-amber-500">
                        <path d="M12.75 12.75a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM7.5 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM8.25 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM9.75 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM10.5 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM12 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM12.75 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM14.25 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM15 17.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM16.5 15.75a.75.75 0 100-1.5.75.75 0 000 1.5zM15 12.75a.75.75 0 11-1.5 0 .75.75 0 011.5 0zM16.5 13.5a.75.75 0 100-1.5.75.75 0 000 1.5z" />
                        <path fill-rule="evenodd" d="M6.75 2.25A.75.75 0 017.5 3v1.5h9V3A.75.75 0 0118 3v1.5h.75a3 3 0 013 3v11.25a3 3 0 01-3 3H5.25a3 3 0 01-3-3V7.5a3 3 0 013-3H6V3a.75.75 0 01.75-.75zm13.5 9a1.5 1.5 0 00-1.5-1.5H5.25a1.5 1.5 0 00-1.5 1.5v7.5a1.5 1.5 0 001.5 1.5h13.5a1.5 1.5 0 001.5-1.5v-7.5z" clip-rule="evenodd" />
                      </svg>

                    </dt>
                    <dd class="text-sm font-medium leading-6 text-gray-900">${trimMillisecondsFromTime(extraClass.from)} - ${trimMillisecondsFromTime(extraClass.to)} (${WEEKDAYS[extraClass.weekday]})</dd>
                  </div>
                 
                </div>

                <div class="mt-6">
                  <h4 class="sr-only">Description</h4>

                  <p class="text-sm text-gray-700">${extraClass.description}</p>
                </div>

                <div class="flex space-x-3 mt-5">
                  <div class="flex-shrink-0">
                    <img class="h-10 w-10 rounded-full" src="${extraClass.teacher.user.profileImage}" alt="${extraClass.teacher.user.fullName}">
                  </div>
                  <div class="min-w-0 flex-1">
                    <p class="text-sm font-semibold text-gray-900">
                      <a href="#" class="hover:underline">Teacher ${extraClass.teacher.user.fullName}</a>
                    </p>
                    <p class="text-sm text-gray-500">
                      <a href="#">${extraClass.teacher.user.email}</a>
                    </p>
                  </div>
	              </div>

              </section>

              <section aria-labelledby="options-heading" class="mt-6">
                <h3 id="options-heading" class="sr-only">Product options</h3>

                <form>
                  <!-- Colors -->
                  

                  <div class="mt-6">
                    <button type="button" id="register_btn" class="flex w-full items-center justify-center rounded-md border border-transparent ${isRegisterDisabled ? "bg-gray-400 pointer-events-none" : "bg-fuchsia-600 hover:bg-fuchsia-700"} px-8 py-3 text-base font-medium text-white focus:outline-none focus:ring-2 focus:ring-fuchsia-500 focus:ring-offset-2 focus:ring-offset-gray-50">${isExtraClassNotRegistered ? "Register now" : "Already registered"}</button>
                  </div>

                  <div class="mt-6">
                    <button type="button" id="bookmark_btn" class="${isExtraClassBookmarked ? "pointer-events-none" : ""} flex w-full items-center justify-center rounded-md border border-transparent ${isExtraClassBookmarked ? "bg-gray-400" : "bg-fuchsia-50"} px-8 py-3 text-base font-medium ${isExtraClassBookmarked ? "text-white" : "text-fuchsia-600"} hover:bg-fuchsia-100 focus:outline-none focus:ring-fuchsia-500 focus:ring-offset-2 focus:ring-offset-gray-50">${isExtraClassBookmarked ? "Already saved to bookmark" : "Save to bookmark"}</button>
                  </div>
                </form>
              </section>
            </div>
          </div>
        </div>
    </div>
        `;
  }

  entering() {
    this.#modal = this.querySelector(".modal");
    this.#modal.classList.remove(..."ease-in duration-300".split(" "));
    this.#modal.classList.add(..."ease-out duration-500".split(" "));
    this.#modal.classList.remove(..."opacity-0 translate-y-4 md:translate-y-0 md:scale-95".split(" "));
    this.#modal.classList.add(..."opacity-100 translate-y-0 md:scale-100".split(" "));
  }

  leaving() {
    this.#modal.classList.remove(..."ease-out duration-500".split(" "));
    this.#modal.classList.add(..."ease-in duration-300".split(" "));
    this.#modal.classList.remove(..."opacity-100 translate-y-0 md:scale-100".split(" "));
    this.#modal.classList.add(..."opacity-0 translate-y-4 md:translate-y-0 md:scale-95".split(" "));

  }

  handleShowQuickview(extraClass) {
    this.innerHTML = this.#render(extraClass);

    this.#modal = this.querySelector(".modal");
    this.#closeBtn = this.querySelector(".close-quickview-btn");
    this.#registerBtn = this.querySelector("#register_btn");
    this.#bookmarkBtn = this.querySelector("#bookmark_btn");

    this.#bookmarkBtn.addEventListener("click", function () {

      setTimeout(() => {
        dataService.bookmarkExtraClass({
          ecBookmarkId: data.currentUser.student.ecBookmark.id,
          extraClassId: extraClass.id
        }).then(res => {
          if (res.succeeded) {
            this.#bookmarkBtn.innerHTML = `
        <span class="flex items-center mr-2">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-5 h-5 text-fuchsia-500">
            <path fill-rule="evenodd" d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm13.36-1.814a.75.75 0 10-1.22-.872l-3.236 4.53L9.53 12.22a.75.75 0 00-1.06 1.06l2.25 2.25a.75.75 0 001.14-.094l3.75-5.25z" clip-rule="evenodd" />
          </svg>
        </span>
        Saved to bookmark
        `;
            this.#bookmarkBtn.classList.add("pointer-events-none");
            data.currentUser.student.ecBookmark.extraClasses.push(extraClass);
            studentEcService.trigger("refreshEcListBook", data.currentUser.student.ecBookmark.extraClasses);
          }
        });

      }, 500);

      this.#bookmarkBtn.textContent = "Saving...";
      this.#bookmarkBtn.insertAdjacentHTML("afterbegin", `
      <span class="flex items-center">
        <loading-spinner se-class="mr-3 w-4 h-4 text-gray-300"></loading-spinner>
      </span>
      `);
    }.bind(this));

    this.#registerBtn.addEventListener("click", function () {

      data.currentUser.student.extraClasses.forEach(currentElement => {
        //Kiem tra xem co bi trung weekday khong
        if (extraClass.weekday == currentElement.weekday) {
          return;
        }

        //Neu bi trung weekday, kiem tra tiep thoi gian
        if (extraClass.from == currentElement.from && extraClass.to == currentElement.to) {
          return;
        }
      });

      const isDuplicated = data.currentUser.student.extraClasses.some(currentElement => currentElement.weekday === extraClass.weekday && currentElement.from === extraClass.from && currentElement.to === extraClass.to);

      if (isDuplicated) {
        alert("Register failed 😭: Duplicated schedule");
        return;
      }

      const addExtraClassStudentDTO = {
        studentId: data.currentUser.student.id,
        extraClassId: extraClass.id
      };
      dataService.registerExtraClass(addExtraClassStudentDTO)
        .then(res => {
          this.#registerBtn.firstElementChild.remove();
          this.#registerBtn.textContent = "Register now";

          dataService.getStudent(data.currentUser.student.id)
            .then(res => {
              const extraClasses = res.data.extraClasses;
              data.currentUser.student.extraClasses = extraClasses;
              studentEcService.trigger("refreshEcListReg", extraClasses);
              studentEcService.trigger("refreshEcGrid", data.extraClasses);
            });


          // Close the quickview modal
          this.leaving();
          setTimeout(function () {
            this.remove();
            // Show the successful modal
            const successModalComponent = new SuccessModalComponent("Register successfully", "We're thrilled to have you on board and look forward to an enriching learning journey together. Get ready to explore new horizons and acquire valuable knowledge. 📚🤩", this.#overlayComponent);
            this.#overlayComponent.overlayWrapper.insertAdjacentElement("beforeend", successModalComponent);
            setTimeout(function () {
              successModalComponent.entering();
            }.bind(this), 50);
          }.bind(this), 500);

        });

      this.#registerBtn.textContent = "Registering......";
      this.#registerBtn.setAttribute("disabled", "");
      this.#registerBtn.insertAdjacentHTML("afterbegin", `
      <span class="flex items-center">
        <loading-spinner se-class="mr-3 w-4 h-4 text-gray-100"></loading-spinner>
      </span>
      `);

    }.bind(this));

    this.#closeBtn.addEventListener("click", function () {
      this.leaving();
      this.#overlayComponent.leaving();
      setTimeout(function () {
        this.remove();
        this.#overlayComponent.remove();
      }.bind(this), 500);
    }.bind(this));
  }
}

customElements.define("student-ec-quickview", StudentExtraClassQuickviewComponent);