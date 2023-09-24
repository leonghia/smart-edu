import { data } from "../../../../app.store";
import dataService from "../../../../services/data.service";

export class StudentDocumentComponent extends HTMLElement {

    #documents = [];

    constructor() {
        super();
        
    }

    connectedCallback() {
        if (data.documents.length === 0) {
            dataService.getDocuments()
                .then(res => {
                    data.documents = res.data;
                    this.#documents = data.documents;
                    this.innerHTML = this.#render(this.#documents);
                });
        } else {
            this.#documents = data.documents;
            this.innerHTML = this.#render(this.#documents);
        }
    }

    disconnectedCallback() {

    }

    #render(documents) {
        return `
    <div class="bg-white w-full h-full">
        <div class="w-full h-full flex gap-x-8">
            <div class="w-1/5 h-full"></div>
            <div class="w-4/5 h-full">             
                <div class="grid grid-cols-1 gap-y-4 sm:grid-cols-2 sm:gap-x-6 sm:gap-y-10 lg:grid-cols-2 lg:gap-x-8 mt-16 lg:mt-10">
                    ${documents.forEach(d => this.#renderDocument(d))}
                </div>
            </div>
        </div>
    </div>   
        `;
    }

    #renderDocument(document) {
        return `
    <article class="relative isolate flex flex-col gap-8 lg:flex-row">
        <div class="relative aspect-[16/9] sm:aspect-[2/1] lg:aspect-square lg:w-44 lg:shrink-0">
            <img src="https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1547125681i/24113._SY300_.jpg"
                alt="" class="absolute right-0 h-full rounded bg-gray-50 object-cover">
            <div class="absolute inset-0 rounded-2xl ring-0 ring-inset ring-gray-900/10"></div>
        </div>
        <div>
            <div class="flex items-center gap-x-4 text-xs">
                <time datetime="2020-03-16" class="text-gray-500">Mar 16, 2020</time>
                <a href="#"
                    class="relative z-10 rounded-full bg-gray-50 px-3 py-1.5 font-medium text-gray-600 hover:bg-gray-100">${document.teacher.subject.name}</a>
            </div>
            <div class="group relative max-w-xl">
                <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                    <a href="#">
                        <span class="absolute inset-0"></span>
                        ${document.name}
                    </a>
                </h3>
                <p class="mt-5 text-sm leading-6 text-gray-600">${document.description}</p>
            </div>
            <div class="mt-6 flex border-t border-gray-900/5 pt-6">
                <div class="relative flex items-center gap-x-4">
                    <img src="https://images.unsplash.com/photo-1519244703995-f4e0f30006d5?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
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

customElements.define("student-doc", StudentDocumentComponent);