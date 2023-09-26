import { data } from "../../../../app.store";

export class MarkInfoComponent extends HTMLElement {

    #student;
    #user;

    constructor() {
        super();
        this.#user = data.currentUser;
        this.#student = data.currentUser.student;
    }

    connectedCallback() {
        this.innerHTML = this.#render();
    }

    disconnectedCallback() {

    }

    #render() {
        return `
    <div class="overflow-hidden bg-amber-50 sm:rounded-xl">
        <div class="px-4 py-6 sm:px-6">
            <h3 class="text-base font-semibold leading-7 text-orange-600">Student Information</h3>
            <p class="mt-1 max-w-2xl text-sm leading-6 text-gray-500">Personal details and statistics.</p>
        </div>
        <div class="border-t border-dashed border-gray-400">
            <dl class="divide-y divide-dashed divide-gray-400">
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                    <dt class="text-sm font-medium text-gray-900">Full name</dt>
                    <dd class="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">${this.#user.fullName}</dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                    <dt class="text-sm font-medium text-gray-900">Main class</dt>
                    <dd class="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">${this.#student.mainClass.name}</dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                    <dt class="text-sm font-medium text-gray-900">GPA</dt>
                    <dd class="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">N/A</dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                    <dt class="text-sm font-medium text-gray-900">Qualify</dt>
                    <dd class="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">N/A</dd>
                </div>
                <div class="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-6">
                    <dt class="text-sm font-medium text-gray-900">Ranking</dt>
                    <dd class="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0">N/A</dd>
                </div>              
            </dl>
        </div>
    </div>        
        `;
    }
}

customElements.define("mark-info", MarkInfoComponent);