import { data } from "../../../../app.store";
import dataService from "../../../../services/data.service";
import { RequestParams } from "../../../../models/requestParams";
import { DEFAULT_DOC_DES } from "../../../../app.config";
import studentDocService from "./student-doc.service";
import { DocumentFilterRequestParams } from "../../../../models/docFilterRequestParams";
import { displayRating } from "../../../../helpers/util.helper";

export class StudentDocumentGridComponent extends HTMLElement {

    #documents = [];
    #filterOption = new DocumentFilterRequestParams();

    constructor() {
        super();
        studentDocService.subscribe("next", {
            component: this,
            eventHandler: this.#display
        });
        studentDocService.subscribe("prev", {
            component: this,
            eventHandler: this.#display
        });
        studentDocService.subscribe("displayFilterResult", {
            component: this,
            eventHandler: this.#handleDisplayFilterResult
        });
    }

    connectedCallback() {
        this.#display(1);
        dataService.getDocumentsCount()
            .then(res => {
                studentDocService.trigger("totalPages", Math.ceil(res.data / 10));
            });
    }

    disconnectedCallback() {
        studentDocService.unSubscribe("next", this);
        studentDocService.unSubscribe("prev", this);
        studentDocService.unSubscribe("displayFilterResult", this);
    }

    #handleDisplayFilterResult(filterOption)
    {
        this.#filterOption = filterOption;
        this.#display();
    }

    #display(page = 1) {
        dataService.getDocuments(new RequestParams(10, page), this.#filterOption)
            .then(res => {
                data.documents = res.data;
                this.#documents = data.documents;
                this.innerHTML = this.#render();
            });
        this.innerHTML = "";
        this.innerHTML = `
        <div class="absolute -translate-x-1/2 -translate-y-1/2 top-2/4 left-[60%]">
        </div>        
        `;
        this.firstElementChild.innerHTML = `
        <loading-spinner se-class ="w-10 h-10 mr-10 text-gray-400"></loading-spinner>
        `;
    }

    #render() {
        return `
        <div class="grid grid-cols-1 gap-y-4 sm:grid-cols-2 sm:gap-x-6 sm:gap-y-10 lg:grid-cols-2 lg:gap-x-8">
            ${this.#renderDocuments(this.#documents)}
        </div>
        `;
    }

    #renderDocuments(documents = []) {
        return documents.reduce((accumulator, currentValue) => accumulator + this.#renderDocument(currentValue), "");
    }

    #renderDocument(document) {
        return `
    <article class="relative isolate flex flex-col gap-8 lg:flex-row bg-gray-100/80 p-6 rounded-xl">
        <div class="relative aspect-[16/9] sm:aspect-[2/1] lg:aspect-square lg:w-44 lg:shrink-0">
            <img src="${document.image}"
                alt="" class="absolute right-0 h-full rounded bg-gray-50 object-cover">
            <div class="absolute inset-0 rounded-2xl ring-0 ring-inset ring-gray-900/10"></div>
        </div>
        <div>
            <div class="flex items-center gap-x-4 text-xs">
                <time datetime="2020-03-16" class="text-gray-500">Sep 16, 2023</time>
                <a href="#"
                    class="relative z-10 rounded-md bg-indigo-100 px-3 py-1.5 font-medium text-indigo-700">${document.teacher.subject.name}</a>
            </div>
            <div class="group relative max-w-xl">
                <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                    <a href="#">
                        <span class="absolute inset-0"></span>
                        ${document.name}
                    </a>
                </h3>
                <div class="mt-3 flex items-center">
                    <!-- Active: "text-yellow-400", Default: "text-gray-300" -->
                    ${displayRating(document.rating)}
                    <span class="ml-4 flex items-center gap-x-1">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="w-4 h-4 text-sky-500">
                            <path fill-rule="evenodd" d="M7.5 6a4.5 4.5 0 119 0 4.5 4.5 0 01-9 0zM3.751 20.105a8.25 8.25 0 0116.498 0 .75.75 0 01-.437.695A18.683 18.683 0 0112 22.5c-2.786 0-5.433-.608-7.812-1.7a.75.75 0 01-.437-.695z" clip-rule="evenodd" />
                        </svg>                  
                        <p class="text-sm text-gray-500">${document.numbersOfRating} ratings</p>
                    </span>
                </div>
                <p class="mt-4 text-sm leading-6 text-gray-600 line-clamp-3">${document.description || DEFAULT_DOC_DES}</p>
            </div>
            <div class="mt-6 flex border-t border-gray-900/5 pt-6">
                <div class="relative flex items-center gap-x-4">
                    <img src="${document.teacher.user.profileImage}"
                        alt="" class="h-10 w-10 rounded-full bg-gray-50">
                    <div class="text-sm leading-6">
                        <p class="font-semibold text-gray-900">
                            <a href="#">
                                <span class="absolute inset-0"></span>
                                ${document.teacher.user.fullName}
                            </a>
                        </p>
                        <p class="text-gray-600">${document.teacher.user.email}</p>
                    </div>
                </div>
            </div>
        </div>
    </article>
        `;
    }
}

customElements.define("student-doc-grid", StudentDocumentGridComponent);