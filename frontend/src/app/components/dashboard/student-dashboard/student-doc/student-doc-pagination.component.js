import studentDocService from "./student-doc.service";

export class StudentDocumentPaginationComponent extends HTMLElement {

    #currentPage = 1;
    #totalPages;
    #nextBtn;
    #prevBtn;

    constructor() {
        super();
        studentDocService.subscribe("totalPages", {
            component: this,
            eventHandler: this.#display
        })
    }

    connectedCallback() {
        this.innerHTML = this.#render();
        this.#nextBtn = this.querySelector(".next-btn");
        this.#prevBtn = this.querySelector(".prev-btn");

        this.#nextBtn.addEventListener("click", function() {
            console.log("next :)");
        }.bind(this));

        this.#prevBtn.addEventListener("click", function() {
            console.log("prev :)");
        }.bind(this));
    }

    disconnectedCallback() {
        studentDocService.unSubscribe("totalPages", this);
    }

    #display(totalPages) {
        this.#totalPages = totalPages;
    }

    #render() {
        return `
    <nav class="flex items-center justify-between mt-6 px-4 sm:px-4">
        <div class="-mt-px flex w-0 flex-1">
            <a href="#"
                class="prev-btn inline-flex items-center border-t-2 border-transparent pr-1 pt-4 text-sm font-medium text-gray-500 hover:border-gray-300 hover:text-gray-700">
                <svg class="mr-3 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                    <path fill-rule="evenodd"
                        d="M18 10a.75.75 0 01-.75.75H4.66l2.1 1.95a.75.75 0 11-1.02 1.1l-3.5-3.25a.75.75 0 010-1.1l3.5-3.25a.75.75 0 111.02 1.1l-2.1 1.95h12.59A.75.75 0 0118 10z"
                        clip-rule="evenodd" />
                </svg>
                Previous
            </a>
        </div>
        <div class="hidden md:-mt-px md:flex">
            <a href="#"
                class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-500 hover:border-gray-300 hover:text-gray-700">1</a>
            <!-- Current: "border-fuchsia-500 text-fuchsia-600", Default: "border-transparent text-gray-500 hover:text-gray-700 hover:border-gray-300" -->
            <a href="#"
                class="inline-flex items-center border-t-2 border-fuchsia-500 px-4 pt-4 text-sm font-medium text-fuchsia-600"
                aria-current="page">2</a>
            <a href="#"
                class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-500 hover:border-gray-300 hover:text-gray-700">3</a>
            <span
                class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-500">...</span>
            <a href="#"
                class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-500 hover:border-gray-300 hover:text-gray-700">8</a>
            <a href="#"
                class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-500 hover:border-gray-300 hover:text-gray-700">9</a>
            <a href="#"
                class="inline-flex items-center border-t-2 border-transparent px-4 pt-4 text-sm font-medium text-gray-500 hover:border-gray-300 hover:text-gray-700">10</a>
        </div>
        <div class="-mt-px flex w-0 flex-1 justify-end">
            <a href="#"
                class="next-btn inline-flex items-center border-t-2 border-transparent pl-1 pt-4 text-sm font-medium text-gray-500 hover:border-gray-300 hover:text-gray-700">
                Next
                <svg class="ml-3 h-5 w-5 text-gray-400" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                    <path fill-rule="evenodd"
                        d="M2 10a.75.75 0 01.75-.75h12.59l-2.1-1.95a.75.75 0 111.02-1.1l3.5 3.25a.75.75 0 010 1.1l-3.5 3.25a.75.75 0 11-1.02-1.1l2.1-1.95H2.75A.75.75 0 012 10z"
                        clip-rule="evenodd" />
                </svg>
            </a>
        </div>
    </nav>
        `;
    }
}

customElements.define("student-doc-pagination", StudentDocumentPaginationComponent);