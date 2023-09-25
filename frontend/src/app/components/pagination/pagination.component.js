import paginationService from "./pagination.service";

export class PaginationComponent extends HTMLElement {

  #paginationContainer;
  #next;
  #previous;
  #slides;
  #currentPage = 0;
  #totalPages;

  constructor() {
    super();
    paginationService.subscribe("reset", {
      component: this,
      eventHandler: this.#reset
    })
  }

  // calculateTranslateX(step) {
  //   const currentIndex = parseInt(this.#ecList.style.transform.match(/translateX\((.*?)%\)/)[1]) || 0;
  //   const newIndex = currentIndex + step * 100; // Di chuyển mỗi lần một slide (100%)
  //   return Math.max(Math.min(newIndex, 0), -((extraClasses.length - 1) / 9) * 100); // Giới hạn giá trị translateX
  // }

  connectedCallback() {
    this.innerHTML = this.#render();
    this.#paginationContainer = document.querySelector(".pagination-container");
    this.#previous = document.querySelector("#previous");
    this.#next = document.querySelector("#next");
    this.#slides = document.querySelectorAll(".slide");
    this.#totalPages = this.#slides.length;


    this.#previous.addEventListener("click", function (event) {

      if (this.#currentPage - 1 < 0) {
        return;
      } else {
        this.#currentPage--;
      }

      this.#slides.forEach(currentElemet => {
        const temp = currentElemet.style.transform.split("(")[1];
        const length = temp.length;
        const value = temp.slice(0, length - 2);
        const num = Number(value);
        currentElemet.style.transform = `translateX(${num + 100}%)`;

      });

    }.bind(this));

    this.#next.addEventListener("click", function (event) {
      
      if (this.#currentPage + 1 == this.#totalPages) {
        return;
      } else {
        this.#currentPage++;
      }

      this.#slides.forEach(currentElemet => {
        const temp = currentElemet.style.transform.split("(")[1];
        const length = temp.length;
        const value = temp.slice(0, length - 2);
        const num = Number(value);
        currentElemet.style.transform = `translateX(${num - 100}%)`;


      });

    }.bind(this));


    this.#paginationContainer.addEventListener("click", function (event) {
      const clicked = event.target.closest("a");
      if (!clicked) {
        return;
      }
      const linksArr = this.#paginationContainer.querySelectorAll("a");
      linksArr.forEach(a => {
        a.classList.remove(..."border-fuchsia-500 text-fuchsia-600".split(" "));
        a.classList.add(..."border-transparent text-gray-700 hover:text-gray-800 hover:border-gray-300".split(" "));
      });
      clicked.classList.remove(..."border-transparent text-gray-700 hover:text-gray-800 hover:border-gray-300".split(" "));
      clicked.classList.add(..."border-fuchsia-500 text-fuchsia-600".split(" "));
    }.bind(this));
  }

  disconnectedCallback() {
    paginationService.unSubscribe("reset", this);
  }

  #reset(data) {
    this.#currentPage = 0;
    this.#slides = document.querySelectorAll(".slide");
  }

  #render() {
    return `
  <div class="w-full -mt-2">
    <nav class="flex items-center justify-between mx-5">
        <div class="-mt-px flex w-0 flex-1">
          <a href="#" id="previous" class="prev-btn inline-flex items-center border-t-2 border-transparent pr-1 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800">
            <svg class="mr-3 h-5 w-5 text-gray-600" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
              <path fill-rule="evenodd" d="M18 10a.75.75 0 01-.75.75H4.66l2.1 1.95a.75.75 0 11-1.02 1.1l-3.5-3.25a.75.75 0 010-1.1l3.5-3.25a.75.75 0 111.02 1.1l-2.1 1.95h12.59A.75.75 0 0118 10z" clip-rule="evenodd" />
            </svg>
            Previous
          </a>
        </div>
        <div class="hidden md:-mt-px md:flex pagination-container">
          <a href="#" class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800">1</a>
          <!-- Current: "border-fuchsia-500 text-fuchsia-600", Default: "border-transparent text-gray-700 hover:text-gray-800 hover:border-gray-300" -->
          <a href="#" class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800" aria-current="page">2</a>
          <a href="#" class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800">3</a>
          <span class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-700">...</span>
          <a href="#" class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800">8</a>
          <a href="#" class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800">9</a>
          <a href="#" class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800">10</a>
        </div>
        <div class="-mt-px flex w-0 flex-1 justify-end">
          <a href="#" id="next" class="next-btn inline-flex items-center border-t-2 border-transparent pl-1 pt-4 text-sm font-medium text-gray-700 hover:border-gray-300 hover:text-gray-800">
            Next
            <svg class="ml-3 h-5 w-5 text-gray-600" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
              <path fill-rule="evenodd" d="M2 10a.75.75 0 01.75-.75h12.59l-2.1-1.95a.75.75 0 111.02-1.1l3.5 3.25a.75.75 0 010 1.1l-3.5 3.25a.75.75 0 11-1.02-1.1l2.1-1.95H2.75A.75.75 0 012 10z" clip-rule="evenodd" />
            </svg>
          </a>
        </div>
    </nav>
  </div>
        `;
  }
}

customElements.define("app-pagination", PaginationComponent);