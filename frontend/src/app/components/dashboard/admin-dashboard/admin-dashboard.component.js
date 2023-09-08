import dataService from "../../../services/data.service";
import { formatDate } from "../../../helpers/datetime.helper.js";
import { searchByName } from "../../../helpers/search.helper.js";

export class AdminDashboardComponent extends HTMLElement {

    constructor() {
        super();
    }

    connectedCallback() {
        // document.documentElement = <html></html>
        document.documentElement.classList.remove("bg-white");
        document.documentElement.classList.add("bg-gray-900");
        this.innerHTML = this.#render();
        const main = document.querySelector("main");
        // main.insertAdjacentHTML("beforeend", this.#renderStudentsTable());
        // this.#renderStudentsRows();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
        <div class="h-full">
            <admin-sidebar></admin-sidebar>
            <admin-main></admin-main>        
        </div>
        `;
    }
    
}

customElements.define("admin-dashboard", AdminDashboardComponent);
