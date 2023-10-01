import { data } from "../../../../app.store";
import { RequestParams } from "../../../../models/requestParams";
import dataService from "../../../../services/data.service";
import { DEFAULT_DOC_DES } from "../../../../app.config";

export class StudentDocumentComponent extends HTMLElement {

    #documents = [];

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
    <div class="bg-white w-full h-full">
        <div class="w-full h-full flex gap-x-8">
            <div class="w-1/6 h-full">
                <student-doc-filter></student-doc-filter>
            </div>
            <div class="w-5/6 h-max	pt-2 pb-10">             
                <student-doc-grid></student-doc-grid>
                <student-doc-pagination></student-doc-pagination>
            </div>
        </div>
    </div>   
        `;
    }
}

customElements.define("student-doc", StudentDocumentComponent);