import { data } from "../../../../app.store";
import dataService from "../../../../services/data.service";

export class StudentExtraClassComponent extends HTMLElement {


    constructor() {
        super();
    }

    connectedCallback() {
        
        if (data.extraClasses.length === 0) {
            dataService.getExtraClasses()
                .then(res => {
                    data.extraClasses = res.data;
                    this.innerHTML = this.#render();
                });
        } else {
            this.innerHTML = this.#render();
        } 

    }

    disconnectedCallback() {
        
    }

    #render() {
        return `
        <div class="w-full flex justify-between gap-10 h-full">
          <student-ec-grid class="w-3/4 h-full"></student-ec-grid>
          <student-ec-list class="h-full w-1/4 flex flex-col gap-y-12 py-3"></student-ec-list>
        </div>
        `;
    }
}

customElements.define("student-ec", StudentExtraClassComponent);

